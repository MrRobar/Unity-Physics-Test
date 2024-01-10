using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class VMTest : MonoBehaviour
{
    public float angle;
    public float speed;
    public Rigidbody2D rb;
    public TextMeshProUGUI debugText;
    public float originalSpeed;

    private void Start()
    {
        float horizontalSpeed = speed * Mathf.Cos(angle * Mathf.Deg2Rad);
        float verticalSpeed = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

        rb.AddForce(new Vector2(verticalSpeed, horizontalSpeed), ForceMode2D.Impulse);
        originalSpeed = rb.velocity.magnitude;
    }

    private void Update()
    {
        debugText.text = $"Magnitude: {rb.velocity.magnitude} \n Normalized: {rb.velocity.normalized}";
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.velocity = rb.velocity.normalized * (originalSpeed * 0.1f);
            rb.gravityScale = 0.015f;
        }
    }
}