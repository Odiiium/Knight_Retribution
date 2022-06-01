using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] GameObject[] backgroundArray;

    private void Start()
    {
        StartCoroutine(SwitchBackground());
    }


    private IEnumerator SwitchBackground()
    {
        for (int i = Random.Range(0,backgroundArray.Length - 1); i < backgroundArray.Length; i++)
        {
            backgroundArray[i].SetActive(true);
            if (i != 0)
            {
                backgroundArray[0].SetActive(false);
            }
            var animator = backgroundArray[i].GetComponent<Animator>();
            yield return new WaitForSeconds(20);

            if (i < backgroundArray.Length - 1)
            {
                backgroundArray[i + 1].SetActive(true);
                animator.SetTrigger("closeBackground");

                yield return new WaitForSeconds(1.7f);
                animator.WriteDefaultValues();
                backgroundArray[i].SetActive(false);
            }
            if ( i == backgroundArray.Length - 1)
            {
                backgroundArray[0].SetActive(true);
                backgroundArray[backgroundArray.Length - 1].SetActive(false);
                StartCoroutine(SwitchBackground());
            }
        }
    }
}

