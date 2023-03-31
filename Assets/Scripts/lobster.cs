using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class lobster : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.freezeRotation = true;
        
        rb.gravityScale = 0;
        rb.velocity = new Vector2(speed, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 10)
        {
            if (Random.Range(0, 2) == 0)
            {
                rb.rotation += 5;
            }
            else
            {
                rb.rotation -= 5;
            }

        }
        float angleRadians = rb.rotation * Mathf.PI / 180f;
        float xSpeed = Mathf.Cos(angleRadians) * speed;
        float ySpeed = Mathf.Sin(angleRadians) * speed;
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Random.Range(0, 2) == 0)
        {
            rb.rotation += Random.Range(40, 90);
        }
        else
        {
            rb.rotation -= Random.Range(40, 90);
        }
        
        float angleRadians = rb.rotation * Mathf.PI / 180f;
        float xSpeed = Mathf.Cos(angleRadians) * speed;
        float ySpeed = Mathf.Sin(angleRadians) * speed;
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}
    









