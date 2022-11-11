using UnityEngine;
using System.Collections.Generic;

public class NPCFirstApparition : StateMachineBehaviour
{
    [SerializeField] private List<Dialogs> _dialogs;
    private NPC _parentNPC;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_parentNPC == null)
        {
            _parentNPC = animator.transform.GetComponent<NPC>();
        }

        _parentNPC.SetDialogScriptable(_dialogs[(int) NPC.Options.FirstOption]);
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
