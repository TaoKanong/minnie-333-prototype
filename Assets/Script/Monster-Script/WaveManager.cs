using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    // int normalEnemyCount;
    // int projectileEnemyCount;
    // int fastEnemyCount;
    // int heavyEnemyCount;
    // int specialEnemyCount;
    public static WaveManager Instance { get; set; }
    public List<GameObject> monsters = new List<GameObject>();
    public List<GameObject> toSpawn = new List<GameObject>();
    public GameObject[] spawnPosition;
    public GameObject spawnPointMain;
    public float spawnTimeInterval = 6f;
    public int currWave = 1;
    public bool isWaveComplete = false;
    Transform player;
    [SerializeField]
    int enemyCount;

    // [SerializeField]
    // int testCount;
    // int maxEnemy = 35;

    //int totalCount = 10; // first wave
    float spawnTime;
    Vector3 test;

    void Awake()
    {
        // foreach (GameObject x in spawnPosition)
        // {
        //     Debug.Log(x);
        // }

        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawnPointMain.gameObject.transform.position = player.position;
        spawnTime = spawnTimeInterval;
        test = new Vector3(6, 8, 9);
        GenerateWave();
        // spawnPosition = GetComponent<GameObject[]>();
    }

    void Update()
    {
        SpawnMonster();
    }

    public void GenerateWave()
    {
        enemyCount += currWave * Random.Range(8, 13);
        spawnTimeInterval -= currWave * 0.1f;
        if (enemyCount != 0)
        {
            isWaveComplete = false;
        }
        GenerateMonster();
    }

    private void GenerateMonster()
    {
        List<GameObject> enemyList = new List<GameObject>();
        for (int i = 0; i < enemyCount; i++)
        {
            // float randomEnemy = Random.Range(0f, 1f);
            // if (currWave < 7)
            // {
            //     if (randomEnemy >= 0 && randomEnemy <= 0.4)
            //     {
            //         enemyList.Add(monsters[0]);
            //     }
            //     else if (randomEnemy > 0.4 && randomEnemy <= 0.5)
            //     {
            //         enemyList.Add(monsters[1]);
            //     }
            //     else if (randomEnemy > 0.6 && randomEnemy <= 0.85)
            //     {
            //         enemyList.Add(monsters[2]);
            //     }
            //     else if (randomEnemy > 0.85 && randomEnemy <= 1)
            //     {
            //         enemyList.Add(monsters[3]);
            //     }
            // }
            // else
            // {

            // }

            enemyList.Add(monsters[Random.Range(0, currWave >= 7 ? 5 : 4)]);
        }
        toSpawn = enemyList;
    }

    private void SpawnMonster()
    {
        spawnTime -= Time.deltaTime;
        spawnPointMain.gameObject.transform.position = player.position;
        if (toSpawn.Count > 0)
        {
            if (spawnTime <= 0)
            {
                var randomPosition = spawnPosition[Random.Range(0, spawnPosition.Length)];
                Instantiate(toSpawn[0], randomPosition.gameObject.transform.position, Quaternion.identity);
                toSpawn.RemoveAt(0);
                // testCount += 1;
                spawnTime = spawnTimeInterval;
                // if (randomPosition.activeSelf == true)
                // {
                //     Debug.Log(randomPosition.activeSelf);
                //     Instantiate(toSpawn[0], randomPosition.gameObject.transform.position, Quaternion.identity);
                //     toSpawn.RemoveAt(0);
                //     spawnTime = spawnTimeInterval;
                // }
                // else
                // {
                //     randomPosition = spawnPosition[Random.Range(0, spawnPosition.Length)];
                // }
            }
        }
    }

    public void DecreaseMonsterCount(int num) // ref with monster.TakeDamage
    {
        enemyCount -= num;
        if (enemyCount == 0)
        {
            isWaveComplete = true;
            // Debug.Log(isWaveComplete);
        }
    }

    public void RemoveSpawnPoint(GameObject currPoint) //ref with DisableSpawnPoint
    {
        // Debug.Log(currPoint);
        if (spawnPosition.Contains(currPoint))
        {
            int indexToRemove = System.Array.IndexOf(spawnPosition, currPoint);
            spawnPosition = spawnPosition.Where((value, index) => index != indexToRemove).ToArray();
            // Debug.Log(indexToRemove);
            // spawnPosition.findIndex(currPoint);
        }
    }

    public void AddSpawnPoint(GameObject currPoint) //ref with DisableSpawnPoint
    {
        if (!spawnPosition.Contains(currPoint))
        {
            // Debug.Log("Hi");
            spawnPosition = spawnPosition.Append(currPoint).ToArray();
        }
    }
}


