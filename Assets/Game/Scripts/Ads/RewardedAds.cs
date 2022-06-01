using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private readonly string androidAdID = "Rewarded_Android";

    private string adID;

    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] Button button;

    private void Awake()
    {
        adID = androidAdID;
    }

    private void Start()
    {
        LoadAd();
    }

    public void LoadAd()
    {
        Advertisement.Load(adID, this);  
    }

    public void ShowAd()
    {
        Advertisement.Show(adID, this);
        LoadAd();
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(adID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + (50 + Mathf.RoundToInt(Mathf.Pow((PlayerPrefs.GetInt("strengthCount") + PlayerPrefs.GetInt("agilityCount") + PlayerPrefs.GetInt("intelligenceCount")), 1.45f))));
            PlayerPrefs.SetInt("adsWatched", PlayerPrefs.GetInt("adsWatched") + 1);
            countText.text = "+" + (50 + Mathf.Round(Mathf.Pow((PlayerPrefs.GetInt("strengthCount") + PlayerPrefs.GetInt("agilityCount") + PlayerPrefs.GetInt("intelligenceCount")), 1.45f)));
        }
    }


    public void OnUnityAdsAdLoaded(string adUnitId) { }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

}

