using UnityEngine;

public class projectile : MonoBehaviour {

    [Header("Projectile Attributes")]
    public float m_damage;
    public float m_projectileSpeed = 40f;
    public GameObject ballisticsEffect;


    private Transform m_shootLocation;
    private Transform m_target;
    private enemy m_targetEnemy;

  public void initializeProjectile(float dmgDealtByProj, Transform shootPoint)
     {
       m_damage = dmgDealtByProj;
       m_shootLocation = shootPoint;

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

        if(checkCollision(direction.magnitude, distanceTraveled))
        {
            actionOnCollision();
            return;
        }

        transform.Translate(direction.normalized * distanceTraveled, Space.World);
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
        Debug.Log("Target Hit");
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
*
*   void dealDamage(take enemy object here)
*   {
*   
*   }
**/
}
