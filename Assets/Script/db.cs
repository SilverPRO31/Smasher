using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using Firebase.Database;
using UnityEngine.SceneManagement;
using System;

public class DB : MonoBehaviour
{
    FirebaseAuth auth;

    public InputField namereg;
    public InputField emailreg;
    public InputField passwordreg;
    public InputField emailsign;
    public InputField passwordsign;
    public static DateTime timeStart;
    public static DateTime timeEnd;
    private ErrorManager em;
    public string email;
    public string password;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        em = GetComponent<ErrorManager>();
        auth.SignOut();
    }

    public void ButtonRegister()
    {
        auth.SignOut();
        email = emailreg.text;
        password = passwordreg.text;
        if (auth.CurrentUser == null)
        {
            StartCoroutine(em.RegisterPlayer(email, password));
        }
    }
    public async void ButtonSign()
    {
        auth.SignOut();
        email = emailsign.text;
        password = passwordsign.text;
        if (auth.CurrentUser == null)
        {
            StartCoroutine(em.SignInPlayer(email, password));
        }
        await auth.SignInWithEmailAndPasswordAsync(emailsign.text, passwordsign.text);
        if (auth.CurrentUser != null)
        {
            em.error.text = "¬ход выполнен: " + auth.CurrentUser.Email;
            SceneManager.LoadScene(1);
        }
    }
}