using UnityEngine;

public class PlayerIdleState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        return;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float inputDirection = Input.GetAxisRaw("Horizontal");
        
        if (inputDirection != 0)
            animator.SetBool("Walking", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       return;
    }
}
