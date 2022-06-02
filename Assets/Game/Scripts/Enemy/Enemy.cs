using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public abstract class Enemy : MonoBehaviour
{
    internal Player player;
    private readonly int forceOffset = 10;
    protected Rigidbody2D enemyRb;
    internal BoxCollider2D enemyCollider;
    internal Animator enemyAnim;

    internal float MaxHp;
    internal float Damage;
    internal float CurrentHp;
    internal int currentEnemyAttack = 0;
    internal float timeSinceAttack = 0;
    internal bool isStuned = false;
    internal bool isBlock = false;

    private GameMusicController musicController;
    public TextMeshProUGUI textHp;
    public Slider slider;
    protected Vector3 offset;
    internal AudioSource enemyAudioSource;
    [SerializeField] internal FireParticle fireParticlePrefab;

    internal Camera mainCamera;
    internal bool isDeath = false;




    private void Start()
    {
        MaxHp = Mathf.Round(Mathf.Pow(Convert.ToSingle(MaxHp), 1 + (Convert.ToSingle(SpawnManager.waveCount) / 100)));
        Damage = Mathf.Round(Mathf.Pow(Convert.ToSingle(Damage), 1 + (Convert.ToSingle(SpawnManager.waveCount) / 80)));
        CurrentHp = MaxHp;
        SetHealth(CurrentHp, MaxHp);

        enemyCollider = GetComponent<BoxCollider2D>();
        try
        {
            enemyAudioSource = GetComponent<AudioSource>();
        }
        catch { }
        enemyAudioSource.volume = Sound.effectsVolume;
        musicController = FindObjectOfType<GameMusicController>();
        offset = new Vector3(-.15f, enemyCollider.size.y + .7f, 0);
        player = GameObject.FindObjectOfType<Player>();
        enemyRb = GetComponent<Rigidbody2D>();

        switch (gameObject.name.Replace("(Clone)", ""))
        {
            case "Flying monster":
                enemyAnim = GetComponent<Animator>();
                break;
            case "Goblin" :
                enemyAnim = GetComponent<Animator>();
                break;
            case "Mushroom monster":
                enemyAnim = GetComponent<Animator>();
                break;
            case "Skeleton":
                enemyAnim = GetComponent<Animator>();
                break;
            default:
                enemyAnim = GetComponentInChildren<Animator>();
                break;
        }
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        enemyAudioSource.volume = Sound.effectsVolume;
        if (transform.position.x > 16.5f)
        {
            transform.position = new Vector3(16.4f, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 10)
        {
            transform.position = new Vector3(transform.position.x, 9.9f, transform.position.z);
        }
        if (transform.position.x < -6.1f)
        {
            transform.position = new Vector3(-4.5f, -2f, transform.position.z);
        }
    }


    public void RunLeft(Transform enemyTransform)
    {
        if (!isStuned)
        {
            enemyTransform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 2.5f;
        }
    }

    public void SetHealth(float health, float maxHealth)
    {
        
        if (health <= 0)
        {
            slider.value = 0;
            OnDeath();
        }
        else
        {
            slider.gameObject.SetActive(true);
            slider.maxValue = maxHealth;
            slider.value = health;
        } 
            
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnGetCollision();
        }
        if (collision.gameObject.CompareTag("FireBall"))
        {
            Instantiate(Resources.Load<Explosion>("Particles/Explosion"), transform.position, transform.rotation);
            enemyAnim.SetTrigger("Take_hit");
            CurrentHp -= player.fireBallDamage;
            StartCoroutine(BurnDamage());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BlackHole"))
        {
            enemyAnim.SetTrigger("Take_hit");
            CurrentHp -= player.blackHoleDamage;
            SetHealth(CurrentHp, MaxHp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            enemyRb.AddForce(Vector2.right * forceOffset / 3.2f, ForceMode2D.Impulse);
            enemyAnim.SetTrigger("Take_hit");
            CurrentHp -= player.damage;
            SetHealth(CurrentHp, MaxHp);
            Destroy(collision.gameObject);
        }
    }

    public void OnAttack(float TimeSinceAttack)
    {
        currentEnemyAttack++;
        if (currentEnemyAttack > 2)
        {
            currentEnemyAttack = 1;
        }
        if (TimeSinceAttack > 1.0f)
        {
            currentEnemyAttack = 1;
        }
        enemyAnim.SetTrigger("Attack" + currentEnemyAttack);
        TimeSinceAttack = 0;
    }

    public void OnGetCollision()
    {
        if (!PlayerController.isBlock)
        {
            enemyRb.AddForce(Vector2.right * forceOffset, ForceMode2D.Impulse);
            enemyAnim.SetTrigger("Take_hit");
            if (isBlock)
            {
                CurrentHp -= Mathf.Round(player.damage / 3);
                player.currentHealth -= Mathf.Round(Damage /1.5f);
            }
            else
            {
                CurrentHp -= Mathf.Round(player.damage / 2);
                player.currentHealth -= Mathf.Round(Damage / 1.5f);
            }
            SetHealth(CurrentHp, MaxHp);
        }
        else
        {
            enemyRb.AddForce(Vector2.right * forceOffset, ForceMode2D.Impulse);
            enemyAnim.SetTrigger("Take_hit");
            if (isBlock)
            {
                CurrentHp -= Mathf.Round(player.damage / 3.75f);
                player.currentHealth -= Mathf.Round(Damage / player.blockModifier / 1.5f);
            }
            else
            {
                CurrentHp -= Mathf.Round(player.damage / 2.5f);
                player.currentHealth -= Mathf.Round(Damage / player.blockModifier);
            }
            SetHealth(CurrentHp, MaxHp);
        }    
    }


    internal void OnDeath()
    {
        switch (gameObject.name.Replace("(Clone)",""))
        {
            case "DeathBringer":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[0]);
                break;
            case "Goblin":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[2]);
                break;
            case "Skeleton":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[3]);
                break;
            case "DarkWizard":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[4]);
                break;
            case "FireWorm":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[5]);
                break;
            case "Samurai":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[6]);
                break;
            case "ElfArcher":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[7]);
                break;
            case "RedHood":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[7]);
                break;
            case "ArchMage":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[6]);
                break;
            case "DarkKnight":
                enemyAudioSource.PlayOneShot(musicController.hurtClips[8]);
                break;
            default:
                enemyAudioSource.PlayOneShot(musicController.hurtClips[1]);
                break;
        }
        isDeath = true;
        enemyAnim.SetTrigger("Death");
        CurrentHp = 0;
        StartCoroutine(GetDeath());
    }

    internal IEnumerator GetDeath()
    {
        switch(gameObject.name.Replace("(Clone)", ""))
        {
            case "ArchMage":
                yield return new WaitForSeconds(.58f);
            break;
            case "RedHood":
                yield return new WaitForSeconds(1);
                break;
            case "DarkKnight":
                yield return new WaitForSeconds(.66f);
                break;
            case "DarkWizard":
                yield return new WaitForSeconds(.41f);
                break;
            case "DeathBringer":
                yield return new WaitForSeconds(1);
                break;
            case "ElfArcher":
                yield return new WaitForSeconds(.83f);
                break;
            case "FireWorm":
                yield return new WaitForSeconds(.66f);
                break;
            case "Samurai":
                yield return new WaitForSeconds(.66f);
                break;
            default:
                yield return new WaitForSeconds(.33f);
                break;
        }
        Destroy(gameObject);
        SpawnManager.enemyCount = 0;
        SpawnManager.bossCount = 0;
        slider.gameObject.SetActive(false);
        Vector3 randomOffset = new Vector3(UnityEngine.Random.Range(-1.5f, 1.5f), UnityEngine.Random.Range(-1.5f, 1.5f), 0);
        if (gameObject.tag == "Boss")
        {
            for (int i = 0; i < 7; i++)
            {
                Instantiate(Resources.Load("Prefabs/Misc/Coin"), transform.position + randomOffset, transform.rotation);
                Instantiate(Resources.Load("Prefabs/Misc/Experience"), transform.position + randomOffset, transform.rotation);
            }
        }
        else
        {
            Instantiate(Resources.Load("Prefabs/Misc/Coin"), transform.position + randomOffset, transform.rotation);
            Instantiate(Resources.Load("Prefabs/Misc/Experience"), transform.position + randomOffset, transform.rotation);
        }
    }

    internal IEnumerator BurnDamage()
    {
        var fireParticle = Instantiate(Resources.Load<FireParticle>("Particles/FireParticle"), transform.position + new Vector3(0, 0.75f, 0), Resources.Load<FireParticle>("Particles/FireParticle").transform.rotation);
        fireParticle.particleIdentifier = 0;
        fireParticle.GetComponent<ParticleSystem>().Play();
        for (var i = 0; i < 3.0f; i++)
        {
            yield return new WaitForSeconds(1);
            CurrentHp -= player.fireBallBurnDamage;
            SetHealth(CurrentHp, MaxHp);
        }
        Destroy(fireParticle.gameObject);
    }



}
