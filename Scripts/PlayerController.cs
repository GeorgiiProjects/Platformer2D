using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _move;
    private bool _isFacingRight = true;
    private bool _isOnGround = true;

    private Rigidbody2D _rigidBody2D;
    private Animator _animator;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _move = Input.GetAxis("Horizontal");

        _animator.SetFloat("Speed", Mathf.Abs(_move));

        _rigidBody2D.velocity = new Vector2(_move * _speed, _rigidBody2D.velocity.y);

        if (_move > 0 && !_isFacingRight)
        {
            Flip();
        }

        else if (_move < 0 && _isFacingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}