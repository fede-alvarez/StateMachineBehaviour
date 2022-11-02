using UnityEngine;

public class TomatoRottenStateBehaviour : StateMachineBehaviour
{
    [SerializeField] private Sprite _rottenStateSprite;

    private SpriteRenderer _renderer;
    private float _stateDuration;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_renderer == null)
            _renderer = animator.transform.GetComponent<SpriteRenderer>();

        _renderer.sprite = _rottenStateSprite;
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
