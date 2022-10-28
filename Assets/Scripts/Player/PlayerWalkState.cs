using UnityEngine;

public class PlayerWalkState : StateMachineBehaviour
{
    private Rigidbody2D _body;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_body == null)
            _body = animator.transform.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float inputDirection = Input.GetAxisRaw("Horizontal");
        
        if (inputDirection == 0)
            animator.SetBool("Walking", false);

        _body.velocity = new Vector3(inputDirection * 5, 0, 0);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       return;
    }
}
