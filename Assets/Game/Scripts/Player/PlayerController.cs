using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    internal static int startMoney;

    private Player player;
    PlayerUI playerUI;
    static internal float timeSinceAttack = 0.25f;
    protected float jumpForce = 7.5f;
    private bool isGrounded = false;
    static internal int currentAttack = 0;
    public static bool isBlock = false;
    internal static bool isStuned;
    internal static bool isDead = false;

    [SerializeField] private AttackSlash slashAttack;
    [SerializeField] internal AudioSource audioSource;
    [SerializeField] private AudioClip moneySound;
    private ParticleSystem lvlUpParticle;

    private readonly float timeDelay = 1.0f;
    private float timeDelayHp;
    private float timeDelayMp;

    private Enemy enemy;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        isStuned = false;
        isDead = false;
        playerUI = FindObjectOfType<PlayerUI>();
        startMoney = PlayerPrefs.GetInt("money");
    }

    private void LateUpdate()
    {
        if (GameController.isGame)
        {
            //Hp regeneration
            if (player.currentHealth < player.maxHealth)
            {
                PlayerHpRegen();
            }
            //Mana regeneration
            if (player.currentMana < player.maxMana)
            {
                PlayerMpRegen();
            }
            timeSinceAttack += Time.deltaTime;
            PlayerDeath();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Getting a coin
        if (collision.gameObject.CompareTag("Coin"))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + SpawnManager.waveCount);
            PlayerPrefs.Save();
            audioSource.PlayOneShot(moneySound, 0.85f * Sound.effectsVolume);
            StartCoroutine(OnGetMoney());
            Destroy(collision.gameObject);
        }
        //Getting Experience
        if (collision.gameObject.CompareTag("Experience"))
        {
            PlayerPrefs.SetInt("expiriencePoints", PlayerPrefs.GetInt("expiriencePoints") + UnityEngine.Random.Range(0, 10));
            if (PlayerPrefs.GetInt("playerLvl") == 0 & PlayerPrefs.GetInt("expiriencePoints") < 51)
            {
                playerUI.experienceSlider.maxValue = 51;
                playerUI.experienceSlider.value = Convert.ToSingle(PlayerPrefs.GetInt("expiriencePoints"));
            }
            else
            {
                playerUI.experienceSlider.maxValue = (Mathf.Pow(Convert.ToSingle((PlayerPrefs.GetInt("playerLvl") + 1)), 2.35f) + 50) - (Mathf.Pow(Convert.ToSingle(PlayerPrefs.GetInt("playerLvl")), 2.35f) + 50);
                playerUI.experienceSlider.value = Convert.ToSingle(PlayerPrefs.GetInt("expiriencePoints")) - (Mathf.Pow(Convert.ToSingle(PlayerPrefs.GetInt("playerLvl")), 2.35f) + 50);
            }
            StartCoroutine(OnGetExperience());
            Destroy(collision.gameObject);
            if (PlayerPrefs.GetInt("expiriencePoints") > (Mathf.Pow(Convert.ToSingle(PlayerPrefs.GetInt("playerLvl") + 1), 2.35f) + 50))
            {
                PlayerPrefs.SetInt("playerLvl", PlayerPrefs.GetInt("playerLvl") + 1);
                PlayerPrefs.SetInt("skillPoints", PlayerPrefs.GetInt("skillPoints") + 1);
                StartCoroutine(OnLvlUp());
                lvlUpParticle = GameObject.Find("LvlUpParticle").GetComponent<ParticleSystem>();
                lvlUpParticle.Play();
            }
            PlayerPrefs.Save();
        }
        //Hitting an enemy or boss
        if (collision.gameObject.CompareTag("Enemy") | collision.gameObject.CompareTag("Boss"))
        {
            player.animator.SetTrigger("Hurt");
        }
        
    }


    public void PlayerBlock()
    {
        if (!isStuned)
        {
            player.animator.SetTrigger("Block");
            StartCoroutine(OnBlock());
        }
    }

    public void PlayerAttack()
    {
        if (timeSinceAttack > 1.5f & !isStuned)
        {
            currentAttack++;
            if (currentAttack > 3)
            {
                currentAttack = 1;
            }
            if (timeSinceAttack > 6.0f)
            {
                currentAttack = 1;
            }
            player.animator.SetTrigger("Attack" + currentAttack);
            Instantiate(slashAttack, player.transform.position + new Vector3(.5f, 1.3f, 0), slashAttack.transform.rotation);
            timeSinceAttack = 0;
        }
    }
    public void PlayerDeath()
    {
        if (player.currentHealth <= 0)
        {
            player.currentHealth = 0;
            player.animator.SetTrigger("Death");
            player.gameObject.SetActive(false);
            isDead = true;
            GameController.isGame = false;

        }
    }


    // Show's Player's money
    internal IEnumerator OnGetMoney()
    {
        player.moneyObject.SetActive(true);
        yield return new WaitForSeconds(2);
        player.moneyObject.SetActive(false);
    }
    internal IEnumerator OnGetExperience()
    {
        player.experienceObject.SetActive(true);
        yield return new WaitForSeconds(2);
        player.experienceObject.SetActive(false);
    }
    internal IEnumerator OnLvlUp()
    {
        playerUI.lvlUpText.SetActive(true);
        yield return new WaitForSeconds(2);
        playerUI.lvlUpText.SetActive(false);

    }

    internal IEnumerator OnBlock()
    {
        isBlock = true;
        yield return new WaitForSeconds(1);
        isBlock = false;
    }

    private void PlayerHpRegen()
    {
        timeDelayHp += Time.deltaTime;
        if (timeDelayHp > timeDelay)
        {
            player.currentHealth += player.hpRegeneration;
            timeDelayHp = 0;
            if (player.currentHealth >= player.maxHealth)
            {
                player.currentHealth = player.maxHealth;
            }
        }
    }

    private void PlayerMpRegen()
    {
        timeDelayMp += Time.deltaTime;
        if (timeDelayMp > timeDelay)
        {
            player.currentMana += player.manaRegeneration;
            timeDelayMp = 0;
            if (player.currentMana >= player.maxMana)
            {
                player.currentMana = player.maxMana;
            }
        }
    }

}
