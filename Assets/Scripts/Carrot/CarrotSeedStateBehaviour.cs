using UnityEngine;

public class CarrotSeedStateBehaviour : StateMachineBehaviour
{
    [SerializeField] private ParticleSystem _growParticles;
    [SerializeField] private float _seedStateDuration = 4.0f;
    [SerializeField] private float _stateTransitionSpeed = 0.1f;

    [SerializeField] private float _stateDuration;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _stateDuration = _seedStateDuration;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _stateDuration -= _stateTransitionSpeed * Time.deltaTime;
        if (_stateDuration <= 0)
        {
            // Change state ASAP
            // animator.Play("Grow");

            animator.SetInteger("SeedStates", 1);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ParticleSystem ps = Instantiate(_growParticles, animator.transform.position, Quaternion.identity);
        if (ps != null)
            ps.Play();
    }
}
