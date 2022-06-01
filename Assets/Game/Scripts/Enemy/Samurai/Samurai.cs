using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : Enemy
{
    private readonly int damage = 65;
    private readonly int maxHp = 300;
    private bool isAttack = false;
    private bool firstAttack = true;

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
            textHp.text = "" + CurrentHp;
            RunLeft(transform);
            slider.transform.position = mainCamera.WorldToScreenPoint(transform.position + offset);
            if (transform.position.x - 2.4f < player.transform.position.x & !isAttack)
            {
                isAttack = true;
                StartCoroutine(OnSamuraiAttack());
            }
        }
    }
    private IEnumerator OnSamuraiAttack()
    {
        if (firstAttack)
        {
            enemyAnim.SetTrigger("Attack1");
        }
        else
        {
            enemyAnim.SetTrigger("Attack2");
        }
        firstAttack = !firstAttack;
        yield return new WaitForSeconds(.4f);
        isAttack = false;
    }
}
