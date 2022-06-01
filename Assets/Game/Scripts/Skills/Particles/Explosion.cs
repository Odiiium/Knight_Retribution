using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ParticleDestroy());
    }

    IEnumerator ParticleDestroy()
    {
        yield return new WaitForSeconds(.58f);
        Destroy(this.gameObject);
    }
}
