using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocitySwapper : MonoBehaviour
{
    [SerializeField] private CanonBall _ball1, _ball2;
    public bool isSwapped = false;

    private void Start()
    {
        Debug.Log(Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (isSwapped)
        {
            return;
        }

        if (_ball1.isCollided && _ball2.isCollided)
        {
            Debug.Log(_ball1.Rb.velocity.x);
            Debug.Log(_ball2.Rb.velocity.x);
            var tmp = _ball1.Rb.velocity.x;
            _ball1.Rb.velocity.Set(_ball2.Rb.velocity.x, _ball1.Rb.velocity.y);
            _ball2.Rb.velocity.Set(tmp, _ball2.Rb.velocity.y);
            isSwapped = true;
            Debug.Log("Worked");
        }
    }
}