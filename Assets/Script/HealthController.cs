using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static int scoreHeart;
    public Text heartScore;
    public GameObject inter;
    public GameObject die;

    private void Start()
    {
        scoreHeart = 3;
    }

    private void Update()
    {
        heartScore.text = "" + scoreHeart;
        if (scoreHeart < 1)
        {
            Time.timeScale = 0f;
            inter.SetActive(false);
            die.SetActive(true);
        }
    }
}
