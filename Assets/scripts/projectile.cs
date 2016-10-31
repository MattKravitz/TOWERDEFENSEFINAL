using UnityEngine;

public class projectile : MonoBehaviour {

    [Header("Projectile Attributes")]
    public float m_damage;
    public float m_projectileSpeed = 60f;
    public GameObject collisionEffect;


    private Transform m_shootLocation;
    private Transform m_target;


   void initializeProjectile(float dmgDealtByProj, Transform shootPoint)
     {
        m_damage = dmgDealtByProj;
       m_shootLocation = shootPoint;

    }

	// Update is called once per frame
	void Update ()
    {
        float distanceTraveled = 0;

	  if(m_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = m_target.position - transform.position;
        distanceTraveled = m_projectileSpeed * Time.deltaTime;

        if(checkCollision(direction.magnitude, distanceTraveled))
        {
            actionOnCollision();
        }

        transform.Translate(direction.normalized * distanceTraveled, Space.World);
	}

    //function responsible for target following
    public void trace(Transform target)
    {
        m_target = target;
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
        GameObject impactEffect = (GameObject)Instantiate(collisionEffect, transform.position, transform.rotation);

        Destroy(impactEffect, 3f);
        Destroy(gameObject);
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
