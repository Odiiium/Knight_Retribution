using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{ 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.isGame)
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * .7f;
        }
    }
}
