using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] internal GameObject fireball;

    private readonly float speed = 20.0f;
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
