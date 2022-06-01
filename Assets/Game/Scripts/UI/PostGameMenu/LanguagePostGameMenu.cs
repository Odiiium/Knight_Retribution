using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LanguagePostGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textArray;
    [SerializeField] RewardedAds rewardedAd;
    void Start()
    {
        SwitchLanguage();
    }
    private void SwitchLanguage()
    {
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                textArray[0].text = "Fireball Damage";
                textArray[1].text = "Burn Damage";
                textArray[2].text = "Lightning Bolt Damage";
                textArray[3].text = "Stun Duration";
                textArray[4].text = "Duration";
                textArray[5].text = "Damage";
                textArray[6].text = "Сhoise wave for start";
                break;
            case 1:
                textArray[0].text = "Урон";
                textArray[1].text = "Періодичний Урон";
                textArray[2].text = "Урон Блискавки";
                textArray[3].text = "Tривалість Стану";
                textArray[4].text = "Tривалість";
                textArray[5].text = "Урон";
                textArray[6].text = "Bиберiть хвилю для старту";

                break;
            case 2:
                textArray[0].text = "Урон";
                textArray[1].text = "Периодический Урон";
                textArray[2].text = "Урон Молнии";
                textArray[3].text = "Время Oглушения";
                textArray[4].text = "Bремя действия";
                textArray[5].text = "Урон";
                textArray[6].text = "Выберите волну что бы начать";
                break;
        }
    }
}
