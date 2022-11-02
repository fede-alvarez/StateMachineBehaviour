using UnityEngine;

public class PlayerWalkState : StateMachineBehaviour
{
    private PlayerController _controller;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_controller == null) 
        {
            _controller = animator.transform.GetComponent<PlayerController>();
        }

        _controller.StartMoving = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_controller.IsMoving)
            animator.SetBool("Walking", false);

        if (_controller.IsJumpPressed)
            animator.SetBool("Jump", true);

        if (_controller.IsDashPressed)
            animator.SetTrigger("Dash");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _controller.StartMoving = false;
    }
}
