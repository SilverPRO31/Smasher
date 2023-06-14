using UnityEngine;
using UnityEngine.Advertisements;

public class Add : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string androidAdId = "Interstitial_Android";
    [SerializeField] string iOSAdId = "Interstitial_iOS";

    private string adId;

    private void Awake()
    {
        adId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOSAdId
            : androidAdId;
        LoadAd();
    }

    public void LoadAd()
    {
        Advertisement.Load(adId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(adId, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
