using UnityEngine;

public class PlayerIdleState : StateMachineBehaviour
{
    private PlayerController _controller;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_controller == null) 
        {
            _controller = animator.transform.GetComponent<PlayerController>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_controller.IsMoving)
            animator.SetBool("Walking", true);

        if (_controller.IsJumpPressed && _controller.IsGrounded)
            animator.SetBool("Jump", true);

        if (_controller.IsDashPressed)
            animator.SetTrigger("Dash");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       return;
    }
}
