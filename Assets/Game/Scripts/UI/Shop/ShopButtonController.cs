using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopButtonController : MonoBehaviour
{
    [SerializeField] private GameObject[] lockedImagesArray;


    private Dictionary<string, int> heroesValues = new Dictionary<string, int>
    {
        { "1",  50  },
        { "2",  100 },
        { "3",  150 }
    };

    private void Start()
    {
        for (var i = 0; i < lockedImagesArray.Length; i++)
        {
            var valueOfLockedImage = Convert.ToInt16(lockedImagesArray[i].gameObject.name.Replace("Locked", ""));
            if (PlayerPrefs.GetInt("adsWatched") >= heroesValues.GetValueOrDefault($"{valueOfLockedImage}"))
            {
                lockedImagesArray[i].gameObject.SetActive(false);
            }

        }
    }

    public void SelectHero1()
    {
        SpawnManager.playerIndex = 0;
    }

    public void SelectHero2()
    {
        if (PlayerPrefs.GetInt("adsWatched") >= 50)
        {
            SpawnManager.playerIndex = 1;
        }
    }

    public void SelectHero3()
    {
        if (PlayerPrefs.GetInt("adsWatched") >= 100)
        {
            SpawnManager.playerIndex = 2;
        }
    }

    public void SelectHero4()
    {
        if (PlayerPrefs.GetInt("adsWatched") >= 150)
        {
            SpawnManager.playerIndex = 3;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
