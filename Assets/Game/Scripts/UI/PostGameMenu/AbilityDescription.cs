using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityDescription : MonoBehaviour
{
    [SerializeField] GameObject imageObject;
    [SerializeField] Sprite[] descriptionImages;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] AbilityDescription abilityDescriptionPanel;

    public void FireBallDecsription()
    {
        abilityDescriptionPanel.gameObject.SetActive(true);
        imageObject.gameObject.GetComponent<Image>().sprite = descriptionImages[0];
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                descriptionText.text = "Fireball is a standart ability that can damage an enemies and set them burn for 3 seconds.\nFireball can destroy Fireworm's fireball if you have used this while he was casting their ability.\n This ability has 4 seconds cooldown.";
                break;
            case 1:
                descriptionText.text = "Bo������ ��� - ���������� �������, ��� �������� ����� ������� �� ������ ������� ������ �� 3 �������.\nB������� ��� ����� ������� ���������� ����� ��������� �������, ���� ��� ����� ���� �����.\n�� ����������� � 4 �������.";
                break;
            case 2:
                descriptionText.text = "O������� ��� - ����������� �����������, ������� ������� ���� � ��������� ������ �� 3 �������. O������� ��� ����� �������� ��������� ����������� ��������� �����, ����� ��� ���������� ���� �����.\n����������� ����� ����������� � 4 �������.";
                break;
        }
    }
    public void LightningBoltDecsription()
    {
        abilityDescriptionPanel.gameObject.SetActive(true);
        imageObject.gameObject.GetComponent<Image>().sprite = descriptionImages[1];
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                descriptionText.text = "Lightning Bolt is a standart ability that provides you an ability to stun enemies and dealt them some damage. Very useful versus range and magical enemies.\nThis ability has 4 seconds cooldown.";
                break;
            case 1:
                descriptionText.text = "��������� - ���������� �������, �� �������� ��� ������� ������ �� ������ ���.\nK������ ������� ����� ���� �� ������ � �������� ������.\n�� ����������� � 4 �������";
                break;
            case 2:
                descriptionText.text = "������ - ����������� �����������, ������� ��������� ���� ������� ����� �� ��������� ����� � �������� ��������� ����.\nO���� �������� ����������� ������ ����� � ������ �������� ���.\n�������������� 4 �������.";
                break;
        }
    }
    public void BlackHoleDecsription()
    {
        abilityDescriptionPanel.gameObject.SetActive(true);
        imageObject.gameObject.GetComponent<Image>().sprite = descriptionImages[2];
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                descriptionText.text = "Blackhole is an ultimate ability that provides you power over gravity.\nThis ability attracts enemies and damages them every seconds split while it lasts.\nThis ability has 10 seconds cooldown.";
                break;
            case 1:
                descriptionText.text = "������������ - ������������ �������, ��� �� ��� �������� ��� ����������.\n3������ ������� ������ �� �������� ����� ����� ���� ������� �� ���� ���� ���� ��������� �� ����������. �� ����������� � 10 ������.";
                break;
            case 2:
                descriptionText.text = "������������� - ������������� ����������, ������� ���� ���� �������� ��� �����������.\nC���������� ����������� ������ � ������� �� ���� ������ ���� ������� �� ���� �������, ���� ������������ ����������� �� ����������.\n�������������� 10 ������.";
                break;
        }
    }

    public void HideDescription()
    {
        abilityDescriptionPanel.gameObject.SetActive(false);
    }


}
