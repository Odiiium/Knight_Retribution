using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchMage : Enemy
{
    private readonly int damage = 75;
    internal readonly int lightingBoltDamage = 125;
    internal readonly float stunDuration = 1.5f;
    private readonly int maxHp = 1200;

    [SerializeField] AudioClip lightingboltClip;
    [SerializeField] private AudioClip teleportAudioClip;
    [SerializeField] private AudioClip waterballClip;
    [SerializeField] ArchMageWaterBall waterBall;
    [SerializeField] ArchMageLightingBolt lightingBolt; 
    private bool isCastingWaterBall = false;
    private bool isCastingLightingBolt = false;
    private bool isCastingTeleport = false;
    float timeSinceWaterBall;
    float timeSinceLightingBolt;

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
            timeSinceLightingBolt += Time.deltaTime;
            timeSinceWaterBall += Time.deltaTime;
            transform.position -= Vector3.right * Time.deltaTime;

            if (transform.position.x < -1 & isFalseCondition())
            {
                isCastingTeleport = true;
                StartCoroutine(Teleport());
            }    
            if (timeSinceLightingBolt > 8 & isFalseCondition())
            {
                isCastingLightingBolt = true;
                StartCoroutine(LightingBolt());
            }
            if (timeSinceWaterBall > 3.5f & isFalseCondition())
            {
                isCastingWaterBall = true;
                StartCoroutine(WaterBall());
            }
            if (isDeath)
            {
                PlayerController.isStuned = false;
            }
        }
    }

    private IEnumerator Teleport()
    {
        enemyAnim.SetTrigger("Teleport");
        enemyAudioSource.PlayOneShot(teleportAudioClip);
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(6, -1.6f, 0);
        yield return new WaitForSeconds(1);
        isCastingTeleport = false;
    }
    
    private IEnumerator LightingBolt()
    {
        enemyAnim.SetTrigger("Cast1");
        yield return new WaitForSeconds(.66f);
        enemyAudioSource.PlayOneShot(lightingboltClip);
        Instantiate(lightingBolt, player.transform.position + new Vector3(0, 4.9f, 0), lightingBolt.transform.rotation);
        PlayerController.isStuned = true;
        isCastingLightingBolt = false;
        player.currentHealth -= Mathf.Pow(lightingBoltDamage, 1.0f + (SpawnManager.waveCount / 80));
        timeSinceLightingBolt = 0;
        yield return new WaitForSeconds(1.5f);
        PlayerController.isStuned = false;
    }

    private IEnumerator WaterBall()
    {
        enemyAnim.SetTrigger("Cast2");
        yield return new WaitForSeconds(.66f);
        enemyAudioSource.PlayOneShot(waterballClip);
        Instantiate(waterBall, transform.position + new Vector3(-2.2f, .7f,0), waterBall.transform.rotation);
        isCastingWaterBall = false;
        timeSinceWaterBall = 0;
    }

    private bool isFalseCondition()
    {
        if (!isCastingTeleport & !isCastingLightingBolt & !isCastingWaterBall & !isDeath)
        {
            return true;
        }
        else
        {
            return false;
        } 
            
    }
}
