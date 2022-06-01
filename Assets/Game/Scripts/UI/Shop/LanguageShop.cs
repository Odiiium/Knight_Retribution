using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LanguageShop : MonoBehaviour
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
                textArray[0].text = "Heroes";
                textArray[1].text = "Abilities";
                for (int i = 2; i < textArray.Length; i++)
                {
                    textArray[i].text = "Choise";
                }
                break;
            case 1:
                textArray[0].text = "Герої";
                textArray[1].text = "Здібності";
                for (int i = 2; i < textArray.Length; i++)
                {
                    textArray[i].text = "Вибрати";
                }
                break;
            case 2:
                textArray[0].text = "Герои";
                textArray[1].text = "Способности";
                for (int i = 2; i < textArray.Length; i++)
                {
                    textArray[i].text = "Выбрать";
                }
                break;
        }
    }

}
