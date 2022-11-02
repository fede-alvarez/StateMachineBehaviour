using UnityEngine;

public class PlayerJumpState : StateMachineBehaviour
{
    private PlayerController _controller;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_controller == null) 
        {
            _controller = animator.transform.GetComponent<PlayerController>();
        }

        _controller.StartMoving = true;
        _controller.Jump();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_controller.IsFalling && _controller.IsGrounded)
          animator.SetBool("Jump", false);

        if (_controller.IsDashPressed)
            animator.SetTrigger("Dash");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _controller.StartMoving = false;
    }
}
