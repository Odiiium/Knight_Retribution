using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFireball : MonoBehaviour
{
    [SerializeField] FireParticle fireParticlePrefab;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce((FindObjectOfType<Player>().transform.position - transform.position) * 3, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = FindObjectOfType<Player>();
        Enemy fireWorm = FindObjectOfType<Enemy>();
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(Resources.Load<Explosion>("Particles/Explosion"), this.transform.position, this.transform.rotation);
            player.currentHealth -= fireWorm.Damage;
            StartCoroutine(BurningDamage());
            StartCoroutine(Destroying());
        }
        if (collision.gameObject.CompareTag("FireBall"))
        {
            Instantiate(Resources.Load<Explosion>("Particles/Explosion"), this.transform.position, this.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BlackHole"))
        {
            Destroy(gameObject);
        }
    }
    internal IEnumerator BurningDamage()
    {
        gameObject.transform.localScale = new Vector3(.001f, .001f, .001f);
        Player player = FindObjectOfType<Player>();
        FireWorm fireWorm = FindObjectOfType<FireWorm>();
        var fireParticle = Instantiate(fireParticlePrefab);
        fireParticle.particleIdentifier = 1;
        for (var i = 0; i < 3.0f; i++)
        {
            yield return new WaitForSeconds(1);
            try
            {
                player.currentHealth -= Mathf.Pow(fireWorm.burnDamage, 1.0f + (SpawnManager.waveCount / 80));
            }
            catch
            { }
        }
        Destroy(fireParticle.gameObject);
    }

    internal IEnumerator Destroying()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }
}
