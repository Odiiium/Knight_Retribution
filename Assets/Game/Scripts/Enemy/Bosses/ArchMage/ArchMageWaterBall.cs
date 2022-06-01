using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchMageWaterBall : MonoBehaviour
{
    private readonly float speed = 20.0f;
    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(Resources.Load<Explosion>("Particles/Explosion"), transform.position, transform.rotation);
            FindObjectOfType<Player>().currentHealth -= FindObjectOfType<ArchMage>().Damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BlackHole"))
        {
            Destroy(gameObject);
        }
    }
}
