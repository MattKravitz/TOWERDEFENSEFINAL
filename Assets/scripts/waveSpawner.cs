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
    public bool start = false;
    private int healthPool = 100; //the starting health pool
    private int enemyHealthLeft;
    private int currentWave = 0;
    private bool spawnWave = false;
    private int spawnWaveAmount;

    /// <summary>
    /// Gets or sets the enemy.
    /// </summary>
    /// <value>
    /// The enemy.
    /// </value>
    /// <exception cref="System.NotImplementedException"></exception>
    public enemy enemy
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
    {
        randCountdown = Random.Range(1, 3);
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
                randCountdown = Random.Range(1,4);//set rand number
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
    public void setStart()
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
    public int getWave()
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
    /// <summary>
    /// Gets the state of the wave.
    /// </summary>
    /// <returns></returns>
    public bool getWaveState()
    {
        return start;
    }
}



