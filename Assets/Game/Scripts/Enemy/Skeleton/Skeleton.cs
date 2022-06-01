using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{

    private readonly int damage = 25;
    private readonly int maxHp = 350;
    private int currentHp;

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

            if (transform.position.x - 2.4f < player.transform.position.x)
            {
                if (timeSinceAttack > 1)
                {
                    var randomStatement = Random.Range(0, 2);
                    if (randomStatement != 0)
                    {
                        OnAttack(timeSinceAttack);
                    }
                    else
                    {
                        OnGuard();
                    }
                    timeSinceAttack = 0;
                }
            }
        }
    }
    internal void OnGuard()
    {
        isBlock = true;
        StartCoroutine(OnSkeletonBlock());
    }

    internal IEnumerator OnSkeletonBlock()
    {
        enemyAnim.SetTrigger("Block");
        yield return new WaitForSeconds(2.0f);
        isBlock = false;
        StopAllCoroutines();
    }
}

