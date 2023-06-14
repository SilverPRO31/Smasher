using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevel : MonoBehaviour
{

    FirebaseAuth auth;
    DatabaseReference dbRef;

    public int levelNumber;
    public int levelNumber2;
    public GameObject level2;
    public GameObject level3;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public IEnumerator LoadData()
    {
        var user = dbRef.Child("Users").Child(auth.CurrentUser.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.LogException(user.Exception);
        }
        else if (user.Result.Value == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = user.Result;
            levelNumber = Convert.ToInt32(snapshot.Child("1 уровень").Value);
            levelNumber2 = Convert.ToInt32(snapshot.Child("2 уровень").Value);
        }
        if (levelNumber == 1)
        {
            level2.SetActive(true);
        }
        else
        {
            level2.SetActive(false);
        }
        if (levelNumber2 == 1)
        {
            level3.SetActive(true);
        }
        else
        {
            level3.SetActive(false);
        }
    }
}
