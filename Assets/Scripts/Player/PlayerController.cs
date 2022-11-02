using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _body;
    private float _inputDirection;
    private bool _actionPressed = false;
    private bool _jumpPressed = false;
    private bool _dashPressed = false;
    private bool _startMoving = false;
    [SerializeField] private bool _isGrounded = true;

    private void Awake() 
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        _inputDirection = Input.GetAxisRaw("Horizontal");
        _actionPressed = Input.GetKey(KeyCode.E);
        _jumpPressed = Input.GetButtonDown("Jump");
        _dashPressed = Input.GetButtonDown("Fire3");

        Debug.DrawRay(transform.position, transform.up * -1 * 0.2f, Color.magenta);
        _isGrounded = Physics2D.Raycast(transform.position, transform.up * -1, 0.2f);
    }

    private void FixedUpdate() 
    {
        if (_startMoving)
            MoveByInput();
    }

    public void MoveByInput()
    {
        _body.velocity = new Vector2(_inputDirection * 5, _body.velocity.y);
    }

    public void Jump()
    {
        _body.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
    }

    public void Dash()
    {
        int facing = 1;
        if (_inputDirection == -1)
            facing = -1;

        //Debug.DrawRay(transform.position, Vector2.right * _inputDirection * 20, Color.magenta, 3);
        _body.AddForce(Vector2.right * facing * 8, ForceMode2D.Impulse);
    }

    public bool IsGrounded 
    {
        get { return _isGrounded; }
    }

    public bool IsFalling 
    {
        get { return _body.velocity.y < 0.01f; }
    }

    public bool IsMoving 
    {
        get { return _inputDirection != 0; }
    }

    public bool IsActionPressed 
    {
        get { return _actionPressed; }
    }

    public bool IsJumpPressed 
    {
        get { return _jumpPressed; }
    }

    public bool IsDashPressed
    {
        get { return _dashPressed; }
    }

    public bool StartMoving
    {
        get { return _startMoving; }
        set { _startMoving = value; }
    }

    public Rigidbody2D GetBody 
    {
        get { return _body; }
    }
}
