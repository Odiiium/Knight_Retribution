using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorm : Enemy
{
    private readonly int damage = 45;
    internal readonly int burnDamage = 15;
    private readonly int maxHp = 250;
    [SerializeField] WormFireball fireball;
    private bool isCasting = false;
    private bool isAttack = false;

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
            if (transform.position.x >= 5.5f)
            {
                RunLeft(transform);
            }
            if (transform.position.x < 5.5f & !isCasting)
            {
                transform.position -= new Vector3(1, 0, 0) * Time.deltaTime;
            }
            if (transform.position.x - 2 < player.transform.position.x & !isAttack)
            {
                isAttack = true;
                StartCoroutine(OnWormAttack());
            }
            slider.transform.position = mainCamera.WorldToScreenPoint(transform.position + offset);
            if (timeSinceAttack > 3 & !isDeath)
            {
                isCasting = true;
                StartCoroutine(OnWormCast());
            }
        }
    }

    private IEnumerator OnWormCast()
    {
        timeSinceAttack = 0;
        enemyAnim.SetTrigger("Cast");
        yield return new WaitForSeconds(.6f);
        isCasting = false;
        Instantiate(fireball, transform.position + new Vector3(-2, .43f, 0), fireball.transform.rotation);
    }
    private IEnumerator OnWormAttack()
    {
        enemyAnim.SetTrigger("Attack");
        yield return new WaitForSeconds(.5f);
        isAttack = false;
    }
}
