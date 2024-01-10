using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private float _angle;
    [SerializeField] private float _speed;
    [SerializeField] private float _velocitySlowmoFactor = 0.07f;
    [SerializeField] private float _gravitySlowmoFactor = 0.0051f;
    private Vector2 _currentVelocity;

    private void Start()
    {
        float horizontalSpeed = _speed * Mathf.Cos(_angle * Mathf.Deg2Rad);
        float verticalSpeed = _speed * Mathf.Sin(_angle * Mathf.Deg2Rad);
        _currentVelocity = new Vector2(horizontalSpeed, verticalSpeed);

        _rb.AddForce(_currentVelocity, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            _rb.AddForce(-_rb.velocity * _speed * 0.5f, ForceMode2D.Impulse);
        }

        if (other.CompareTag("SlowArea"))
        {
            _rb.velocity = _rb.velocity.normalized * (_rb.velocity.magnitude * _velocitySlowmoFactor);
            _rb.gravityScale *= _gravitySlowmoFactor;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Time.timeScale = 0f;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _collider.isTrigger = false;
    }
}