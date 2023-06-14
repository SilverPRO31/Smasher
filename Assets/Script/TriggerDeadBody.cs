using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TriggerDeadBody : MonoBehaviour
{
    public static int trig = 0;
    public GameObject Coffin;
    public GameObject block;
    private GameObject respawn;
    private GameObject create;
    public GameObject createSpawn;
    public GameObject spawn;
    public GameObject Monster;
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (trig == 1)
        {
            PlayerController.score += 500;
            trig = 0;
            respawn = Instantiate(Coffin, new Vector2 (0, 0), Quaternion.identity);
            Destroy(gameObject);
            Destroy(Monster);
            respawn.transform.position = spawn.transform.position;
            if (block != null)
            {
                create = Instantiate(block, new Vector2(0, 0), Quaternion.identity);
                create.transform.position = createSpawn.transform.position;
            }
        }
    }
}
