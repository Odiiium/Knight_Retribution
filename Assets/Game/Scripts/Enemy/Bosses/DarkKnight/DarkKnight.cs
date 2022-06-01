using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkKnight : Enemy
{
    private readonly int damage = 100;
    private readonly int maxHp = 1450;
    private float prayBonus;
    private int currentHp;
    private float timeSinceHeal;
    private float timeSincePray;
    private float timeSinceAirAttack;
    private float airAttack;
    private bool isHeal;
    private bool isPray;
    private bool isAirAttack;
    private bool isAttack;
    private bool currentAttack = true;
    [SerializeField] private ParticleSystem prayParticle;
    [SerializeField] private AudioClip healAudioClip;
    ParticleSystem prayParticleSystem;

    private void Awake()
    {
        Player player = FindObjectOfType<Player>();
        MaxHp = maxHp;
        CurrentHp = MaxHp;
        Damage = damage;
        SetHealth(CurrentHp, MaxHp);
    }


    void Update()
    {
        if (GameController.isGame & !isStuned)
        {
            try
            {
                prayParticleSystem.transform.position = transform.position + new Vector3(.44f, 5.66f, 0);
            }
            catch
            {
              
            }
            timeSinceAttack += Time.deltaTime;
            timeSinceHeal += Time.deltaTime;
            timeSincePray += Time.deltaTime;
            timeSinceAirAttack += Time.deltaTime;
            if (!isAirAttack & !isHeal & !isPray)
            transform.position -= Vector3.right * Time.deltaTime * 2.5f;

            if (transform.position.x - 2.4f < player.transform.position.x & !isAttack & isFalseCondition())
            {
                transform.position -= Vector3.right * Time.deltaTime;
                isAttack = true;
                StartCoroutine(Attack());
            }
            if (CurrentHp < MaxHp*.6f & timeSinceHeal > 12 & !isAttack & isFalseCondition())
            {
                transform.position -= Vector3.right * Time.deltaTime;
                isHeal = true;
                StartCoroutine(Heal());
            }
            if (transform.position.x > -1.5f & timeSincePray > 10 & !isAttack & isFalseCondition())
            {
                transform.position -= Vector3.right * Time.deltaTime;
                isPray = true;
                StartCoroutine(Pray());
            }
            if (transform.position.x < -2 & timeSinceAirAttack > 13 & !isAttack & isFalseCondition())
            {
                transform.position -= Vector3.right * Time.deltaTime;
                isAirAttack = true;
                StartCoroutine(AirAttack());
            }
        }
    }



    IEnumerator Heal()
    {
        enemyAnim.SetTrigger("Heal");
        enemyAudioSource.PlayOneShot(healAudioClip);
        yield return new WaitForSeconds(.66f);
        timeSinceHeal = 0;
        CurrentHp += MaxHp * .25f;
        SetHealth(CurrentHp, MaxHp);
        isHeal = false;
    }
    
    IEnumerator Pray()
    {
        enemyAnim.SetTrigger("Pray");
        prayParticleSystem = Instantiate(prayParticle, transform.position + new Vector3(.44f, 5.66f, 0), prayParticle.transform.rotation);
        yield return new WaitForSeconds(2);
        timeSincePray = 0;
        Damage = Damage * 1.8f;
        isPray = false;
        yield return new WaitForSeconds(5);
        Damage = Damage / 1.8f;
        Destroy(prayParticleSystem);
    }

    IEnumerator Attack()
    {
        if (currentAttack)
        {
            enemyAnim.SetTrigger("Attack1");
        }
        else
        {
            enemyAnim.SetTrigger("Attack2");
        }
        yield return new WaitForSeconds(.9f);
        currentAttack = !currentAttack;
        yield return new WaitForSeconds(1);
        isAttack = false;

    }

    IEnumerator AirAttack()
    {
        enemyRb.AddForce(new Vector2(0, 250));
        enemyAnim.SetTrigger("Jump");
        yield return new WaitForSeconds(.67f);
        enemyAnim.SetTrigger("AirAttack");
        yield return new WaitForSeconds(.67f);
        timeSinceAirAttack = 0;
        PlayerController.isStuned = true;
        player.currentHealth -= Mathf.Round(Damage * 1.2f);
        isAirAttack = false;
        yield return new WaitForSeconds(1.8f);
        PlayerController.isStuned = false;
    }

    private bool isFalseCondition()
    {
        if (!isAirAttack & !isHeal & !isPray)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
