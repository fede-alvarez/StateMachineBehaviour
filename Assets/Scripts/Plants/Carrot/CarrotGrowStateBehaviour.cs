using UnityEngine;

public class CarrotGrowStateBehaviour : StateMachineBehaviour
{
    [SerializeField] private float _growStateDuration = 1f;
    [SerializeField] private Sprite _growStateSprite;

    private SpriteRenderer _renderer;
    private float _stateDuration;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _stateDuration = _growStateDuration;

        if (_renderer == null)
            _renderer = animator.transform.GetComponent<SpriteRenderer>();

        _renderer.sprite = _growStateSprite;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _stateDuration -= 0.1f * Time.deltaTime;

        if (_stateDuration <= 0)
            animator.SetInteger("SeedStates", 2);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        return;
    }
}
