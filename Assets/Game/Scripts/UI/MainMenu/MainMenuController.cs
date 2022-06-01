using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button prefsButton;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("PrefsButtonCondition") == 0)
        {
            prefsButton.gameObject.SetActive(true);
        }
        else
        {
            prefsButton.gameObject.SetActive(false);
        }

    }
    public void OnPlay()
    {
        if (SettingsController.enableTutorial)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            SceneManager.LoadScene("PostGameMenu");
        }
    }

    public void PrefsInitialize()
    {
        PlayerPrefs.SetInt("maximalWave", 1);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("skillPoints", 0);
        PlayerPrefs.SetInt("agilityCount", 0);
        PlayerPrefs.SetInt("strengthCount", 0);
        PlayerPrefs.SetInt("intelligenceCount", 0);
        PlayerPrefs.SetFloat("maxHealth", 250);
        PlayerPrefs.SetFloat("maxMana", 100);
        PlayerPrefs.SetFloat("damage", 40);
        PlayerPrefs.SetInt("healthPotionsCount", 0);
        PlayerPrefs.SetInt("manaPotionsCount", 0);
        PlayerPrefs.SetInt("fireBallDamage", 100);
        PlayerPrefs.SetInt("fireBallBurnDamage", 20);
        PlayerPrefs.SetInt("lightingBoltDamage", 160);
        PlayerPrefs.SetFloat("lightingBoltStunDuration", 1.5f);
        PlayerPrefs.SetFloat("blackHoleDuration", 1f);
        PlayerPrefs.SetInt("blackHoleDamage", 44);
        PlayerPrefs.SetInt("playerLvl", 0);
        PlayerPrefs.SetInt("expiriencePoints", 0);
        PlayerPrefs.SetInt("PrefsButtonCondition", 1);
        PlayerPrefs.SetInt("gameSession", 0);

        PlayerPrefs.SetInt("adsWatched", 150);

        PlayerPrefs.Save();
        prefsButton.gameObject.SetActive(false);
        OnPlay();
    }

    public void OnSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnStore()
    {
        SceneManager.LoadScene("Shop");
    }
    public void OnLeaderboard()
    {
    }
}
