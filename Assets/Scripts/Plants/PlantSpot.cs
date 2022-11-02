using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlantSpot : MonoBehaviour
{
    [SerializeField] private GameObject _keyPrompt;
    [SerializeField] private CanvasGroup _plantTimerGroup;
    [SerializeField] private Image _barFillImage;

    private bool _isNear = false;
    private bool _startTimer = false;
    private PlayerController _player;

    private void Start() 
    {
        _player = GameManager.GetInstance.GetPlayer;
    }

    private void Update() 
    {
        if (!_isNear) return;
        _startTimer = _player.IsActionPressed;
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
        _keyPrompt.SetActive(false);
    }
}
