using UnityEngine;

public class NPC : MonoBehaviour
{
    public delegate void PlayerInteracted(Lines[] lines, NPC npc);
    public PlayerInteracted OnPlayerInteracted;

    [SerializeField] private Dialogs _dialogsSO;

    private bool _isNear = false;
    private bool _isActive = true;

    private void Update() 
    {
        if (!_isActive) return;

        if (_isNear && Input.GetKeyDown(KeyCode.E))
        {
            OnPlayerInteracted?.Invoke(_dialogsSO.Lines, this);
            _isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Player")) return;
        _isNear = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (!other.CompareTag("Player")) return;
        _isNear = false;
        _isActive = true;
    }

    public bool IsActive {
        get { return _isActive; }
        set { _isActive = value; }
    }
}
