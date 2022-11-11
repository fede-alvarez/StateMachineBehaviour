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
        Pink
    }

    public Characters Name;
    [TextArea(5,10)]
    public string DialogText;
    
    [Space(10)]
    public AnswerOption[] Options;
}

[System.Serializable]
public class AnswerOption 
{
    public string Answer;
}