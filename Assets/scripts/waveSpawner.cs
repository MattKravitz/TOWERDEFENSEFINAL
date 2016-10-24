using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class waveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    private float timeBetweenWaves = 9f;
    private float countdown = 2f;
    private int waveNumber = 1;
    public Transform spawnPoint;
    //public Text waveCountdown;
    private int positionOffset = 0;
    private int i = 1;
    private int randCountdown;
    public static bool start;

    void Start()
    {
        randCountdown = Random.Range(1, 5);
        start = false;
    }

    void Update()
    {
        if (start == true) {
            if (countdown <= 0f || i==1)
            {
                SpawnEnemy();
                randCountdown = Random.Range(1,7);
                countdown = randCountdown;
                i++;
            }

            countdown -= Time.deltaTime;
        }
    }
   
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, proceduralGeneration.points[17].position, proceduralGeneration.points[17].rotation);
    }

    public static void setStart()
    {
        start = true;
    }
}



