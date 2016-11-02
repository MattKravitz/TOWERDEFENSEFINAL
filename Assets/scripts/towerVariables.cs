using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class towerVariables : MonoBehaviour {

    public int enemyHealth;
    public float enemySpeed;
    public int enemyMV; //enemyMoneyValue

    public float towerShotSpeed;
    public float towerDamage;
    public float towerRange;



    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () {
	
	}

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update () {
	
	}

    //Sets the enemy health to the paramater
    /// <summary>
    /// Sets the enemy health.
    /// </summary>
    /// <param name="health">The health.</param>
    public void setEnemyHealth(int health)
    {
        enemyHealth = health; 
    }

    //Returns the enemyHealth
    /// <summary>
    /// Gets the enemy health.
    /// </summary>
    /// <returns></returns>
    public int getEnemyHealth()
    {
        return enemyHealth;

    }

    //Sets the enemy speed
    /// <summary>
    /// Sets the enemy speed.
    /// </summary>
    /// <param name="speed">The speed.</param>
    public void setEnemySpeed(float speed)
    {
        enemySpeed = speed;

    }

    //Returns the enemey speed
    /// <summary>
    /// Gets the enemy speed.
    /// </summary>
    /// <returns></returns>
    public float getEnemySpeed()
    {
        return enemySpeed; 
    }

    //Sets the money multiplier
    /// <summary>
    /// Sets the money multiplier.
    /// </summary>
    /// <param name="money">The money.</param>
    public void setMoneyMultiplier(int money)
    {
        enemyMV = money;
    }

    //Returns the money multiplier
    /// <summary>
    /// Gets the money multiplier.
    /// </summary>
    /// <returns></returns>
    public int getMoneyMultiplier()
    {
        return enemyMV; 
    }

    //Sets the tower shot speed
    /// <summary>
    /// Sets the tower shot speed.
    /// </summary>
    /// <param name="shotSpeed">The shot speed.</param>
    public void setTowerShotSpeed(float shotSpeed)
    {
        towerShotSpeed = shotSpeed;

    }

    //Returns the tower shot speed
    /// <summary>
    /// Gets the tower speed.
    /// </summary>
    /// <returns></returns>
    public float getTowerSpeed()
    {
        return towerShotSpeed;
    }

    //Sets the tower range
    /// <summary>
    /// Sets the tower range.
    /// </summary>
    /// <param name="range">The range.</param>
    public void setTowerRange(float range)
    {
        towerRange = range;

    }

    //Returns the tower range
    /// <summary>
    /// Gets the tower range.
    /// </summary>
    /// <returns></returns>
    public float getTowerRange()
    {
        return towerRange;
    }

    //Sets the tower damage
    /// <summary>
    /// Sets the tower damage.
    /// </summary>
    /// <param name="damage">The damage.</param>
    public void setTowerDamage(float damage)
    {
        towerDamage = damage;

    }

    //Returns the tower damage
    /// <summary>
    /// Gets the tower damage.
    /// </summary>
    /// <returns></returns>
    public float getTowerDamage()
    {
        return towerDamage;
    }
}
