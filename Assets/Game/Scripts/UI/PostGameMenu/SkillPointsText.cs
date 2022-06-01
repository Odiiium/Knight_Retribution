using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkillPointsText : MonoBehaviour
{
    internal TextMeshProUGUI skillPointsText;

    private void Start()
    {
        skillPointsText = GetComponent<TextMeshProUGUI>();
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                skillPointsText.text = PlayerPrefs.GetInt("skillPoints") + " Skill Points";
                break;
            case 1:
                skillPointsText.text = PlayerPrefs.GetInt("skillPoints") + " Балів Навичок";
                break;
            case 2:
                skillPointsText.text = PlayerPrefs.GetInt("skillPoints") + " Oчков Умений";
                break;
        }
    }
}
