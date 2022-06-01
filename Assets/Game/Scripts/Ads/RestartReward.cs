using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartReward : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private readonly string  androidAdID = "Rewarded_Android";

    private string adID;

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
        try
        {
            if (PlayerPrefs.GetInt("gameSession") <= 4)
            {
                SpawnManager.waveCount = PlayerPrefs.GetInt("restartWave");
                PlayerPrefs.SetInt("gameSession", PlayerPrefs.GetInt("gameSession") + 1);
                SceneManager.LoadScene("Game");
            }
            if (PlayerPrefs.GetInt("gameSession") >= 5)
            {
                PlayerPrefs.SetInt("gameSession", 0);
                Advertisement.Show(adID, this);
                LoadAd();
            }
        }
        catch { }
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(adID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            PlayerPrefs.SetInt("adsWatched", PlayerPrefs.GetInt("adsWatched") + 1);
            SpawnManager.waveCount = PlayerPrefs.GetInt("restartWave");
            SceneManager.LoadScene("Game");
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    { 
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }
}
