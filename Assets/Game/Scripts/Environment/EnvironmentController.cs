using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    private void Update()
    {   if (GameController.isGame)
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 2.5f;

            if (transform.position.x < -30)
            {
                Destroy(gameObject);
                SpawnManager.environmentCount -= 1;
            }
        }
    }
}
