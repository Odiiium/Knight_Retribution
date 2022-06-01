using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    internal string androidGameId = "4773079";
    internal string iOsGameId = "4773078"; 
    bool testMode = true; 
    private string gameID;

    private void Awake()
    {
        InitializeAds();
    }


    public void InitializeAds()
    {
        gameID = androidGameId;
        Advertisement.Initialize(gameID, testMode, this);

    }

    public void OnInitializationComplete()
    {
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }
}
