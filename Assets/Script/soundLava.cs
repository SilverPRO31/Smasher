using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundLava : MonoBehaviour
{
    private AudioSource ac;

    void Start()
    {
        ac = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lava")
        {
            ac.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Lava")
        {
            ac.Pause();
        }
    }
}
