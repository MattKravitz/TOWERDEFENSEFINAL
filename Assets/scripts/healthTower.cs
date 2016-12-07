using UnityEngine;
using System.Collections;

public class healthTower : MonoBehaviour {
    public waveSpawner wSpawner;
    private GameObject thisGame;
    private bool hasHealthIncreased = false;
    public int healthIncrease = 1;
    private int currentHealth;
	// Use this for initialization
	void Start () {
        currentHealth = ActiveTowerRotate.getHealth();
        thisGame = GameObject.Find("GameMaster");
        wSpawner = thisGame.GetComponentInChildren<waveSpawner>();
    }
	
	// Update is called once per frame
	void Update () {
        if(wSpawner.getWaveState() == false && hasHealthIncreased == false){
            currentHealth = ActiveTowerRotate.getHealth();
            if (currentHealth < 100)
            {
                ActiveTowerRotate.setHealth(currentHealth + healthIncrease);
                hasHealthIncreased = true;
            }
        } else if(wSpawner.getWaveState() == true && hasHealthIncreased == true)
        {
            hasHealthIncreased = false;
        }
	}
}
