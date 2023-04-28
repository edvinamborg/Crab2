using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Crab : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 6;
    public TMP_Text scoreDisplay;
    private TMP_Text scoreDisplaytext;
    private int score = 0;
    public TMP_Text livDisplay;
    private TMP_Text livDisplaytext;
    private int Liv = 3;
    public TMP_Text gameover;
    public TMP_Text restart;
    public TMP_Text vinst;
  
   
    
    
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
        gameover.enabled = false;
        restart.enabled = false;
        vinst.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
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
                rb.rotation += 4;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // and turn right
                rb.rotation -= 4;
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

            if (score == 6)
            {
                Time.timeScale = 0;
                vinst.enabled = true;
                restart.enabled = true;
            }
        }

        else if (collision.gameObject.name.StartsWith("lobster"))
        {
            Debug.Log("collision2");
            Liv = Liv - 1;
            Destroy(collision.gameObject);
            livDisplay.text = "Liv: " + Liv;

            if (Liv == 0)
            {
                Time.timeScale = 0;
                gameover.enabled = true;
                restart.enabled = true;
            }



        }
    }
    
}



