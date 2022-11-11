using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _dialogContainer;
    [SerializeField] private TMP_Text _dialogCharacter;
    [SerializeField] private TMP_Text _dialogContent;
    [SerializeField] private Transform _npcsParent;
    [SerializeField] private Transform _optionsContainer;

    private Lines[] _currentLines;
    private NPC _currentNPC;

    private int _dialogsCount = 0;
    private int _dialogIndex = 0;

    private void Start() 
    {
        _dialogContainer.alpha = 0;

        _optionsContainer.gameObject.SetActive(false);

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
    }
    
    private void SetLine(int index)
    {
        _dialogCharacter.text = _currentLines[index].Name.ToString();
        _dialogContent.text = _currentLines[index].DialogText;
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
            StartCoroutine("Dialog");
    }

    private void OnDestroy() 
    {
        foreach(Transform npc in _npcsParent)
        {
            if (npc != null && npc.TryGetComponent(out NPC npcChar))
            {
                npcChar.OnPlayerInteracted -= DialogStart;
            }
        }
    }
}
