using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WriteLeaderScore : MonoBehaviour
{

    FirebaseAuth auth;
    DatabaseReference dbRef;
    public string level;
    public static int time;
    public static string timeText;
    private int score;
    private int scoreTime;

    void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
    }

    public void WriteScore()
    {
        StartCoroutine(Leader());
    }

    public IEnumerator Leader()
    {
        var leader = dbRef.Child("Leaders").Child(level).Child(auth.CurrentUser.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => leader.IsCompleted);

        if (leader.Exception != null)
        {
            Debug.LogException(leader.Exception);
        }
        else if (leader.Result.Value == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = leader.Result;
            score = Convert.ToInt32(snapshot.Child("—чет").Value);
            scoreTime = Convert.ToInt32(snapshot.Child("¬рем€—равнение").Value);
        }
        if (score < ButtonController.scoreFinal)
        {
            dbRef.Child("Leaders").Child(level).Child(auth.CurrentUser.UserId).Child("—чет").SetValueAsync(ButtonController.scoreFinal);
            dbRef.Child("Leaders").Child(level).Child(auth.CurrentUser.UserId).Child("¬рем€—равнение").SetValueAsync(time);
            dbRef.Child("Leaders").Child(level).Child(auth.CurrentUser.UserId).Child("¬рем€").SetValueAsync(timeText);
        }
        else if (score == ButtonController.scoreFinal)
        {
            if (scoreTime > time)
            {
                dbRef.Child("Leaders").Child(level).Child(auth.CurrentUser.UserId).Child("¬рем€—равнение").SetValueAsync(time);
                dbRef.Child("Leaders").Child(level).Child(auth.CurrentUser.UserId).Child("¬рем€").SetValueAsync(timeText);
            }
        }
    }
}
