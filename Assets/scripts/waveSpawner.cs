using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/// <summary>
/// 
/// </summary>
public class waveSpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    private float timeBetweenWaves = 9f;
    private float countdown = 2f;
    private int waveNumber = 1;
    public Transform spawnPoint;
    //public Text waveCountdown;
    private int positionOffset = 0;
    private int i = 1;
    private int randCountdown;
    public static bool start = false;
    private static int healthPool = 100; //the starting health pool
    private static int enemyHealthLeft;
    private static int currentWave = 0;
    private static bool spawnWave = false;
    private static int spawnWaveAmount;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
    {
        randCountdown = Random.Range(1, 5);
        start = false;
        enemyHealthLeft = healthPool;
    }

    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update()
    {
        if (start == true) {//if the enenmy spawn has been clicked
            if (countdown <= 0f || i==1)//when its ready to spawn next enemy
            {
                spawnEnemy();
                randCountdown = Random.Range(1,7);//set rand number
                countdown = randCountdown;//set the next time for spawn
                i++;
                //set multiple enemies to spawn in a row
                if(randCountdown > 5 && healthPool>1000+waveNumber*5)//TODO: account for increase in enemy health
                {
                    spawnWave = true;
                    spawnWaveAmount = Random.Range(5,11);
                }
            }
            //spawn multiple enemies in a row
            else if (spawnWave)
            {
                spawnEnemy();
                spawnWaveAmount--;
                if(spawnWaveAmount == 0)
                {
                    spawnWave = false;
                }
            }
            if (enemyHealthLeft <= 0)
            {
                endWave();
            }
            countdown -= Time.deltaTime;//decrement the countdown by timepassed
        }
    }


    /// <summary>
    /// Sets the start.
    /// </summary>
    public static void setStart()
    {
        if (start == false)
        {
            start = true;//if the spawn has been clicked we set this to true
            enemyHealthLeft = healthPool;
            currentWave++;
        }
    }
    private void endWave()
    {
        start = false;
        healthPool = healthPool + 50*currentWave;
    }
    /// <summary>
    /// Get the current wave
    /// </summary>
    /// <returns>currentWave</returns>
    public static int getWave()
    {
        return currentWave;
    }
    /// <summary>
    /// create a new enemy
    /// </summary>
    private void spawnEnemy()
    {
        GameObject placedObject = (GameObject)Instantiate(enemyPrefab, proceduralGeneration.points[17].position, proceduralGeneration.points[17].rotation);//spawn next enemy
        enemy newEnemy = placedObject.GetComponent<enemy>();
        enemyHealthLeft = enemyHealthLeft - newEnemy.getHealth();
        Debug.Log("Health pool left " + enemyHealthLeft);
    }
}



