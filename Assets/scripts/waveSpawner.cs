using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class waveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public float timeBetweenWaves = 2f;
    public float countdown = 2f;
    private int waveNumber = 1;
    public Transform spawnPoint;
    //public Text waveCountdown;
    private int positionOffset = 0;
    
    void Update()
    {

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }

        countdown -= Time.deltaTime;
        //waveCountdown.text = Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave()
    {

       // for (int i = 0; i < waveNumber  ; i++)
       // {
            

             SpawnEnemy();
            
             yield return new WaitForSeconds(.2f);
            
            
        //}

        waveNumber++;

    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, proceduralGeneration.points[17].position, proceduralGeneration.points[17].rotation);
    }
}



