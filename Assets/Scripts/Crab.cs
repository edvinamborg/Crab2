using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Crab : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4;
    public TMP_Text scoreDisplay;
    private TMP_Text scoreDisplaytext;
    private int score = 0;
    public TMP_Text livDisplay;
    public TMP_Text GameOver;
    private TMP_Text livDisplaytext;
    private int Liv = 3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Physics enginge will not rotate Crab
        rb.freezeRotation = true;
        // remove gravity
        rb.gravityScale = 0;
        scoreDisplaytext = scoreDisplay.GetComponent<TMP_Text>();
        livDisplaytext = livDisplay.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            // walk
            float angleRadians = rb.rotation * Mathf.PI / 180f;
            float xSpeed = Mathf.Cos(angleRadians) * speed;
            float ySpeed = Mathf.Sin(angleRadians) * speed;
            rb.velocity = new Vector2(xSpeed, ySpeed);

            if (Input.GetKey(KeyCode.A))
            {
                // and turn left
                rb.rotation += 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // and turn right
                rb.rotation -= 1;
            }
        }
        else
        {
            // do not move
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.name.StartsWith("worm"))
        {
            Debug.Log("collision1");
            Destroy(collision.gameObject);
            score = score + 1;
            scoreDisplaytext.text = "Score: " + score;
        }

        else if (collision.gameObject.name.StartsWith("lobster"))
        {
            Debug.Log("collision2");
            Liv = Liv - 1;
            Destroy(collision.gameObject);
            livDisplay.text = "Liv: " + Liv;

        }
    }
    
}



