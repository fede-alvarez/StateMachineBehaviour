using UnityEngine;
using TMPro;

public class HarvestUI : MonoBehaviour
{
    private int _foodAmount = 0;
    private TMP_Text _text;

    private void Awake() 
    {
        _text = GetComponent<TMP_Text>();
    }

    public void IncreaseFood()
    {
        _foodAmount++;
        
        UpdateAmount();
    }

    public void UpdateAmount()
    {
        _text.text = _foodAmount.ToString();
    }
}
