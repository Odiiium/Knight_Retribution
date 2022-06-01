using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    internal int particleIdentifier;
    private Enemy enemy;
    private Player player;

    private float lifetime;
    void Start()
    {
        lifetime = 0;
        enemy = FindObjectOfType<Enemy>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        try 
        {
            if (particleIdentifier == 0)
            {
                transform.position = enemy.transform.position;
            }
            if( particleIdentifier == 1)
            {
                transform.position = player.transform.position;
            }
            if (lifetime > 3.3f)
            {
                try
                {
                    Destroy(gameObject);
                }
                catch
                {
                    Destroy(gameObject);
                }
            }
        }
        catch
        {
            Destroy(gameObject);
        }
    }
}
