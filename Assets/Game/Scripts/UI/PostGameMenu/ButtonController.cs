using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI skillPoints;
    [SerializeField] GameObject chooseWavePanel;
    [SerializeField] GameObject mainPanel;

    public static int MoneyToBuy(string name)
    {
        int price = 0;

        switch (name)
        {
            case "StrengthPrice":
                price = Mathf.RoundToInt(Mathf.Pow(PlayerPrefs.GetInt("strengthCount") + 1, 2));
                break;
            case "AgilityPrice":
                price = Mathf.RoundToInt(Mathf.Pow(PlayerPrefs.GetInt("agilityCount") + 1, 2));
                break;
            case "IntelligencePrice":
                price = Mathf.RoundToInt(Mathf.Pow(PlayerPrefs.GetInt("intelligenceCount") + 1, 2));
                break;
            case "HPPrice":
                price = Mathf.RoundToInt(Mathf.Pow(PlayerPrefs.GetFloat("maxHealth") / 50, 1.55f));
                break;
            case "DamagePrice":
                price = Mathf.RoundToInt(Mathf.Pow(PlayerPrefs.GetFloat("damage") / 20, 1.55f));
                break;
            case "HPPotionPrice":
                price = Mathf.RoundToInt(Mathf.Pow((PlayerPrefs.GetInt("healthPotionsCount") + 1) * 2.5f, 1.55f));
                break;
            case "MPPotionPrice":
                price = Mathf.RoundToInt(Mathf.Pow((PlayerPrefs.GetInt("manaPotionsCount") + 1) * 2.5f, 1.55f));
                break;
        }
        return price;
    }
    public void AddStrength()
    {
        if (PlayerPrefs.GetInt("money") >= MoneyToBuy("StrengthPrice") & PlayerPrefs.GetInt("strengthCount") < 50)
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - MoneyToBuy("StrengthPrice"));
            PlayerPrefs.SetInt("strengthCount", PlayerPrefs.GetInt("strengthCount") + 1);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("StrengthPrice").GetComponent<TextMeshProUGUI>().text = "" + MoneyToBuy("StrengthPrice");
            GameObject.FindGameObjectWithTag("strengthCount").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("strengthCount");
        }
    }

    public void AddAgility()
    {
        if (PlayerPrefs.GetInt("money") >= MoneyToBuy("AgilityPrice") & PlayerPrefs.GetInt("agilityCount") < 50)
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - MoneyToBuy("AgilityPrice"));
            PlayerPrefs.SetInt("agilityCount", PlayerPrefs.GetInt("agilityCount") + 1);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("AgilityPrice").GetComponent<TextMeshProUGUI>().text = "" + MoneyToBuy("AgilityPrice");
            GameObject.FindGameObjectWithTag("agilityCount").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("agilityCount");
        }
    }

    public void AddIntelligence()
    {
        if (PlayerPrefs.GetInt("money") >= MoneyToBuy("IntelligencePrice") & PlayerPrefs.GetInt("intelligenceCount") < 50)
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - MoneyToBuy("IntelligencePrice"));
            PlayerPrefs.SetInt("intelligenceCount", PlayerPrefs.GetInt("intelligenceCount") + 1);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("IntelligencePrice").GetComponent<TextMeshProUGUI>().text = "" + MoneyToBuy("IntelligencePrice");
            GameObject.FindGameObjectWithTag("intelligenceCount").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("intelligenceCount");
        }
    }

    public void AddHP()
    {
        if (PlayerPrefs.GetInt("money") >= MoneyToBuy("HPPrice"))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - MoneyToBuy("HPPrice"));
            PlayerPrefs.SetFloat("maxHealth", PlayerPrefs.GetFloat("maxHealth") + 50);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("HPPrice").GetComponent<TextMeshProUGUI>().text = "" + MoneyToBuy("HPPrice");
            GameObject.FindGameObjectWithTag("maxHealth").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetFloat("maxHealth");
        }
    }

    public void AddDamage()
    {
        if (PlayerPrefs.GetInt("money") >= MoneyToBuy("DamagePrice"))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - MoneyToBuy("DamagePrice"));
            PlayerPrefs.SetFloat("damage", PlayerPrefs.GetFloat("damage") + 20);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("DamagePrice").GetComponent<TextMeshProUGUI>().text = "" + MoneyToBuy("DamagePrice");
            GameObject.FindGameObjectWithTag("damage").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetFloat("damage");
        }
    }

    public void AddHPPotion()
    {
        if (PlayerPrefs.GetInt("money") >= MoneyToBuy("HPPotionPrice"))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - MoneyToBuy("HPPotionPrice"));
            PlayerPrefs.SetInt("healthPotionsCount", PlayerPrefs.GetInt("healthPotionsCount") + 1);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("HPPotionPrice").GetComponent<TextMeshProUGUI>().text = "" + MoneyToBuy("HPPotionPrice");
            GameObject.FindGameObjectWithTag("healthPotionsCount").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("healthPotionsCount");
        }
    }

    public void AddMPPotion()
    {
        if (PlayerPrefs.GetInt("money") >= MoneyToBuy("MPPotionPrice"))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - MoneyToBuy("MPPotionPrice"));
            PlayerPrefs.SetInt("manaPotionsCount", PlayerPrefs.GetInt("manaPotionsCount") + 1);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("MPPotionPrice").GetComponent<TextMeshProUGUI>().text = "" + MoneyToBuy("MPPotionPrice");
            GameObject.FindGameObjectWithTag("manaPotionsCount").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("manaPotionsCount");
        }
    }

    public void AddFireDamage()
    {
        if (PlayerPrefs.GetInt("skillPoints") > 0 & PlayerPrefs.GetInt("fireBallDamage") < 1350)
        {
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.SetInt("fireBallDamage", PlayerPrefs.GetInt("fireBallDamage") + 50);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("fireBallDamage").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("fireBallDamage");
            skillPoints.text = "" + PlayerPrefs.GetInt("skillPoints");
        }
    }
    public void AddBurnDamage()
    {
        if (PlayerPrefs.GetInt("skillPoints") > 0 & PlayerPrefs.GetInt("fireBallBurnDamage") < 520)
        {
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.SetInt("fireBallBurnDamage", PlayerPrefs.GetInt("fireBallBurnDamage") + 20);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("fireBallBurnDamage").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("fireBallBurnDamage");
            skillPoints.text = "" + PlayerPrefs.GetInt("skillPoints");
        }
    }
    public void AddLightingDamage()
    {
        if (PlayerPrefs.GetInt("skillPoints") > 0 & PlayerPrefs.GetInt("lightingBoltDamage") < 2160)
        {
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.SetInt("lightingBoltDamage", PlayerPrefs.GetInt("lightingBoltDamage") + 80);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("lightingBoltDamage").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("lightingBoltDamage");
            skillPoints.text = "" + PlayerPrefs.GetInt("skillPoints");
        }
    }
    public void AddStunDuration()
    {
        if (PlayerPrefs.GetInt("skillPoints") > 0 & PlayerPrefs.GetFloat("lightingBoltStunDuration") < 3.95f)
        {
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.SetFloat("lightingBoltStunDuration", PlayerPrefs.GetFloat("lightingBoltStunDuration") + .1f);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("lightingBoltStunDuration").GetComponent<TextMeshProUGUI>().text = "" + MathF.Round(PlayerPrefs.GetFloat("lightingBoltStunDuration"), 2);
            skillPoints.text = "" + PlayerPrefs.GetInt("skillPoints");
        }
    }
    public void AddBlackHoleDuration()
    {
        if (PlayerPrefs.GetInt("skillPoints") > 0 & PlayerPrefs.GetFloat("blackHoleDuration") < 5.9f)
        {
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.SetFloat("blackHoleDuration", PlayerPrefs.GetFloat("blackHoleDuration") + .2f);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("blackHoleDuration").GetComponent<TextMeshProUGUI>().text = "" + MathF.Round(PlayerPrefs.GetFloat("blackHoleDuration"), 2);
            skillPoints.text = "" + PlayerPrefs.GetInt("skillPoints");
        }
    }
    public void AddBlackHoleDamage()
    {
        if (PlayerPrefs.GetInt("skillPoints") > 0 & PlayerPrefs.GetInt("blackHoleDamage") < 594)
        {
            PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") - 1);
            PlayerPrefs.SetInt("blackHoleDamage", PlayerPrefs.GetInt("blackHoleDamage") + 22);
            PlayerPrefs.Save();
            GameObject.FindGameObjectWithTag("blackHoleDamage").GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("blackHoleDamage");
            skillPoints.text = "" + PlayerPrefs.GetInt("skillPoints");

        }
    }
    public void PlayGame()
    {
        mainPanel.gameObject.SetActive(false);
        chooseWavePanel.gameObject.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }


    private void SetSkillPointsText()
    {
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                skillPoints.text = PlayerPrefs.GetInt("skillPoints") + " Skill Points";
                break;
            case 1:
                skillPoints.text = PlayerPrefs.GetInt("skillPoints") + " Балів Навичок";
                break;
            case 2:
                skillPoints.text = PlayerPrefs.GetInt("skillPoints") + " Oчков Умений";
                break;
        }

    }
}
