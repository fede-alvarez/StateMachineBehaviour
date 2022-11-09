using UnityEngine;

public class PlayerFallState : StateMachineBehaviour
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
        if (_controller.IsGrounded)
          animator.SetBool("Jump", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _controller.StartMoving = false;
    }
}
