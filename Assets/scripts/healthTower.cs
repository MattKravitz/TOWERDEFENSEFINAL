using UnityEngine;
using System.Collections;

public class healthTower : MonoBehaviour {
    public waveSpawner wSpawner;
    private GameObject thisGame;
    private bool hasHealthIncreased = true;
    public int healthIncrease = 1;
    private int currentHealth;
	// Use this for initialization
	void Start () {
        currentHealth = GameObject.FindGameObjectWithTag("playerTower").GetComponent<ActiveTowerRotate>().getHealth();
        thisGame = GameObject.Find("GameMaster");
        wSpawner = thisGame.GetComponentInChildren<waveSpawner>();
    }
	
	// Update is called once per frame
	void Update () {
        if(wSpawner.getWaveState() == true && hasHealthIncreased == false){
            currentHealth = GameObject.FindGameObjectWithTag("playerTower").GetComponent<ActiveTowerRotate>().getHealth();
            if (currentHealth < 100)
            {
                GameObject.FindGameObjectWithTag("playerTower").GetComponent<ActiveTowerRotate>().setHealth(currentHealth + healthIncrease);
            }
            hasHealthIncreased = true;
        } else if(wSpawner.getWaveState() == false && hasHealthIncreased == true)
        {
            hasHealthIncreased = false;
        }
	}
}
