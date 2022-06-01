using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    private readonly int damage = 50;
    private readonly int maxHp = 300;

    private void Awake()
    {
        Player player = FindObjectOfType<Player>();
        MaxHp = Mathf.Round(Mathf.Pow(maxHp, 1 + (SpawnManager.waveCount / 100)));
        CurrentHp = MaxHp;
        Damage = Mathf.Round(Mathf.Pow(damage, 1 + (SpawnManager.waveCount / 100)));
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

