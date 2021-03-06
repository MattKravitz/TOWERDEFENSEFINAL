﻿using UnityEngine;
using System.Collections;

public class healthTower : MonoBehaviour {
    public waveSpawner wSpawner;
    private GameObject thisGame;
    private bool hasHealthIncreased = true;
    public int healthIncrease = 1;
    private int currentHealth;
    private LineRenderer laser;
	// Use this for initialization
	void Start () {
        currentHealth = GameObject.FindGameObjectWithTag("playerTower").GetComponent<ActiveTowerRotate>().getHealth();
        thisGame = GameObject.Find("GameMaster");
        wSpawner = thisGame.GetComponentInChildren<waveSpawner>();

        laser = gameObject.GetComponent<LineRenderer>();
        laser.SetWidth(.1f, .1f);
        laser.SetPosition(0, this.transform.position);
        laser.SetPosition(1, GameObject.FindGameObjectWithTag("playerTower").transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 1);
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
