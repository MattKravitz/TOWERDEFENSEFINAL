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

    //Sets the enemy speed
    public void setEnemySpeed(float speed)
    {
        enemySpeed = speed;

    }

    //Returns the enemey speed
    public float getEnemySpeed()
    {
        return enemySpeed; 
    }

    //Sets the money multiplier
    public void setMoneyMultiplier(int money)
    {
        enemyMV = money;
    }

    //Returns the money multiplier
    public int getMoneyMultiplier()
    {
        return enemyMV; 
    }

    //Sets the tower shot speed
    public void setTowerShotSpeed(float shotSpeed)
    {
        towerShotSpeed = shotSpeed;

    }

    //Returns the tower shot speed
    public float getTowerSpeed()
    {
        return towerShotSpeed;
    }

    //Sets the tower range
    public void setTowerRange(float range)
    {
        towerRange = range;

    }

    //Returns the tower range
    public float getTowerRange()
    {
        return towerRange;
    }

    //Sets the tower damage
    public void setTowerDamage(float damage)
    {
        towerDamage = damage;

    }

    //Returns the tower damage
    public float getTowerDamage()
    {
        return towerDamage;
    }
}
