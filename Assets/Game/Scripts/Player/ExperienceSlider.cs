using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ExperienceSlider : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        if (PlayerPrefs.GetInt("playerLvl") == 0 & PlayerPrefs.GetInt("expiriencePoints") < 51)
        {
            slider.maxValue = 51;
            slider.value = Convert.ToSingle(PlayerPrefs.GetInt("expiriencePoints"));
        }
        else
        {
            slider.maxValue = (Mathf.Pow(Convert.ToSingle((PlayerPrefs.GetInt("playerLvl") + 1)), 2.35f) + 50) - (Mathf.Pow(Convert.ToSingle(PlayerPrefs.GetInt("playerLvl")), 2.35f) + 50);
            slider.value = Convert.ToSingle(PlayerPrefs.GetInt("expiriencePoints")) - (Mathf.Pow(Convert.ToSingle(PlayerPrefs.GetInt("playerLvl")), 2.35f) + 50);
        }
    }
}
