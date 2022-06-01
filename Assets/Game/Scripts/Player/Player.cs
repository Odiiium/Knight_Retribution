using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class Player : MonoBehaviour
{
    internal Rigidbody2D rigidBody;
    internal Animator animator;
    internal GameObject moneyObject;
    internal GameObject experienceObject;

    internal float maxHealth = 300;
    internal float currentHealth;
    internal float knockbackPower = 5.0f;
    internal float blockModifier = 1.5f;
    internal float maxMana = 100;
    internal float currentMana;
    internal float manaRegeneration;
    internal float hpRegeneration;

    internal int playerLvl;
    internal int expiriencePoints;
    internal int skillPoints;

    internal float damage = 40;
    internal int money;

    internal int fireBallDamage = 90;
    internal int fireBallBurnDamage = 10;

    internal int lightingBoltDamage = 75;
    internal float lightingBoltStunDuration = 1.5f;

    internal float blackHoleDamage;
    internal float blackHoleDuration;

    internal int strengthCount = 0;
    internal int agilityCount = 0;
    internal int intelligenceCount = 0;

    internal int healthPotionsCount = 0;
    internal int manaPotionsCount = 0;




    private void Start()
    {
        var playerUI = FindObjectOfType<PlayerUI>();

        moneyObject = GameObject.Find("MoneyObject");
        StartCoroutine(SetActiveForObject(moneyObject));
        experienceObject = GameObject.Find("ExperienceSliderObject");
        StartCoroutine(SetActiveForObject(experienceObject));

        PrefsInitialize();
        currentHealth = maxHealth;
        currentMana = maxMana;
        playerUI.manaBar.maxValue = maxMana;
        playerUI.manaBar.value = maxMana;
        rigidBody = GetComponent<Rigidbody2D>();
        switch (gameObject.name.Replace("(Clone)", ""))
        {
            case "Player1":
                animator = GetComponent<Animator>();
                break;
            default:
                animator = GetComponentInChildren<Animator>();
                break;
        }
    }
    // Load Player statistics 
    public void PrefsInitialize()
    {
        strengthCount = PlayerPrefs.GetInt("strengthCount");
        agilityCount = PlayerPrefs.GetInt("agilityCount");
        intelligenceCount = PlayerPrefs.GetInt("intelligenceCount");

        money = PlayerPrefs.GetInt("money");
        PlayerPrefs.SetFloat("maxMana", 100);
        PlayerPrefs.SetFloat("blockModifier", 1.5f);
        PlayerPrefs.SetFloat("manaRegeneration", 1.0f);
        PlayerPrefs.SetFloat("hpRegeneration", 1.0f);
        maxHealth = Mathf.Round(PlayerPrefs.GetFloat("maxHealth") * (1.0f + 4* Convert.ToSingle(strengthCount) / 50));                       // MaxHealth multiplies x5 if Strength count is maximum ( 50 )
        maxMana = Mathf.Round(PlayerPrefs.GetFloat("maxMana") * (1.0f + (4 * Convert.ToSingle(intelligenceCount) / 50)));                   // MaxMana multiplies x5 if Intelligence count is maximum ( 50 )
        manaRegeneration = Mathf.Round(PlayerPrefs.GetFloat("manaRegeneration") * (1.0f + 3.5f * Convert.ToSingle(intelligenceCount) / 50) * maxMana/100); // ManaRegen multiplies x3.5 if Intelligence count is maximum ( 50 ). Restore 4.5% mana per second at maximum Intelligence
        hpRegeneration = Mathf.Round(PlayerPrefs.GetFloat("hpRegeneration") * (1.0f + 2.5f * Convert.ToSingle(strengthCount) / 50) * maxHealth/100); // HpRegen multiplies x3.5 if Intelligence count is maximum ( 50 ). Restore 3.5% HP per second at maximum Strength

        damage = Mathf.Round(PlayerPrefs.GetFloat("damage") * (1.0f + 2 * Convert.ToSingle(agilityCount) / 50));                         // Damage multiplies x3 if Agility count is maximum ( 50 )
        blockModifier = Mathf.Round(PlayerPrefs.GetFloat("blockModifier") * (1.0f + 2 * Convert.ToSingle(agilityCount) / 50));            // Block multiplies x3 if Agility count is maximum ( 50 )

        playerLvl = PlayerPrefs.GetInt("playerLvl");
        expiriencePoints = PlayerPrefs.GetInt("expiriencePoints");
        skillPoints = PlayerPrefs.GetInt("skillPoints");

        fireBallDamage = PlayerPrefs.GetInt("fireBallDamage");
        fireBallBurnDamage = PlayerPrefs.GetInt("fireBallBurnDamage");

        lightingBoltStunDuration = PlayerPrefs.GetFloat("lightingBoltStunDuration");
        lightingBoltDamage = PlayerPrefs.GetInt("lightingBoltDamage");

        blackHoleDamage = PlayerPrefs.GetInt("blackHoleDamage");
        blackHoleDuration = PlayerPrefs.GetFloat("blackHoleDuration");

        healthPotionsCount = PlayerPrefs.GetInt("healthPotionsCount");
        manaPotionsCount = PlayerPrefs.GetInt("manaPotionsCount");

    }

    private IEnumerator SetActiveForObject(GameObject obj)
    {
        yield return new WaitForSeconds(.1f);
        obj.gameObject.SetActive(false);
    }
}
