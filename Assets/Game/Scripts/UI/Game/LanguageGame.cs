using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LanguageGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textArray;

    void Start()
    {
        SwitchLanguage();
    }

    private void SwitchLanguage()
    {
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                textArray[0].text = "Game is paused";
                textArray[1].text = "NEW LVL";
                textArray[2].text = "New Highscore!";
                break;
            case 1:
                textArray[0].text = "Гра на паузі";
                textArray[1].text = "Hовий Pівень";
                textArray[2].text = "Новий Pекорд!";

                break;
            case 2:
                textArray[0].text = "игра на паузе";
                textArray[1].text = "Hовый уровень";
                textArray[2].text = "Новый Рекорд!";
                break;
        }
    }
}
