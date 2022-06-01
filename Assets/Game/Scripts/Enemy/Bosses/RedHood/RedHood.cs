using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RedHood : Enemy
{
    private readonly int damage = 100;
    private readonly int maxHp = 850;
    private int attackCount = 0;
    private float timeSinceTeleport;
    private float timeSinceShoot;
    private bool isAttack = false;
    private bool isCriticalAttack = false;
    private bool isShoot = false;
    private bool isTeleport = false;

    [SerializeField] Arrow arrow;
    [SerializeField] AudioClip attackAudioClip;
    [SerializeField] AudioClip teleportAudioClip;
    [SerializeField] private TextMeshProUGUI critText;



    private void Awake()
    {
        MaxHp = maxHp;
        CurrentHp = MaxHp;
        Damage = damage;
        SetHealth(CurrentHp, MaxHp);
    }

    void Update()
    {
        if (GameController.isGame)
        {
            timeSinceAttack += Time.deltaTime;
            timeSinceShoot += Time.deltaTime;
            timeSinceTeleport += Time.deltaTime;
            if (critText.gameObject.activeSelf)
            {
                critText.transform.position = mainCamera.WorldToScreenPoint(transform.position + new Vector3(0, .5f, 0));
            }
            if (transform.position.x > 5)
            {
                RunLeft(transform);
            }
            if (transform.position.x <= 5 & !isTeleport)
            {
                RunLeft(transform);
            }
            if (transform.position.x > 0 & isFalseCondition() & timeSinceShoot > 3 & !isDeath)
            {
                isShoot = true;
                StartCoroutine(Shoot());
                transform.position -= new Vector3(1, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x < -3 & isFalseCondition() & attackCount == 2)
            {
                StartCoroutine(CriticalAttack());
                isCriticalAttack = true;
            }
            if (transform.position.x < -3 & isFalseCondition() & (attackCount == 0 | attackCount == 1))
            {
                StartCoroutine(Attack());
                isAttack = true;
            }
            if (transform.position.x < -2 & isFalseCondition() & timeSinceTeleport > 2)
            {
                StartCoroutine(Teleport());
                isTeleport = true;
            }
        }
    }

    private IEnumerator Shoot()
    {
        enemyAnim.SetTrigger("Shoot");
        yield return new WaitForSeconds(.75f);
        enemyAudioSource.PlayOneShot(attackAudioClip);
        Instantiate(arrow, transform.position + new Vector3(-2, -1 ,0), arrow.transform.rotation);
        isShoot = false;
        timeSinceShoot = 0;
    }

    private IEnumerator CriticalAttack()
    {
        enemyAnim.SetTrigger("CriticalAttack");
        yield return new WaitForSeconds(1);
        critText.transform.position = mainCamera.WorldToScreenPoint(transform.position + new Vector3(0, .5f, 0));
        critText.gameObject.SetActive(true);
        player.currentHealth -= Damage * 2;
        isCriticalAttack = false;
        attackCount = 0;
        yield return new WaitForSeconds(1);
        critText.gameObject.SetActive(false);
    }

    private IEnumerator Attack()
    {
        enemyAnim.SetTrigger("Attack");
        yield return new WaitForSeconds(2);
        attackCount++;
        isAttack = false;
        

    }

    private IEnumerator Teleport()
    {
        enemyAnim.SetTrigger("Teleport");
        enemyAudioSource.PlayOneShot(teleportAudioClip);
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(7.7f, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(1);
        StartCoroutine(Shoot());
        isTeleport = false;
        timeSinceTeleport = 0;
    }

    private bool isFalseCondition()
    {
        if (!isAttack & !isCriticalAttack & !isTeleport & !isShoot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
