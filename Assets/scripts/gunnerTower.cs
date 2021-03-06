﻿using UnityEngine;
using System.Collections;

public class gunnerTower : towerBaseClass {

    [Header("Tower Attack Attributes")]
    public float towerShotSpeed = 2f;
    //public int towerDamage = 1;
 

    [Header("Projectile Variables")]
    public GameObject projectile;
    public float shotCooldown = 1f;

    public projectile projectile1
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public enemy enemy
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
    void Start ()
    {
        InvokeRepeating("refreshTarget", 2f, .5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_target == null)
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
    /// <summary>
    /// Fires this instance.
    /// </summary>
    virtual public void fire()
    {
        /**This is a temporary position configuration for the prototype only
        *   this will produce awkward graphics since the projectile will be launched from the same coordinate as the tower.
        **/

        GameObject projectileShot = (GameObject)Instantiate(projectile, m_towerPosition.position, m_towerPosition.rotation);
        projectile projectile1 = projectileShot.GetComponent<projectile>();

        projectile1.setDamage(towerDamage);
        //projectile1.setShotPoint(shootPosition.position);

        if (projectile != null)
        {
            
            projectile1.trace(m_target.transform, targetedEnemy);
        }

    }

    /// <summary>
    /// Sets the tower shot speed.
    /// </summary>
    /// <param name="shotSpeed">The shot speed.</param>
    public void setTowerShotSpeed(float shotSpeed)
    {
        towerShotSpeed = shotSpeed;

    }

    /// <summary>
    /// Gets the tower speed.
    /// </summary>
    /// <returns></returns>
    public float getTowerSpeed()
    {
        return towerShotSpeed;
    }

   // public void setTowerDamage(int damage)
  //  {
       // towerDamage = damage;

   // }

   // public int getTowerDamage()
   // {
      //  return towerDamage;
   // }
}
