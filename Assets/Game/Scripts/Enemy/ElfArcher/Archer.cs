using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{
    private readonly int damage = 35;
    private readonly int maxHp = 320;

    private bool isAttack = false;

    [SerializeField] AudioClip attackAudioClip;
    [SerializeField] Arrow arrow;


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
            if (transform.position.x > 5)
            {
                RunLeft(transform);
            }
            if (transform.position.x < 5 & !isAttack)
            {
                transform.position -= new Vector3(1, 0, 0) * Time.deltaTime;
            }
            slider.transform.position = mainCamera.WorldToScreenPoint(transform.position + offset);
            if (timeSinceAttack > 2.4f & !isDeath)
            {
                isAttack = true;
                StartCoroutine(OnArcherAttack());
            }
        }
    }

    private IEnumerator OnArcherAttack()
    {
        timeSinceAttack = 0;
        enemyAnim.SetTrigger("Attack");
        yield return new WaitForSeconds(.4f);
        enemyAudioSource.PlayOneShot(attackAudioClip);
        isAttack = false;
        Instantiate(arrow, transform.position + new Vector3(-1.5f, .3f, 0), arrow.transform.rotation);
    }    
}
