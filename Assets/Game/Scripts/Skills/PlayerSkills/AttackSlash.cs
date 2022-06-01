using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlash : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(1, 0, 0);

        if (transform.position.x > 30)
        {
            Destroy(gameObject);
        }
    }
}
