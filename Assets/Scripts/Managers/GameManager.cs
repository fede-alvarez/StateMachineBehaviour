using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HarvestUI _ui;
    private static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }else{
            instance = this;
        }
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

    public static GameManager GetInstance
    {
        get { return instance;}
    }
}
