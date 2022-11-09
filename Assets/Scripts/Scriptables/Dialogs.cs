using UnityEngine;
    
[CreateAssetMenu(fileName = "DialogsData", menuName = "My Project/Add Dialog", order = 0)]
public class Dialogs : ScriptableObject 
{
    public Lines[] Lines;
}

[System.Serializable]
public class Lines 
{
    public enum Characters {
        You,
        Pink,
        Yellow,
        OtherPink
    }
    public Characters Name;
    [TextArea(5,10)]
    public string DialogText;
}