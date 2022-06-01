using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private Rigidbody2D moneyRb;
    [SerializeField] private GameObject player;
    

    private void Start()
    {
        moneyRb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        moneyRb.AddForce(player.transform.position/3, ForceMode2D.Force);

        if (transform.position.x > 16)
        {
            transform.position = new Vector3(15.9f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -12)
        {
            transform.position = new Vector3(-11.9f, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 7)
        {
            transform.position = new Vector3(transform.position.x, 6.9f, transform.position.z);
        }
        if (transform.position.y < -2.6f)
        {
            transform.position = new Vector3(transform.position.x, -2, transform.position.z);
        }
    }
}
