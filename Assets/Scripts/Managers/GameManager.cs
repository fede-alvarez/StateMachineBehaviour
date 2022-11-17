using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HarvestUI _ui;
    [SerializeField] private PlayerController _player;
    private DialogManager _dialogManager;
    private static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }else{
            instance = this;
        }

        _dialogManager = GetComponent<DialogManager>();
    }

    private void OnDestroy()
    {
        if (instance != null)
            instance = null;
    }

    public HarvestUI GetUI 
    {
        get { return _ui; }
    }

    public PlayerController GetPlayer 
    {
        get { return _player; }
    }

    public DialogManager GetDialogManager
    {
        get { return _dialogManager; }
    }

    public static GameManager GetInstance
    {
        get { return instance;}
    }
}
