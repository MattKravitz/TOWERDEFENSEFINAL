using UnityEngine;
using System.Collections;

public class towerBaseClass : MonoBehaviour {

    [Header("Tower Attributes")]
    public float towerRange = 3f;
    public Transform m_target;
    public enemy targetedEnemy;
    public string towersTag = "placed_tower";
    public int towerDamage = 1;
    //public Collider towerCollider;

    [Header("Targeting Variables")]
    public string enemiesTag = "enemy";
    public Transform m_towerPosition;
    public Transform m_rotatingPiece;
    public float rotationVelocity = 5f;


    [Header("Economy Interfacing Variables")]
    public int towerCost;
    public int towerValue;

    /// <summary>
    /// Acquires the target.
    /// </summary>
    public void acquireTarget()
    {
        Vector3 direction = m_target.position - m_towerPosition.position;
        Quaternion towerRotation = Quaternion.LookRotation(direction);
        Vector3 convertedRotation = Quaternion.Lerp(m_rotatingPiece.rotation, towerRotation, Time.deltaTime * rotationVelocity).eulerAngles;
        m_rotatingPiece.rotation = Quaternion.Euler(0f, convertedRotation.y, 0f);
    }

    /// <summary>
    /// Refreshes the target.
    /// </summary>
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
                
            }

        }

        if (closestEnemy != null && smallestDistance <= towerRange)
        {
            
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

    /// <summary>
    /// Sets the tower range.
    /// </summary>
    /// <param name="range">The range.</param>
    public void setTowerRange(float range)
    {
        towerRange = range;
    }
    /// <summary>
    /// Gets the tower range.
    /// </summary>
    /// <returns></returns>
    public float getTowerRange()
    {
        return towerRange;
    }
    /// <summary>
    /// Sets the tower target.
    /// </summary>
    /// <param name="target">The target.</param>
    public void setTowerTarget(Transform target)
    {
        m_target = target;
    }
    /// <summary>
    /// Gets the tower target.
    /// </summary>
    /// <returns></returns>
    public Transform getTowerTarget()
    {
        return m_target;
    }
    /// <summary>
    /// Sets the targeted enemy.
    /// </summary>
    /// <param name="newEnemy">The new enemy.</param>
    public void setTargetedEnemy(enemy newEnemy)
    {
        targetedEnemy = newEnemy;
    }
    /// <summary>
    /// Gets the targeted enemy.
    /// </summary>
    /// <returns></returns>
    public enemy getTargetedEnemy()
    {
        return targetedEnemy;
    }
    /// <summary>
    /// Sets the tower cost.
    /// </summary>
    /// <param name="cost">The cost.</param>
    public void setTowerCost(int cost)
    {
        towerCost = cost;
    }
    /// <summary>
    /// Gets the tower cost.
    /// </summary>
    /// <returns></returns>
    public int getTowerCost()
    {
        return towerCost;
    }

    /// <summary>
    /// Gets the tower damage.
    /// </summary>
    /// <returns></returns>
    public int getTowerDamage()
    {
        return towerDamage;
    }

    /// <summary>
    /// Sets the tower damage.
    /// </summary>
    /// <param name="dmg">The DMG.</param>
    public void setTowerDamage(int dmg)
    {
        towerDamage = dmg;
    }
}
