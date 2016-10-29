using UnityEngine;
using System.Collections;

public class towerVariables : MonoBehaviour {

    public int enemyHealth;
    public float enemySpeed;
    public int enemyMV; //enemyMoneyValue

    public float towerShotSpeed;
    public float towerDamage;
    public float towerRange; 



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Sets the enemy health to the paramater
    public void setEnemyHealth(int health)
    {
        enemyHealth = health; 
    }

    //Returns the enemyHealth
    public int getEnemyHealth()
    {
        return enemyHealth;

    }

    public void setEnemySpeed(float speed)
    {
        enemySpeed = speed;

    }

    public float getEnemySpeed()
    {
        return enemySpeed; 
    }

    public void setMoneyMultiplier(int money)
    {
        enemyMV = money;
    }

    public int getMoneyMultiplier()
    {
        return enemyMV; 
    }

    public void setTowerShotSpeed(float shotSpeed)
    {
        towerShotSpeed = shotSpeed;

    }

    public float getTowerSpeed()
    {
        return towerShotSpeed;
    }

    public void setTowerRange(float range)
    {
        towerRange = range;

    }

    public float getTowerRange()
    {
        return towerRange;
    }

    public void setTowerDamage(float damage)
    {
        towerDamage = damage;

    }

    public float getTowerDamage()
    {
        return towerDamage;
    }
}
