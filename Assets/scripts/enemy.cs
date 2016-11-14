using UnityEngine;
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

    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Awake()
    {
        playerTower = GameObject.FindGameObjectWithTag("playerTower").GetComponent<ActiveTowerRotate>();
        //this is just the basic way of how im going to give every enemy its attributes
        target = proceduralGeneration.myWaypointsPositions[0];
        speed = Random.Range(1, 5);
        this.tag = "enemy";

        if (speed == 1)
        {
            health = 100;
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            setMoneyValue(100);
        }
        if (speed == 2)
        {
            health = 75;
            setMoneyValue(75);
        }
        if (speed == 3)
        {
            health = 50;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            setMoneyValue(50);
        }
        if (speed == 4)
        {
            health = 25;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            setMoneyValue(25);
        }
        
    }
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update()
    {
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
        if (wavepointIndex >= proceduralGeneration.myWaypoints.Count - 1)
        {
            playerTower.takeDamage(this);
            Destroy(this.gameObject);
            return;
        }
        wavepointIndex++;
        target = proceduralGeneration.myWaypointsPositions[wavepointIndex];

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
    public void setSpeed(int s)
    {
        speed = s;
    }

   public void setDamage(int damage)
    {
        m_damage = damage;
    }
    
    public int getDamage()
    {
        return m_damage;
    }
}
