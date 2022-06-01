using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.isGame)
        {
            timer += Time.deltaTime;
            if (timer > 65)
            {
                timer = 0;
                StartCoroutine(WeatherLiveTime());
            }
        }
    }


    IEnumerator WeatherLiveTime()
    {
        yield return new WaitForSeconds(Random.Range(0, 45));
        FindObjectOfType<Rain>().transform.position = transform.position;
        

    }
}
