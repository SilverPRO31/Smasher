using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = respawn.transform.position;
            HealthController.scoreHeart--;
            PlayerController.score -= 250;
        }
    }
}
