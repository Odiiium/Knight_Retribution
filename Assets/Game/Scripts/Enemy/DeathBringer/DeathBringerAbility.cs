using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringerAbility : MonoBehaviour
{
    private Rigidbody2D abilityRb;
    private Player player;
    private SpawnManager spawnManager;
    void Start()
    {
        player = FindObjectOfType<Player>();
        abilityRb = GetComponent<Rigidbody2D>();
        abilityRb.AddForce((player.transform.position - transform.position) * 10, ForceMode2D.Impulse);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DeathBringer deathBringer = FindObjectOfType<DeathBringer>();
            player.currentHealth -= deathBringer.Damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BlackHole"))
        {
            Destroy(gameObject);
        }
    }
}
