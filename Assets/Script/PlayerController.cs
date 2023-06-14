using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float speed;
    public float normalSpeed;
    public float jumpForce;
    private bool facingRight = true;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D fullFriction;
    public static int trig = 0;
    public Text scoreText;
    public static int score;
    public static int startScore;
    public int scoreStart;

    private void Start()
    {
        speed = 0f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        startScore = scoreStart;
        score = 0;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (facingRight == false && speed > 0)
        {
            Flip();
        }
        else if (facingRight == true && speed < 0)
        {
            Flip();
        }
        if (speed == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else if (speed != 0f)
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);


        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

        SetFriction();
        scoreText.text = "—чет: " + score;
    }

    public void SetFriction()
    {
        if (isGrounded == false)
        {
            rb.sharedMaterial = noFriction;
        }
        else
        {
            rb.sharedMaterial = fullFriction;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void OnJumpButton()
    {
        if (isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOff");
        }
    }
    public void OnLeftButtonDown()
    {
        if (speed >= 0f)
        {
            speed = -normalSpeed;
        }
    }

    public void OnRightButtonDown()
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }

    public void OnButtonUp()
    {
        speed = 0f;
        anim.SetBool("isRunning", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "deadbody")
        {
            trig = 1;
        }
        if (collision.tag == "Finish")
        {
            trig = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "deadbody" || collision.tag == "Finish")
        {
            trig = 0;
        }
    }

    public void OnButtonInteraction()
    {
        if (trig == 1)
        {
            TriggerDeadBody.trig = 1;
            trig = 0;
        }
        if (trig == 2)
        {
            FinishTrigger.trig = 1;
        }
    }
}
