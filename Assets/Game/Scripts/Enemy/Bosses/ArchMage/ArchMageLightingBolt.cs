using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchMageLightingBolt : MonoBehaviour
{
    
    private void Start()
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }
}
