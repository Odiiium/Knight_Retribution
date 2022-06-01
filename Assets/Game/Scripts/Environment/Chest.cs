using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chest : MonoBehaviour
{
    private Animator chestAnim;
    [SerializeField] private GameObject chestCanvas;
    [SerializeField] private TextMeshProUGUI moneyCountText;
    [SerializeField] private TextMeshProUGUI manaPotionsCountText;
    [SerializeField] private TextMeshProUGUI healthPotionsCountText;
    private int manaPotionsCount;
    private int moneyCount;
    private int healthPotionsCount;


    private void Start()
    {
        GameController.isGame = true;
        chestAnim = GetComponent<Animator>();

        switch (gameObject.name.Replace("(Clone)", "").Trim())    
        {
            case "WoodenChest":
                moneyCount = Random.Range(1, 9) * SpawnManager.waveCount + 5;
                moneyCountText.text = "" + moneyCount;
                healthPotionsCount = 0;
                manaPotionsCount = 0;
                break;
            case "IronChest":
                moneyCount = Random.Range(5, 29) * SpawnManager.waveCount + 15;
                manaPotionsCount = Random.Range(1, 4);
                healthPotionsCount = 0;
                moneyCountText.text = "" + moneyCount;
                manaPotionsCountText.text = "" + manaPotionsCount;
                break;
            case "SilverChest":
                moneyCount = Random.Range(25, 59) * SpawnManager.waveCount + 40;
                healthPotionsCount = Random.Range(1, 6);
                manaPotionsCount = 0;
                moneyCountText.text = "" + moneyCount;
                healthPotionsCountText.text = "" + healthPotionsCount;
                break;
            case "GoldenChest":
                moneyCount = Random.Range(45, 100) * SpawnManager.waveCount + 75;
                healthPotionsCount = Random.Range(3, 9);
                manaPotionsCount = Random.Range(3, 9);
                moneyCountText.text = "" + moneyCount;
                healthPotionsCountText.text = "" + healthPotionsCount;
                manaPotionsCountText.text = "" + manaPotionsCount;
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.isGame = false;
            StartCoroutine(OpenChest());

        }
    }

    private void Update()
    {
        if (GameController.isGame)
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 2.5f;
        }
    }

    public void CloseChest()
    {
        PlayerPrefs.SetInt("healthPotionsCount", PlayerPrefs.GetInt("healthPotionsCount") + healthPotionsCount);
        PlayerPrefs.SetInt("manaPotionsCount", PlayerPrefs.GetInt("manaPotionsCount") + manaPotionsCount);
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + moneyCount);
        var playerUI = FindObjectOfType<PlayerUI>();
        playerUI.hpPotionsCountText.text = "" + PlayerPrefs.GetInt("healthPotionsCount");
        playerUI.manaPotionsCountText.text = "" + PlayerPrefs.GetInt("manaPotionsCount");
        chestCanvas.SetActive(false);
        Destroy(gameObject);
        GameController.isGame = true;
        SpawnManager.chestCount = 0;
        
    }

    internal IEnumerator OpenChest()
    {
        chestAnim.SetTrigger("OpenChest");
        yield return new WaitForSeconds(.5f);
        chestCanvas.SetActive(true);    
    }
}
