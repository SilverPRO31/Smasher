using UnityEngine;
using UnityEngine.Advertisements;

public class AddInitialization : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string androidGameId = "5310417";
    [SerializeField] string iOSGameID = "5310416";
    [SerializeField] bool testMode = false;

    private string gameID;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        gameID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOSGameID
            : androidGameId;
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Initialization Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
