using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce((FindObjectOfType<Player>().transform.position - transform.position)*2.7f, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = FindObjectOfType<Player>();
        Enemy archer = FindObjectOfType<Enemy>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.currentHealth -= archer.Damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BlackHole"))
        {
            Destroy(gameObject);
        }
    }
}
