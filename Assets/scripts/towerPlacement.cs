﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class towerPlacement : MonoBehaviour {

    private Vector3 placement;
    private Vector3 down;
    private int j;

    private int thisTower;
    private int cost;

    public Transform lasertower1;
    public Transform lasertower2;
    public Transform lasertower3;
    public Transform lasertower4;

    public Transform tower;
    public Transform healthTower;
    public Transform speedTower;
    public Transform damTower;
    public Transform moneyTower;

    public Transform stand;
    public int[] towerCheck = new int[256];

    public GameObject money;
    private static int amount;

    public laserTower laserTower
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public healthTower healthTower1
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public damageTower damageTower
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public gunnerTower gunnerTower
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () {

	    //0s mean thereis not a tower spawned here, 1 means there is
        placement = this.transform.position;
        Vector2 temp = new Vector2(placement.x, placement.z);
        for (int i = 0; i < towerCheck.Length; i++)
        {
            towerCheck[i] = 0;
        }
        //---------------------------------------------------------
        //Checks all spots on the game board
        for (int i = 0; i < 255; i++)
        {

            Vector2 temp2 = new Vector2(proceduralGeneration.points[i].position.x, proceduralGeneration.points[i].position.z);
            if (temp == temp2) //If one of the spots is clicked, stores what index it was
            {
                j = i;

            }
        }

    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update () {
	
        


	}


    /// <summary>
    /// Called when [mouse down].
    /// </summary>
    void OnMouseDown()
    {
        thisTower = ToggleHandler.getTower();
        cost = ToggleHandler.getCost();
        amount = playerWallet.getPlayerMoneyTotal();

        if (towerCheck[j] == 0 && cost <= amount)
        {
            playerWallet.subtractMoney(cost);

            if (thisTower == 0) { Instantiate(lasertower1, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }
            else if (thisTower == 1) { Instantiate(lasertower2, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }
            else if (thisTower == 2) { Instantiate(lasertower3, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }
            else if (thisTower == 3) { Instantiate(lasertower4, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }
            else if (thisTower == 4) { Instantiate(tower, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }
            else if (thisTower == 5) { Instantiate(healthTower, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }
            else if (thisTower == 6) { Instantiate(moneyTower, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }
            else if (thisTower == 7) { Instantiate(damTower, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }
            else if (thisTower == 8) { Instantiate(speedTower, proceduralGeneration.redpoints[j].position, proceduralGeneration.redpoints[j].rotation); }

            Instantiate(stand, proceduralGeneration.points[j].position, proceduralGeneration.points[j].rotation);
            towerCheck[j] = 1;

        }
    }
}
