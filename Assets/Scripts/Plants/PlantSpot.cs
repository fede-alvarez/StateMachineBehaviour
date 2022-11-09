using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PlantSpot : MonoBehaviour
{
    [SerializeField] private GameObject _keyPrompt;
    [SerializeField] private CanvasGroup _plantTimerGroup;
    [SerializeField] private Image _barFillImage;
    [SerializeField] private CanvasGroup _barCanvas;

    [SerializeField] private GameObject _plantSeed;

    private bool _isNear = false;
    private bool _startTimer = false;
    private bool _isCompleted = false;
    private PlayerController _player;

    private void Start() 
    {
        _player = GameManager.GetInstance.GetPlayer;
    }

    private void Update() 
    {
        if (!_isNear || _isCompleted) return;
        bool isActionPressed = _player.IsActionPressed;
        
        if (isActionPressed && !_startTimer)
        {
            _startTimer = true;
            _barCanvas.DOFade(1, 0.1f);
            _barFillImage.DOFillAmount(1, 2f)
                         .SetEase(Ease.Linear)
                         .OnComplete(OnPlantPlanted);
        }

        if (!_startTimer) return;
        if (!isActionPressed)
        {
            ResetCanvas();
        }
    }

    private void OnPlantPlanted()
    {
        ResetCanvas();
        ResetSpot();

        _isCompleted = true;
        
        if (_plantSeed != null)
            Instantiate(_plantSeed, transform.position - new Vector3(0,0.5f), Quaternion.identity);
    }

    private void ResetCanvas()
    {
        _barCanvas.DOFade(0, 0.1f);
        _barFillImage.DOKill();
        _barFillImage.fillAmount = 0;
        _startTimer = false;
    }

    private void ResetSpot()
    {
        _keyPrompt.SetActive(false);
        _isNear = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Player") || _isCompleted) return;
        _isNear = true;
        _keyPrompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (!other.CompareTag("Player") || _isCompleted) return;
        _isNear = false;
        _keyPrompt.SetActive(false);
    }
}
