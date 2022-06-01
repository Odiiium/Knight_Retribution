using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private int turnModifier;
    protected Animator animator;
    private Dictionary<string, int> animalValues = new Dictionary<string, int>() // Dictionary with animal name and count of animations minus one
    {
        { "Cat",         6},
        { "Cobra",       1},
        { "Fox",         2},
        { "Hedgehog",    3},
        { "Squirell",    3},
    };

    private void Start()
    {
        turnModifier = Random.Range(1, 3);
        transform.Rotate(0, 180 * turnModifier, 0);
        animator = GetComponent<Animator>();
        StartCoroutine(SetAnimation());
    }

    private IEnumerator SetAnimation()
    {
        var animalValue = animalValues.GetValueOrDefault(gameObject.name.Replace("(Clone)", ""));
        var randomAnim = Random.Range(0, animalValue) + 1;
        animator.SetTrigger("condition" + randomAnim);
        yield return new WaitForSeconds(5);
        StartCoroutine(SetAnimation());
    }

    private void Update()
    {
        if (GameController.isGame)
        {
            if (turnModifier == 2)
            {
                transform.position -= Vector3.right * Time.deltaTime * 2;
            }
            else
            {
                transform.position -= Vector3.right * Time.deltaTime;
            }
        }
        if (transform.position.x < -13)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlackHole"))
        {
            StopAllCoroutines();
            Destroy(this.gameObject);
        }
    }
}
