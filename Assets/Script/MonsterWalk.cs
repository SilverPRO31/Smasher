using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed;
    public float normalSpeed;
    private bool facingRight = true;
    public GameObject respawn;

    private void Start()
    {
        speed = -6f;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (facingRight == false && speed < 0)
        {
            Flip();
        }
        else if (facingRight == true && speed > 0)
        {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "1")
        {
            if (speed >= 0f)
            {
                speed = -normalSpeed;
            }
        }
        if (collision.tag == "2")
        {
            if (speed <= 0f)
            {
                speed = normalSpeed;
            }
        }
        if (collision.tag == "Player")
        {
            collision.transform.position = respawn.transform.position;
            HealthController.scoreHeart--;
            PlayerController.score -= 250;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
