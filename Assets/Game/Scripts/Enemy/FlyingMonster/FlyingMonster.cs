using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class FlyingMonster : Enemy
{
    private int damage = 35;
    private int maxHp = 420;

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
                OnAttack(timeSinceAttack);
            }
        }
    }
}

