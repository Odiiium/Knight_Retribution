using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountController : MonoBehaviour
{
    private TextMeshProUGUI countText;
    void Start()
    {
        countText = gameObject.GetComponent<TextMeshProUGUI>();
        switch (gameObject.name)
        {
            case "StrengthCount":
                countText.text = "" + PlayerPrefs.GetInt("strengthCount");
                break;
            case "AgilityCount":
                countText.text = "" + PlayerPrefs.GetInt("agilityCount");
                break;
            case "IntelligenceCount":
                countText.text = "" + PlayerPrefs.GetInt("intelligenceCount");
                break;
            case "HPCount":
                countText.text = "" + PlayerPrefs.GetFloat("maxHealth");
                break;
            case "DamageCount":
                countText.text = "" + PlayerPrefs.GetFloat("damage");
                break;
            case "HPPotionCount":
                countText.text = "" + PlayerPrefs.GetInt("healthPotionsCount");
                break;
            case "MPPotionCount":
                countText.text = "" + PlayerPrefs.GetInt("manaPotionsCount");
                break;
            case "FireDamageCount":
                countText.text = "" + PlayerPrefs.GetInt("fireBallDamage");
                break;
            case "BurnDamageCount":
                countText.text = "" + PlayerPrefs.GetInt("fireBallBurnDamage");
                break;
            case "LightingDamageCount":
                countText.text = "" + PlayerPrefs.GetInt("lightingBoltDamage");
                break;
            case "StunDurationCount":
                countText.text = "" + PlayerPrefs.GetFloat("lightingBoltStunDuration");
                break;
            case "BlackHoleDurationCount":
                countText.text = "" + PlayerPrefs.GetFloat("blackHoleDuration");
                break;
            case "BlackHoleDamageCount":
                countText.text = "" + PlayerPrefs.GetInt("blackHoleDamage");
                break;
            case "PlayersLevel":
                switch (PlayerPrefs.GetInt("usedLanguage"))
                {
                    case 0:
                        countText.text = PlayerPrefs.GetInt("playerLvl") + " LVL";
                        break;
                    case 1:
                        countText.text = PlayerPrefs.GetInt("playerLvl") + " Рівень";
                        break;
                    case 2:
                        countText.text = PlayerPrefs.GetInt("playerLvl") + " Уровень";
                        break;
                }
                break;
            case "WatchAddCount":
                countText.text = "+" + Mathf.Round(Mathf.Pow((PlayerPrefs.GetInt("strengthCount") + PlayerPrefs.GetInt("agilityCount") + PlayerPrefs.GetInt("intelligenceCount")), 1.45f));
                break;
        }
    }

}
