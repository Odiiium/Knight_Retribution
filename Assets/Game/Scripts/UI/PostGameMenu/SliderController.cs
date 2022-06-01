using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SliderController : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        if (gameObject.name == "XPSlider")
        {
            slider.maxValue = (Mathf.Pow(Convert.ToSingle((PlayerPrefs.GetInt("playerLvl") + 1)), 2.35f) + 50) - (Mathf.Pow(Convert.ToSingle(PlayerPrefs.GetInt("playerLvl")), 2.35f) + 50);
            slider.value = Convert.ToSingle(PlayerPrefs.GetInt("expiriencePoints")) - (Mathf.Pow(Convert.ToSingle(PlayerPrefs.GetInt("playerLvl")), 2.35f) + 50);
        }
    }

    private void Update()
    {    
        switch (gameObject.name)
        {
            case "StrengthSlider":
                slider.value = Convert.ToSingle(PlayerPrefs.GetInt("strengthCount"))/50;
                break;
            case "AgilitySlider":
                slider.value = Convert.ToSingle(PlayerPrefs.GetInt("agilityCount")) / 50;
                break;
            case "IntelligenceSlider":
                slider.value = Convert.ToSingle(PlayerPrefs.GetInt("intelligenceCount")) / 50;
                break;
            case "FireDamageSlider":
                slider.value = Convert.ToSingle(PlayerPrefs.GetInt("fireBallDamage") - 100) / 1250;
                break;
            case "BurnDamageSlider":
                slider.value = Convert.ToSingle(PlayerPrefs.GetInt("fireBallBurnDamage") - 20) / 500;
                break;
            case "LightingDamageSlider":
                slider.value = Convert.ToSingle(PlayerPrefs.GetInt("lightingBoltDamage") - 160 ) / 2000;
                break;
            case "StunDurationSlider":
                slider.value = (PlayerPrefs.GetFloat("lightingBoltStunDuration") - 1.5f) / 2.5f;
                break;
            case "BlackHoleDurationSlider":
                slider.value = (PlayerPrefs.GetFloat("blackHoleDuration") - 1) / 5;
                break;
            case "BlackHoleDamageSlider":
                slider.value = Convert.ToSingle(PlayerPrefs.GetInt("blackHoleDamage") - 440) / 5500;
                break;
        }
    }
}
