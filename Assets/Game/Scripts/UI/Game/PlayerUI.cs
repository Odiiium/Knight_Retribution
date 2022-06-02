using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class PlayerUI : MonoBehaviour
{
    private float timeSinceFirstSpell;
    private float timeSinceSecondSpell;
    private float timeSinceUltimate;

    private Player player;
    private Enemy enemy;

    [SerializeField] internal TextMeshProUGUI healthText;
    [SerializeField] internal TextMeshProUGUI manaText;
    [SerializeField] internal Image currentHealthImage;
    [SerializeField] internal TextMeshProUGUI moneyText;
    [SerializeField] internal GameObject lvlUpText;
    [SerializeField] internal TextMeshProUGUI waveCounter;
    [SerializeField] internal Slider manaBar;
    [SerializeField] internal TextMeshProUGUI manaPotionsCountText;
    [SerializeField] internal TextMeshProUGUI hpPotionsCountText;
    [SerializeField] internal Slider experienceSlider;
    [SerializeField] private Image firstSpellCooldown;
    [SerializeField] private Image secondSpellCooldown;
    [SerializeField] private Image ultimateSpellCooldown;

    //[SerializeField] private EndGameMenu endGameMenu;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        manaBar.maxValue = player.maxMana;
        player.currentMana = player.maxMana;
        manaPotionsCountText.text = "" + PlayerPrefs.GetInt("manaPotionsCount");
        hpPotionsCountText.text = "" + PlayerPrefs.GetInt("healthPotionsCount");
    }

    private void Update()
    {
        timeSinceFirstSpell += Time.deltaTime;
        timeSinceSecondSpell += Time.deltaTime;
        timeSinceUltimate += Time.deltaTime;

        SetCooldown(firstSpellCooldown, timeSinceFirstSpell, .4f);
        SetCooldown(secondSpellCooldown, timeSinceSecondSpell, .2f);
        SetCooldown(ultimateSpellCooldown, timeSinceUltimate, .1f);

        healthText.SetText($"{Mathf.Round(player.currentHealth)}");
        manaText.SetText($"{Mathf.Round(player.currentMana)}");
        currentHealthImage.fillAmount = player.currentHealth / player.maxHealth;
        manaBar.value = player.currentMana;
        moneyText.text = "" + PlayerPrefs.GetInt("money");
    }

    public void LightStrike()
    {
        if (player.currentMana > 35 & !PlayerController.isStuned & timeSinceSecondSpell > 5)
        {
            try
            {
                timeSinceSecondSpell = 0;
                secondSpellCooldown.gameObject.SetActive(true);
                player.currentMana -= 35;
                enemy = FindObjectOfType<Enemy>();
                var lightingBolt =Instantiate(Resources.Load<LightingBolt>("Prefabs/Skills/Player/LightningBolt"), enemy.transform.position + new Vector3(0, 2, 0), Resources.Load<LightingBolt>("Prefabs/Skills/Player/LightningBolt").transform.rotation);
                var lightingParticle =Instantiate(Resources.Load<LightingParticle>("Particles/Electricity"), enemy.transform.position + new Vector3(0, -1.2f, 0), Resources.Load<LightingParticle>("Particles/Electricity").transform.rotation);
                enemy.enemyAnim.SetTrigger("Take_hit");
                enemy.isStuned = true;
                enemy.CurrentHp -= Convert.ToSingle(player.lightingBoltDamage);
                enemy.SetHealth(enemy.CurrentHp, enemy.MaxHp);
                StartCoroutine(LightStrikeDestroy(player.lightingBoltStunDuration, lightingBolt, lightingParticle));
            }
            catch
          {
          }
        }
    }

    public void FireBall()
    {
        if (player.currentMana > 30 & !PlayerController.isStuned & timeSinceFirstSpell > 2.5f)
        {
            timeSinceFirstSpell = 0;
            firstSpellCooldown.gameObject.SetActive(true);
            player.currentMana -= 30;
            Instantiate(Resources.Load<FireBall>("Prefabs/Skills/Player/Fireball"), player.transform.position + new Vector3(.6f, 2.0f, 0), Resources.Load<FireBall>("Prefabs/Skills/Player/Fireball").transform.rotation);

        }
    }

    public void Blackhole()
    {
        if (player.currentMana > 50 & !PlayerController.isStuned & timeSinceUltimate > 10)
        {
            timeSinceUltimate = 0;
            ultimateSpellCooldown.gameObject.SetActive(true);
            timeSinceUltimate = 0;
            player.currentMana -= 50;
            var blackHole = Instantiate(Resources.Load<BlackHole>("Prefabs/Skills/Player/BlackHole"), new Vector3(7, 2, 0), Resources.Load<BlackHole>("Prefabs/Skills/Player/BlackHole").transform.rotation);
            StartCoroutine(BlackHoleLifetime(player.blackHoleDuration, blackHole));
        }
    }

    public void OnHealthPotionDrink()
    {
        if (PlayerPrefs.GetInt("healthPotionsCount") > 0 & !PlayerController.isStuned)
        {
            PlayerPrefs.SetInt("healthPotionsCount", PlayerPrefs.GetInt("healthPotionsCount") - 1);
            if (player.currentHealth < player.maxHealth * 0.7f)
            {
                player.currentHealth += player.maxHealth * 0.3f;
            }
            else
            {
                player.currentHealth = player.maxHealth;
            }
            hpPotionsCountText.text = "" + PlayerPrefs.GetInt("healthPotionsCount");
        }
    }

    public void OnManaPotionDrink()
    {
        if (PlayerPrefs.GetInt("manaPotionsCount") > 0 & !PlayerController.isStuned)
        {
            PlayerPrefs.SetInt("manaPotionsCount", PlayerPrefs.GetInt("manaPotionsCount") - 1);
            if (player.currentMana < player.maxMana * 0.7f)
            {
                player.currentMana += player.maxMana * 0.3f;
            }
            else
            {
                player.currentMana = player.maxMana;
            }
            manaPotionsCountText.text = "" + PlayerPrefs.GetInt("manaPotionsCount");
        }
    }
    // Destroy lighting bolt and turn's enemy stun to false.
    internal IEnumerator LightStrikeDestroy(float stunDuration, LightingBolt lightingBolt, LightingParticle lightingParticle)
    {
        yield return new WaitForSeconds(stunDuration);
        enemy.isStuned = false;
        Destroy(lightingBolt);
        Destroy(lightingParticle);
    }
    internal IEnumerator BlackHoleLifetime(float time, BlackHole blackhole)
    {
        yield return new WaitForSeconds(time);
        Destroy(GameObject.FindGameObjectWithTag("BlackHole"));
    }

    public void PlayerBlock()
    {
        if (!PlayerController.isStuned)
        {
            player.animator.SetTrigger("Block");
            StartCoroutine(OnBlock());
        }
    }

    internal IEnumerator OnBlock()
    {
        PlayerController.isBlock = true;
        yield return new WaitForSeconds(1);
        PlayerController.isBlock = false;
    }

    public void PlayerAttack()
    {
        if (PlayerController.timeSinceAttack > 1.5f & !PlayerController.isStuned)
        {
            PlayerController.currentAttack++;
            if (PlayerController.currentAttack > 3)
            {
                PlayerController.currentAttack = 1;
            }
            if (PlayerController.timeSinceAttack > 6.0f)
            {
                PlayerController.currentAttack = 1;
            }
            player.animator.SetTrigger("Attack" + PlayerController.currentAttack);
            var slashAttack = Resources.Load<AttackSlash>("Prefabs/Skills/Player/AttackSlash");
            Instantiate(slashAttack, player.transform.position + new Vector3(.5f, 1.3f, 0), slashAttack.transform.rotation);
            PlayerController.timeSinceAttack = 0;
        }
    }


    private void SetCooldown(Image spell, float time, float multiplicator)
    {
        if (spell.gameObject.activeSelf)
        {
            spell.fillAmount = 1 - (time * multiplicator);
            if (spell.fillAmount < 0.01)
            {
                spell.gameObject.SetActive(false);
            }
        }
    }
}
