using System;
using TMPro;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private float _angle;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeScale = 0.1f;
    [SerializeField] private float _startingGravity;
    [SerializeField] private float _startingMass;
    [SerializeField] private TextMeshProUGUI _velocityText;
    private Vector2 _currentVelocity;
    private bool _frozen;
    [SerializeField] private float _originalSpeed;
    public bool isCollided = false;

    public Rigidbody2D Rb
    {
        get { return _rb; }
        set { _rb = value; }
    }

    private void Awake()
    {
        _startingGravity = _rb.gravityScale;
    }

    private void Start()
    {
        float horizontalSpeed = _speed * Mathf.Cos(_angle * Mathf.Deg2Rad);
        float verticalSpeed = _speed * Mathf.Sin(_angle * Mathf.Deg2Rad);
        _currentVelocity = new Vector2(horizontalSpeed, verticalSpeed);

        _rb.AddForce(_currentVelocity, ForceMode2D.Impulse);
        _originalSpeed = _rb.velocity.magnitude;
    }

    private void Update()
    {
        _velocityText.text = $"X: {Math.Round(_rb.velocity.x, 3)} \n Y: {Math.Round(_rb.velocity.y, 3)}";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            _rb.AddForce(-_rb.velocity * _speed * 0.5f, ForceMode2D.Impulse);
            //Time.timeScale = 0f;
        }

        if (other.CompareTag("SlowArea"))
        {
            _rb.velocity = _rb.velocity.normalized * (_rb.velocity.magnitude * 0.07f);
            _rb.gravityScale *= 0.0051f;
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