using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringer : Enemy
{
    private readonly int damage = 50;
    private readonly int maxHp = 250;
    private float timeSinceCast = 0;
    private bool isCasting = false;
    private bool isAttacking = false;
    [SerializeField] DeathBringerAbility deathBringerAbility;

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
        if (GameController.isGame)
        {
            timeSinceAttack += Time.deltaTime;
            timeSinceCast += Time.deltaTime;
            textHp.text = "" + CurrentHp;
            slider.transform.position = mainCamera.WorldToScreenPoint(transform.position + offset);
            if (!isCasting)
            {
                RunLeft(transform);
            }
            else
            {
                transform.position -= Vector3.right * Time.deltaTime * 1.25f;
            }
            if (transform.position.x - 3 < player.transform.position.x & !isAttacking)
            {
                isAttacking = true;
                StartCoroutine(OnAttack());
            }
            if (timeSinceCast > 4 & CurrentHp < MaxHp / 2 & !isDeath)
            {
                OnCast();
            }
        }
    }

    private void OnCast()
    {
        isCasting = true;
        enemyAnim.SetTrigger("Cast");
        StartCoroutine(WaitForCast());
        timeSinceCast = 0;
    }
    private IEnumerator OnAttack()
    {
        enemyAnim.SetTrigger("Attack");
        yield return new WaitForSeconds(1);
        isAttacking = false;
    }

    private IEnumerator WaitForCast()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(deathBringerAbility, transform.position + new Vector3(0, 3f, 0), deathBringerAbility.transform.rotation);
        isCasting = false;
    }
}
