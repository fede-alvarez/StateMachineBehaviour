using UnityEngine;

public class PlayerDashState : StateMachineBehaviour
{
    private PlayerController _controller;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_controller == null) 
        {
            _controller = animator.transform.GetComponent<PlayerController>();
        }

        _controller.Dash();
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
