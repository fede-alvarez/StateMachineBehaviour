using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum Options {
        FirstOption,
        SecondOption
    }

    public delegate void PlayerInteracted(Lines[] lines, NPC npc);
    public PlayerInteracted OnPlayerInteracted;

    [SerializeField] private GameObject _keyPrompt;

    private Dialogs _dialogsSO;

    private bool _isNear = false;
    private bool _isActive = true;

    private Animator _anim;

    private void Awake() 
    {
        _anim = GetComponent<Animator>();    
    }

    private void Update() 
    {
        if (!_isActive) return;

        if (_isNear && Input.GetKeyDown(KeyCode.E))
        {
            if (_dialogsSO != null)
                OnPlayerInteracted?.Invoke(_dialogsSO.Lines, this);
            else
                Debug.LogError("Dialog scriptable not assigned!");
            
            _isActive = false;
            _keyPrompt.SetActive(false);
        }
    }

    public void SetDialogScriptable(Dialogs dialog)
    {
        _dialogsSO = dialog;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Player")) return;
        _isNear = true;
        _keyPrompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (!other.CompareTag("Player")) return;
        _isNear = false;
        _isActive = true;
        _keyPrompt.SetActive(false);
    }

    public bool IsActive {
        get { return _isActive; }
        set { _isActive = value; }
    }
}
