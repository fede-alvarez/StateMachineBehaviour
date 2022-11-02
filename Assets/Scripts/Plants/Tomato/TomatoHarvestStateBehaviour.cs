using UnityEngine;

public class TomatoHarvestStateBehaviour : StateMachineBehaviour
{
    [SerializeField] private float _harvestStateDuration = 2f;
    [SerializeField] private float _stateTransitionSpeed = 0.1f;
    [SerializeField] private Sprite _harvestStateSprite;

    private SpriteRenderer _renderer;
    private float _stateDuration;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _stateDuration = _harvestStateDuration;
        
        if (_renderer == null)
            _renderer = animator.transform.GetComponent<SpriteRenderer>();

        _renderer.sprite = _harvestStateSprite;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _stateDuration -= _stateTransitionSpeed * Time.deltaTime;

        if (_stateDuration <= 0)
            animator.SetInteger("SeedStates", 3);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        return;
    }
}
