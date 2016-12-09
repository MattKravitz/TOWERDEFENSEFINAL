using UnityEngine;
using System.Collections;

public class towerVariables : MonoBehaviour {
    [Header("Enemy Attributes")]
    public int enemyHealth;
    public float enemySpeed;
    public int enemyMV; //enemyMoneyValue

    [Header("Tower Attributes")]
    public float towerShotSpeed =  2f;
    public int towerDamage = 1;
    public float towerRange = 3f;
    public Transform m_target;
    private enemy targetedEnemy;


    
    [Header("Projectile/Shooting Setup")]
    public GameObject projectile;
    public Transform shootPosition;
    public float shotCooldown = 1;

    [Header("Targeting Variables")]
    public string enemiesTag = "enemy";
    public Transform rotatingPiece;
    public float rotationVelocity = 5f;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("refreshTarget", 2f, .5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(m_target == null)
        {
            //return; //empty return statement to kill update function if no target exists.
        }
        else
        {
            acquireTarget();
            if (shotCooldown <= 0f)
            {
                fire();
                shotCooldown = 1f / towerShotSpeed;
            }

            shotCooldown -= Time.deltaTime;
        }
	}



    public void fire()
    {
        /**This is a temporary position configuration for the prototype only
        *   this will produce awkward graphics since the projectile will be launched from the same coordinate as the tower.
        **/
        
        GameObject projectileShot = (GameObject)Instantiate(projectile, shootPosition.position, shootPosition.rotation);
        projectile projectile1 = projectileShot.GetComponent<projectile>();

        projectile1.setDamage(towerDamage);
        //projectile1.setShotPoint(shootPosition.position);

        if (projectile != null)
        {
            Debug.Log("Firing");
            projectile1.trace(m_target.transform, targetedEnemy);
        }

    }

   // void OnDrawGizmosSelected()
    //{
     //   Gizmos.DrawWireSphere(transform.position, towerRange);
   // }
   void acquireTarget()
    {
        //Debug.Log("HAS TARGET");
        Vector3 direction = m_target.position - shootPosition.position;
        Quaternion towerRotation = Quaternion.LookRotation(direction);
        Vector3 convertedRotation = Quaternion.Lerp(rotatingPiece.rotation, towerRotation, Time.deltaTime * rotationVelocity).eulerAngles;
        rotatingPiece.rotation = Quaternion.Euler(0f, convertedRotation.y, 0f);
    }
    /// <summary>
    /// Refreshes the target.
    /// </summary>
    void refreshTarget()
    {
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag(enemiesTag);
        float smallestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach(GameObject enemy in enemiesArray)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(enemyDistance <= smallestDistance)
            {
                smallestDistance = enemyDistance;
                closestEnemy = enemy;
                Debug.Log("Redefining Target");
            }

        }

        if(closestEnemy != null && smallestDistance <= towerRange)
        {
            Debug.Log("Target Selected");
            m_target = closestEnemy.transform;
            targetedEnemy = closestEnemy.GetComponent<enemy>();
            //targetedEnemy.setHealth(5);
        }
        else
        {
            m_target = null;
            //Debug.Log("No Target");
        }
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

    public void setTowerDamage(int damage)
    {
        towerDamage = damage;

    }

    public int getTowerDamage()
    {
        return towerDamage;
    }
}
