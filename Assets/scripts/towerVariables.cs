using UnityEngine;
using System.Collections;

public class towerVariables : MonoBehaviour {
    [Header("Enemy Attributes")]
    public int enemyHealth;
    public float enemySpeed;
    public int enemyMV; //enemyMoneyValue

    [Header("Tower Attributes")]
    public float towerShotSpeed;
    public float towerDamage;
    public float towerRange;

    // "p_" refers to variables used to configure projectile mechanics
    [Header("Projectile Setup")]
    public GameObject p_projectilePrefab;
    public Transform p_shootPosition;

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


    public void fire()
    {
/**This is a temporary position configuration for the prototype only
*   this will produce awkward graphics since the projectile will be launched from the same coordinate as the tower.
**/
        p_shootPosition.position = transform.position; 
        GameObject projectileShot = (GameObject)Instantiate(p_projectilePrefab, p_shootPosition);
        projectile projectile = projectileShot.GetComponent<projectile>();

        if(projectile != null)
        {
           // projectile.trace(currentTarget.transform);
        }

    }

}
