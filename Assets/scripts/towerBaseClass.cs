using UnityEngine;
using System.Collections;

public class towerBaseClass : MonoBehaviour {

    [Header("Tower Attributes")]
    public float towerRange = 3f;
    public Transform m_target;
    public enemy targetedEnemy;
    public string towersTag = "placed_tower";
    public Collider towerCollider;

    [Header("Targeting Variables")]
    public string enemiesTag = "enemy";
    public Transform m_towerPosition;
    public Transform m_rotatingPiece;
    public float rotationVelocity = 5f;


    [Header("Economy Interfacing Variables")]
    public int towerCost;
    public int towerValue;

    public  void acquireTarget()
    {
        Vector3 direction = m_target.position - m_towerPosition.position;
        Quaternion towerRotation = Quaternion.LookRotation(direction);
        Vector3 convertedRotation = Quaternion.Lerp(m_rotatingPiece.rotation, towerRotation, Time.deltaTime * rotationVelocity).eulerAngles;
        m_rotatingPiece.rotation = Quaternion.Euler(0f, convertedRotation.y, 0f);
    }

    virtual public void refreshTarget()
    {
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag(enemiesTag);
        float smallestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemiesArray)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemyDistance <= smallestDistance)
            {
                smallestDistance = enemyDistance;
                closestEnemy = enemy;
                Debug.Log("Redefining Target");
            }

        }

        if (closestEnemy != null && smallestDistance <= towerRange)
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

    public  void setTowerRange(float range)
    {
        towerRange = range;
    }
    public  float getTowerRange()
    {
        return towerRange;
    }
    public  void setTowerTarget(Transform target)
    {
        m_target = target;
    }
    public  Transform getTowerTarget()
    {
        return m_target;
    }
    public void setTargetedEnemy(enemy newEnemy)
    {
        targetedEnemy = newEnemy;
    }
    public enemy getTargetedEnemy()
    {
        return targetedEnemy;
    }
    public void setTowerCost(int cost)
    {
        towerCost = cost;
    }
    public int getTowerCost()
    {
        return towerCost;
    }
   

}
