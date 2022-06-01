using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizard : Enemy
{
    private readonly int damage = 30;
    internal readonly int burnDamage = 20;
    private readonly int maxHp = 320;
    [SerializeField] WizardFireball fireball;
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
                transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 1.4f;
            }
            if (transform.position.x - 3 < player.transform.position.x & !isAttack)
            {
                isAttack = true;
                StartCoroutine(OnWizardAttack());
            }
            slider.transform.position = mainCamera.WorldToScreenPoint(transform.position + offset);
            if (timeSinceAttack > 4 & !isDeath)
            {
                isCasting = true;
                StartCoroutine(OnWizardCast());
            }
        }
    }

    private IEnumerator OnWizardCast()
    {
        timeSinceAttack = 0;
        enemyAnim.SetTrigger("Cast");
        yield return new WaitForSeconds(.65f);
        isCasting = false;
        var wizardFireball = Instantiate(fireball, transform.position + new Vector3(.8f, 2.6f, 0), fireball.transform.rotation);
    }
    private IEnumerator OnWizardAttack()
    {
        enemyAnim.SetTrigger("Attack");
        StartCoroutine(BurningDamage());
        yield return new WaitForSeconds(2);
        isAttack = false;
    }

    internal IEnumerator BurningDamage()
    {
        Player player = FindObjectOfType<Player>();
        var fireParticle = Instantiate(fireParticlePrefab);
        fireParticle.particleIdentifier = 1;
        for (var i = 0; i < 3.0f; i++)
        {
            yield return new WaitForSeconds(1);
            player.currentHealth -= Mathf.Pow(burnDamage, 1.0f + (SpawnManager.waveCount / 80));
        }
        Destroy(fireParticle.gameObject);
    }
}
