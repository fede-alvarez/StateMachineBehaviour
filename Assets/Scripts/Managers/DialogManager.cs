using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using DG.Tweening;

public class DialogManager : MonoBehaviour
{
    public delegate void DialogEnded();
    public DialogEnded OnDialogEnded;

    [Header("Setup")]
    [SerializeField] private CanvasGroup _dialogContainer;
    [SerializeField] private TMP_Text _dialogCharacter;
    [SerializeField] private TMP_Text _dialogContent;

    [Header("NPCs")]
    [SerializeField] private Transform _npcsParent;

    [Header("Options")]
    [SerializeField] private Transform _optionsContainer;

    private Lines[] _currentLines;
    private Lines _actualLine;
    private NPC _currentNPC;

    private int _dialogsCount = 0;
    private int _dialogIndex = 0;

    private void Start() 
    {
        _dialogContainer.alpha = 0;

        SetOptionsActive(false);

        foreach(Transform npc in _npcsParent)
        {
            if (npc.TryGetComponent(out NPC npcChar))
            {
                npcChar.OnPlayerInteracted += DialogStart;
            }
        }
    }

    private void DialogStart(Lines[] lines, NPC npc)
    {
        _currentLines = lines;
        _currentNPC = npc;

        _dialogsCount = _currentLines.Length;
        _dialogIndex = 0;
        
        _dialogContainer.DOFade(1, 0.5f);
        SetLine(_dialogIndex);
    }

    private IEnumerator Dialog()
    {
        StopCoroutine("DialogByChar");

        for (int i = 1; i < _dialogsCount; i++)
        {
            yield return new WaitForSeconds(2);
            _dialogIndex += 1;

            if (_dialogIndex > _dialogsCount - 1)
                _dialogIndex = _dialogsCount - 1;

            SetLine(_dialogIndex);
        }

        yield return new WaitForSeconds(2);

        CloseDialog();
    }

    private void CloseDialog()
    {
        StopCoroutine("Dialog");
        _dialogContainer.DOFade(0, 0.5f);
        _currentNPC.IsActive = true;

        if (OnDialogEnded != null)
            OnDialogEnded.Invoke();
    }
    
    private void SetLine(int index)
    {
        _actualLine = _currentLines[index];

        _dialogCharacter.text = _actualLine.Name.ToString();
        _dialogContent.text = _actualLine.DialogText;
        _dialogContent.maxVisibleCharacters = 0;

        StartCoroutine("DialogByChar", _dialogContent.text.Length);
    }

    private IEnumerator DialogByChar(int totalChars)
    {
        for (int i = 0; i <= totalChars; i++)
        {
            yield return new WaitForSeconds(0.03f);
            _dialogContent.maxVisibleCharacters = i;
        }

        if (_dialogIndex + 1 < _dialogsCount)
        {
            StartCoroutine("Dialog");
        }else{

            if (_actualLine.Options.Length > 0) 
            {
                SetOptionsActive(true);
                int index = 0;

                foreach (Transform option in _optionsContainer)
                {
                    int j = index;

                    if (option.Find("Text").TryGetComponent(out TMP_Text optionText))
                    {
                        optionText.text = _actualLine.Options[index].Answer;
                    }

                    if (option.TryGetComponent(out Button optionButton))
                    {
                        optionButton.onClick.AddListener(() => DialogAfterOptions(j));
                    }

                    index++;
                }
            }else{
                yield return new WaitForSeconds(2);
                CloseDialog();
            }
        }
    }

    private void DialogAfterOptions(int index)
    {
        int i = 0;
        foreach (Transform option in _optionsContainer)
        {
            int j = i;
            if (option.TryGetComponent(out Button optionButton))
            {
                optionButton.onClick.RemoveListener(() => DialogAfterOptions(j));
            }
            i++;
        }

        SetOptionsActive(false);
        CloseDialog();
        DialogStart(_actualLine.Options[index].NextDialog.Lines, _currentNPC);
    }

    private void SetOptionsActive(bool state)
    {
        _optionsContainer.gameObject.SetActive(state);
    }
    
    private void OnDestroy() 
    {
        int index = 0;
        foreach (Transform option in _optionsContainer)
        {
            int j = index;

            if (option.TryGetComponent(out Button optionButton))
                optionButton.onClick.RemoveListener(() => DialogAfterOptions(j));

            index++;
        }

        if (_npcsParent == null) return;

        foreach(Transform npc in _npcsParent)
        {
            if (npc.TryGetComponent(out NPC npcChar))
            {
                npcChar.OnPlayerInteracted -= DialogStart;
            }
        }
    }
}
