using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private float _speed = 5f;


    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _velocity * (_speed * Time.fixedDeltaTime));
    }
}