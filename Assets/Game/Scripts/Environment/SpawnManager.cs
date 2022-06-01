using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] environmentList;
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] chests;
    [SerializeField] GameObject[] bosses;
    [SerializeField] Animal[] animals;
    [SerializeField] Player[] players;

    PlayerUI playerUI;
    static internal int enemyCount = 0;
    public static int chestCount = 0;
    internal static int bossCount = 0;
    static internal int environmentCount;
    internal static int waveCount;
    private float timeSinceAnimalSpawn;
    static internal int playerIndex;

    private void Awake()
    {
        Instantiate(players[playerIndex], new Vector3(-6.21f, -2.51f, 0), players[0].transform.rotation);

    }
    private void Start()
    {
        timeSinceAnimalSpawn = 14;
        playerUI = FindObjectOfType<PlayerUI>();

        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                playerUI.waveCounter.text = "Wave\n" + waveCount;
                break;
            case 1:
                playerUI.waveCounter.text = "Xвиля\n" + waveCount;
                break;
            case 2:
                playerUI.waveCounter.text = "Волна\n" + waveCount;
                break;
        }
        var index = Random.Range(0, environmentList.Length);
        Instantiate(environmentList[index], new Vector3(transform.position.x + 10, transform.position.y - 1.68f, transform.position.z), environmentList[index].transform.rotation);
        StartCoroutine(WaitForEnvironmentSpawn());
        SpawnRandomEnemy();
        enemyCount = 1;
        
    }

    private void Update()
    {
        if (GameController.isGame)
        {
            timeSinceAnimalSpawn += Time.deltaTime;
        }
        if (GameController.isGame & enemyCount == 0 & chestCount == 0 & bossCount == 0)
        {
            int randomPrefabSpawn = Random.Range(0, 100);
            if (waveCount % 7 == 6)
            {
                SpawnRandomBoss();
                AddWave();
            }
            else if (randomPrefabSpawn > 90)
            {
                SpawnRandomChest();
                AddWave();
            }

            else if (randomPrefabSpawn <=90)
            {
                SpawnRandomEnemy();
                enemyCount = 1;
                AddWave();
            }
        }
        if (GameController.isGame & environmentCount == 2)
        {
            SpawnRandomEnvironment();
            environmentCount += 1;
        }
        if (GameController.isGame & timeSinceAnimalSpawn > 15)
        {
            SpawnRandomAnimal();
        }
    }

    // Spawn random enemy when enemy has been killed
    public void SpawnRandomEnemy()
    {
        int i = Random.Range(0, enemies.Length);
        Instantiate(enemies[i], transform.position, enemies[i].transform.rotation);
    }

    // Spawn random environment when one of environments has been destroyed
    private void SpawnRandomEnvironment()
    {
        var index = Random.Range(0, environmentList.Length);
        Instantiate(environmentList[index], new Vector3(transform.position.x + 10, transform.position.y - 1.71f, transform.position.z), environmentList[index].transform.rotation);
    }

    //Spawn random chest with some chance based on his rarity
    private void SpawnRandomChest()
    {
        int randomInt = Random.Range(0, 100);
        var randomChest = randomInt >= 50 ?
            Instantiate(chests[0], new Vector3(transform.position.x, -2.42f, transform.position.z), transform.rotation) : randomInt >= 20 & randomInt < 50 ?
            Instantiate(chests[1], new Vector3(transform.position.x, -2.42f, transform.position.z), transform.rotation) : randomInt >= 7 & randomInt < 20 ?
            Instantiate(chests[2], new Vector3(transform.position.x, -2.42f, transform.position.z), transform.rotation) : Instantiate(chests[3], new Vector3(transform.position.x, -2.42f, transform.position.z), transform.rotation);
        chestCount += 1;
    }

    // Spawn random boss
    private void  SpawnRandomBoss()
    {
        int index = Random.Range(0, bosses.Length);
        Instantiate(bosses[index], transform.position, bosses[index].transform.rotation);
        bossCount = 1;
        
    }

    // Creating 2 additional environments at Start function
    private IEnumerator WaitForEnvironmentSpawn()
    {
        environmentCount = 3;
        yield return new WaitForSeconds(7.9f);
        var index = Random.Range(0, environmentList.Length);
        Instantiate(environmentList[index], new Vector3(transform.position.x + 10, transform.position.y - 1.68f, transform.position.z), environmentList[index].transform.rotation);
        yield return new WaitForSeconds(7.9f);
        index = Random.Range(0, environmentList.Length);
        Instantiate(environmentList[index], new Vector3(transform.position.x + 10, transform.position.y - 1.68f, transform.position.z), environmentList[index].transform.rotation);

    }

    // Spawn random animal every 0 - 10.5 seconds
    private void SpawnRandomAnimal()
    {
        timeSinceAnimalSpawn = Random.Range(0, 4.5f);
        var index = Random.Range(0, 5);
        Instantiate(animals[index], transform.position, animals[index].transform.rotation);
    }

    private void AddWave()
    {
        waveCount++;
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                playerUI.waveCounter.text = "Wave\n" + waveCount;
                break;
            case 1:
                playerUI.waveCounter.text = "Xвиля\n" + waveCount;
                break;
            case 2:
                playerUI.waveCounter.text = "Волна\n" + waveCount;
                break;
        }
    }
}
