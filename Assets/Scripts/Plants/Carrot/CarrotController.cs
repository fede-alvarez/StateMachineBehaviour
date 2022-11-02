using UnityEngine;

public class CarrotController : MonoBehaviour
{
    [SerializeField] private GameObject _keyPrompt;
    private HarvestUI _ui;
    private Animator _anim;
    private bool _isNear = false;

    private void Awake() 
    {
        _anim = GetComponent<Animator>();
    }

    private void Start() 
    {
        _ui = GameManager.GetInstance.GetUI;
    }

    private void Update() 
    {
        /*
            _anim.GetCurrentAnimatorStateInfo(layerIndex) -> devuelve información sobre el estado actual
            .IsName chequea si el nombre del estado corresponde
        */
        bool isHarvest = _anim.GetCurrentAnimatorStateInfo(0).IsName("Harvest");
        
        if (_isNear && Input.GetKeyDown(KeyCode.E) && isHarvest)
        {
            _ui.IncreaseFood();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        _isNear = true;
        _keyPrompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        _isNear = false;
        _keyPrompt.SetActive(false);
    }
}
