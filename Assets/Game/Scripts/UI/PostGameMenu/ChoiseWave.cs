using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class ChoiseWave : MonoBehaviour
{
    [SerializeField] private GameObject[] notActiveButtons;
    [SerializeField] private TextMeshProUGUI[] textArray;
    [SerializeField] private Image[] images;

    private Dictionary<int, int> waveValues = new Dictionary<int, int>()
    {{0, 1}, {1, 10 }, {2, 21 }, {3, 32 },
    {4, 45 }, {5, 60 }, {6, 78 }, {7,99 }};


    private void Start()
    {
        if (gameObject.name == "ButtonPanel")
        {
            for (int i = 0; i < notActiveButtons.Length; i++)
            {
                if (PlayerPrefs.GetInt("maximalWave") >= Convert.ToInt16(notActiveButtons[i].name.Replace("WaveButton", "")))
                {
                    images[i].gameObject.SetActive(false);
                }
            }
        }

        for (int i = 0; i < textArray.Length; i++)
        {
            switch (PlayerPrefs.GetInt("usedLanguage"))
            {
                case 0:
                    textArray[i].text = waveValues.GetValueOrDefault(i) + " wave";
                    break;
                case 1:
                    textArray[i].text = waveValues.GetValueOrDefault(i) + " xвиля";
                    break;
                case 2:
                    textArray[i].text = waveValues.GetValueOrDefault(i) + " волна";  
                    break;
            }

        }
    }

    public void StartWave1()
    {
        SpawnManager.waveCount = 1;
        SceneTransition.SwitchToScene("Game");
    }
    public void StartWave10()
    {
        WaveChoise(10);
    }
    public void StartWave21()
    {
        WaveChoise(21);
    }
    public void StartWave32()
    {
        WaveChoise(32);
    }
    public void StartWave45()
    {
        WaveChoise(45);
    }
    public void StartWave60()
    {
        WaveChoise(60);
    }
    public void StartWave78()
    {
        WaveChoise(78);
    }
    public void StartWave99()
    {
        WaveChoise(99);
    }
    void WaveChoise(int waveNumber)
    {
        if (PlayerPrefs.GetInt("maximalWave") >= waveNumber)
        {
            if (PlayerPrefs.GetInt("restartWave") == 0)
            {
                PlayerPrefs.SetInt("restartWave", 1);
            }
            else
            {
                PlayerPrefs.SetInt("restartWave", waveNumber);
            }
            SpawnManager.waveCount = waveNumber;
            SceneTransition.SwitchToScene("Game");
        }
    }
}
