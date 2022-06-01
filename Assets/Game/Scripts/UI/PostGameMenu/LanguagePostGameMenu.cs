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
                textArray[6].text = "�hoise wave for start";
                break;
            case 1:
                textArray[0].text = "����";
                textArray[1].text = "���������� ����";
                textArray[2].text = "���� ���������";
                textArray[3].text = "T�������� �����";
                textArray[4].text = "T��������";
                textArray[5].text = "����";
                textArray[6].text = "B����i�� ����� ��� ������";

                break;
            case 2:
                textArray[0].text = "����";
                textArray[1].text = "������������� ����";
                textArray[2].text = "���� ������";
                textArray[3].text = "����� O��������";
                textArray[4].text = "B���� ��������";
                textArray[5].text = "����";
                textArray[6].text = "�������� ����� ��� �� ������";
                break;
        }
    }
}
