using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ViewLeaderBoard : MonoBehaviour
{
    DatabaseReference dbRef;

    public Text rankScore;
    public Text nameScore;
    public Text timeScore;
    public Text scoreScore;

    void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public IEnumerator LeaderBoard(string level)
    {
        rankScore.text = "";
        nameScore.text = "";
        timeScore.text = "";
        scoreScore.text = "";

        var leader = dbRef.Child("Leaders").Child(level).OrderByChild("—чет").GetValueAsync();

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

            int rank = 1;
            foreach (DataSnapshot dataSnapshot in snapshot.Children.Reverse().Take(10))
            {
                rankScore.text += "\n" + rank + ")";
                nameScore.text += "\n" + dataSnapshot.Child("»м€").Value.ToString();
                timeScore.text += "\n" + dataSnapshot.Child("¬рем€").Value.ToString();
                scoreScore.text += "\n" + dataSnapshot.Child("—чет").Value.ToString();
                rank++;
            }
        }
    }
}
