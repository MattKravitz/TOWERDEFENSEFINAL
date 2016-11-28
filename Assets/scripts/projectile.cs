﻿using UnityEngine;

/// <summary>
/// 
/// </summary>
public class projectile : MonoBehaviour {

    [Header("Projectile Attributes")]
    public int m_damage;
    public float m_projectileSpeed = 45f;
    public GameObject ballisticsEffect;


   // private Transform m_shootLocation;
    private Transform m_target;
    private enemy m_targetEnemy;

    /// <summary>
    /// Sets the damage.
    /// </summary>
    /// <param name="dmgDealtByProj">The DMG dealt by proj.</param>
    public void setDamage(int dmgDealtByProj)
     {
        m_damage = dmgDealtByProj;
    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update ()
    {
        

	  if(m_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = m_target.position - transform.position;
        float distanceTraveled = m_projectileSpeed * Time.deltaTime;
        transform.Translate(direction.normalized * distanceTraveled, Space.World);
        if (checkCollision(direction.magnitude, distanceTraveled))
        {
            actionOnCollisionWithDamage();
            
        }

        
	}

    //function responsible for target following
    /// <summary>
    /// Traces the specified target.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <param name="targetEnemy">The target enemy.</param>
    public void trace(Transform target, enemy targetEnemy)
    {
        m_target = target;
        m_targetEnemy = targetEnemy;
        
    }


    /// <summary>
    /// Checks the collision.
    /// </summary>
    /// <param name="directionVectorMagnitude">The direction vector magnitude.</param>
    /// <param name="distancePerFrame">The distance per frame.</param>
    /// <returns></returns>
    virtual public bool checkCollision(float directionVectorMagnitude, float distancePerFrame)
    {
        if (directionVectorMagnitude <= distancePerFrame)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Actions the on collision.
    /// </summary>
    virtual public void actionOnCollision()
    {
        GameObject impactEffect = (GameObject)Instantiate(ballisticsEffect, transform.position, transform.rotation);

        Destroy(impactEffect, 1f);
        Destroy(m_target.gameObject);
        return;
    }

    /// <summary>
    /// Actions the on collision with damage.
    /// </summary>
    virtual public void actionOnCollisionWithDamage()
    {
        dealDamage();
        Destroy(gameObject);
        Debug.Log("Target Damaged");
        Debug.Log("TargetHealth is now: ");
        Debug.Log(m_targetEnemy.getHealth());

        GameObject impactEffect = (GameObject)Instantiate(ballisticsEffect, transform.position, transform.rotation);

        Destroy(impactEffect, 1f);

        return;
    }

    /// <summary>
    /// Sets the shot point.
    /// </summary>
    /// <param name="firePoint">The fire point.</param>
  //  public void setShotPoint(Transform firePoint)
   // {
   //     m_shootLocation = firePoint;
   // }
    /**
    *   Functions to Implement later
    *    void aoeDetection()
    *   {
    *
    *   }
*/
    /// <summary>
    /// Deals the damage.
    /// </summary>
    virtual public void dealDamage()
    {
        int healthAfterDamage = m_targetEnemy.getHealth() - m_damage;
        if(damageIsLethal())
        {
            killEnemy(m_targetEnemy);
            //Debug.Log("Target should self-destruct on next update");
        }
        else
        {
            m_targetEnemy.setHealth(healthAfterDamage);
        }
    }

    /// <summary>
    /// Damages the is lethal.
    /// </summary>
    /// <returns></returns>
    virtual public bool damageIsLethal()
    {
        if((m_targetEnemy.getHealth() <= m_damage))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Kills the enemy.
    /// </summary>
    /// <param name="targetToKill">The target to kill.</param>
    virtual public void killEnemy(enemy targetToKill)
    {
        Destroy(targetToKill.gameObject);
        Debug.Log("Enemy killed by killEnemy Function");
    }

}
