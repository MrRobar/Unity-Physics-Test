using UnityEngine;
using System.Collections;

public class SlowMoScript : MonoBehaviour
{
    public float timeScale = 0.5f;
    public bool frozen = false;

    public Rigidbody2D rb2d;
    public float startMass;
    public float startGravityScale;

    public bool slowMoBool = true;

    void FixedUpdate()
    {
        if (frozen)
        {
            SlowMo();
        }
        else
        {
            StopSlowMo();
        }
    }

    void SlowMo()
    {
        rb2d.gravityScale = 0;

        if (slowMoBool)
        {
            rb2d.mass /= timeScale;
            rb2d.velocity *= timeScale;
        }

        slowMoBool = false;

        float dt = Time.fixedDeltaTime * timeScale;
        rb2d.velocity += Physics2D.gravity / rb2d.mass * dt;
    }

    void StopSlowMo()
    {
        if (!slowMoBool)
        {
            rb2d.gravityScale = startGravityScale;
            rb2d.mass = startMass;

            rb2d.velocity /= timeScale;
        }

        slowMoBool = true;
    }
}