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

        if (start == true) {//if the enenmy spawn has been clicked
            if (countdown <= 0f || i==1)//when its ready to spawn next enemy
            {
                Instantiate(enemyPrefab, proceduralGeneration.points[17].position, proceduralGeneration.points[17].rotation);//spawn next enemy
                randCountdown = Random.Range(1,7);//set rand number
                countdown = randCountdown;//set the next time for spawn
                i++;
            }

            countdown -= Time.deltaTime;//decrement the countdown by timepassed
        }
    }
   
    
    public static void setStart()
    {
        start = true;//if the spawn has been clicked we set this to true
    }
}



