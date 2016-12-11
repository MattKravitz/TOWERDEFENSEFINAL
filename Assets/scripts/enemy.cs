﻿using UnityEngine;
using System.Collections;
using Assets.scripts;


/// <summary>
/// 
/// </summary>

public class enemy: MonoBehaviour
{

    private float speed = 2f;
    private Vector3 target;
    private int wavepointIndex = 0;
    private ActiveTowerRotate playerTower;
    private int health=10;
    private int moneyValue = 0;
    private int m_damage = 1;

    public GameObject playerWallet;
    public GameObject gamemaster;

    public playerWallet playerWallet1
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
    void Awake()
    {
        gamemaster = GameObject.FindGameObjectWithTag("gamemaster");
        target = gamemaster.GetComponent<proceduralGeneration>().myWaypointsPositions[0];

        int wave;
        wave = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<waveSpawner>().getWave();

        playerTower = GameObject.FindGameObjectWithTag("playerTower").GetComponent<ActiveTowerRotate>();
        //this is just the basic way of how im going to give every enemy its attributes
        

        speed = Random.Range(1, 5);
        this.tag = "enemy";

        if (speed == 1)
        {
            //Loop to increase speed every five rounds, and health every ten
            for (int i = 1; i <= wave; i++)
            {
                health = 100;
                if (i % 5 == 0) //If a multiple of 5, increase speed by .25f
                {
                    speed = speed + .25f;
                }
                if (i % 10 == 0) //If a multiple of 10, increase health by 25
                {
                    health = health + 25;
                }
            }
            Debug.Log("Speed: " + getSpeed() + " Health: " + getHealth() + " Wave: " + wave);
          
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
          
        }
        if (speed == 2)
        {
            //Loop to increase speed every five rounds, and health every ten

            for (int i = 1; i <= wave; i++)
            {
                health = 75;
                if (i % 5 == 0) //If a multiple of 5, increase speed by .25f
                {
                    speed = speed + .25f;
                }
                if(i % 10 == 0) //If a multiple of 10, increase health by 25
                {
                    health = health + 25;
                }
            }
            Debug.Log("Speed: " + getSpeed() + " Health: " + getHealth() + " Wave: " + wave);

        }
        if (speed == 3)
        {
            //Loop to increase speed every five rounds, and health every ten

            for (int i = 1; i <= wave; i++)
            {
                health = 50;
                if (i % 5 == 0) //If a multiple of 5, increase speed by .25f
                {
                    speed = speed + .25f;
                }
                if (i % 10 == 0) //If a multiple of 10, increase health by 25
                {
                    health = health + 25;
                }

            }
            Debug.Log("Speed: " + getSpeed() + " Health: " + getHealth() + " Wave: " + wave);

            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
        if (speed == 4)
        {
            //Loop to increase speed every five rounds, and health every ten

            for (int i = 1; i <= wave; i++)
            {
                health = 25;
                if(i % 5 == 0) //If a multiple of 5, increase speed by .25f
                {
                    speed = speed + .25f;
                }
            }
            Debug.Log("Speed: " + getSpeed() + " Health: " + getHealth() + " Wave: " + wave);
           
            gameObject.GetComponent<Renderer>().material.color = Color.green;
     
        }

        setMoneyValue(getHealth()/10);
    }
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update()
    {
        if(this.health <= 0)
        {
            Destroy(this.gameObject);

            playerWallet.GetComponent<playerWallet>().addMoney(getMoneyValue());
        }
        
        //This code to traverse through wavepoints was found in a video on youtube by Brackeys-------------------------------
        Vector3 dir = target - this.transform.position;

        this.transform.Translate(dir.normalized * speed * .5f * Time.deltaTime, Space.World);
        if (Vector3.Distance(this.transform.position, target) <= .2f)
        {
            GetNextWaypoint();

        }
        //-------------------------------------------------------------------------------------------------------------------
       
    }
    /// <summary>
    /// Gets the next waypoint.
    /// </summary>
    void GetNextWaypoint()
    {
        //The basic if statement to destroy the gameobject and the wavepoint incrementation was found in a video on youtube by Brackeys-------------------------------
        if (wavepointIndex >= gamemaster.GetComponent<proceduralGeneration>().myWaypoints.Count - 1)
        {
            playerTower.takeDamage(this);
            Destroy(this.gameObject);
            return;
        }
        wavepointIndex++;
        target = gamemaster.GetComponent<proceduralGeneration>().myWaypointsPositions[wavepointIndex];

        //------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
    //our getters and setters
    /// <summary>
    /// Gets the health.
    /// </summary>
    /// <returns></returns>
    public int getHealth()
    {
        return health;
    }
    /// <summary>
    /// Sets the health.
    /// </summary>
    /// <param name="h">The h.</param>
    public void setHealth(int h)
    {
        health = h;
    }
    /// <summary>
    /// Gets the money value.
    /// </summary>
    /// <returns></returns>
    public int getMoneyValue()
    {
        return moneyValue;
    }
    /// <summary>
    /// Sets the money value.
    /// </summary>
    /// <param name="m">The m.</param>
    public void setMoneyValue(int m)
    {
        moneyValue = m;
    }
    /// <summary>
    /// Gets the speed.
    /// </summary>
    /// <returns></returns>
    public float getSpeed()
    {
        return speed;
    }
    /// <summary>
    /// Sets the speed.
    /// </summary>
    /// <param name="s">The s.</param>
    public void setSpeed(float s)
    {
        speed = s;
    }

    /// <summary>
    /// Sets the damage.
    /// </summary>
    /// <param name="damage">The damage.</param>
    public void setDamage(int damage)
    {
        m_damage = damage;
    }

    /// <summary>
    /// Gets the damage.
    /// </summary>
    /// <returns></returns>
    public int getDamage()
    {
        return m_damage;
    }

    /// <summary>
    /// Attacks the enemy.
    /// </summary>
    /// <param name="damage">The damage.</param>
    public void attackEnemy(int damage)
    {
        health = health - damage;
    }
}
