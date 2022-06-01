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
                textArray[0].text = "��� �� ����";
                textArray[1].text = "H���� P�����";
                textArray[2].text = "����� P�����!";

                break;
            case 2:
                textArray[0].text = "���� �� �����";
                textArray[1].text = "H���� �������";
                textArray[2].text = "����� ������!";
                break;
        }
    }
}
