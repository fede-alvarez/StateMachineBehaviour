using UnityEngine;

public class NPCSecondApparition : StateMachineBehaviour
{
    [SerializeField] private Dialogs _dialogs;
    private NPC _parentNPC;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_parentNPC == null)
        {
            _parentNPC = animator.transform.GetComponent<NPC>();
        }

        _parentNPC.SetDialogScriptable(_dialogs);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        return;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        return;
    }
}
