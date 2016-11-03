using UnityEngine;

public class projectile : MonoBehaviour {

    [Header("Projectile Attributes")]
    public int m_damage;
    public float m_projectileSpeed = 40f;
    public GameObject ballisticsEffect;


    private Transform m_shootLocation;
    private Transform m_target;
    private enemy m_targetEnemy;

  public void setDamage(int dmgDealtByProj)
     {
        m_damage = dmgDealtByProj;
    }

	// Update is called once per frame
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
    public void trace(Transform target, enemy targetEnemy)
    {
        m_target = target;
        m_targetEnemy = targetEnemy;
        
    }
    

  bool checkCollision(float directionVectorMagnitude, float distancePerFrame)
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

  void actionOnCollision()
    {
        GameObject impactEffect = (GameObject)Instantiate(ballisticsEffect, transform.position, transform.rotation);

        Destroy(impactEffect, 1f);
        Destroy(m_target.gameObject);
        Debug.Log("Target Hit: One Shot");
        return;
    }

    void actionOnCollisionWithDamage()
    {
        dealDamage();
        Destroy(gameObject);
        Debug.Log("Target Damaged");
        Debug.Log("TargetHealth is now: ");
        Debug.Log(m_targetEnemy.getHealth());

        GameObject impactEffect = (GameObject)Instantiate(ballisticsEffect, transform.position, transform.rotation);

        Destroy(impactEffect, .5f);

        return;
    }

    public void setShotPoint(Transform firePoint)
    {
        m_shootLocation = firePoint;
    }
    /**
    *   Functions to Implement later
    *    void aoeDetection()
    *   {
    *
    *   }
*/
    void dealDamage()
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

    bool damageIsLethal()
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

    void killEnemy(enemy targetToKill)
    {
        Destroy(targetToKill.gameObject);
        Debug.Log("Enemy killed by killEnemy Function");
    }

}
