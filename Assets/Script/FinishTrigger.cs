using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTrigger : MonoBehaviour
{

    FirebaseAuth auth;
    DatabaseReference dbRef;

    public static int trig = 0;
    public GameObject inter;
    public GameObject final;
    public string level;

    private void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (trig == 1)
        {
            dbRef.Child("Users").Child(auth.CurrentUser.UserId).Child(level).SetValueAsync(1);
            inter.SetActive(false);
            final.SetActive(true);
            trig = 0;
        }
    }
}
