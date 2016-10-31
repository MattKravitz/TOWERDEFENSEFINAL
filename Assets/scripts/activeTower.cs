using System.Collections.Generic;
using UnityEngine;
/*
namespace Assets.scripts
{
    class activeTower : MonoBehaviour
    {
        public float shotSpeed = 1; //fire rate of the tower
        
        //TODO: add a projectile object that takes in the tower damage
        public float baseDamage = 1; //the base damage a tower deals 
        private enemy currentTarget;
        private List<enemy> targetList = new List<enemy>(); //a list of enemies in the attack radius

        [Header("Projectile Setup")]
        public GameObject projectilePrefab;
        public Transform m_shootPosition;

  //      /**
    //     * initialize the tower 
      //   * call functions to initialize projectile
        // 
        void placeTower()
        {

        }
  //      /**
         * set the target of a tower to the first element in the target list
         * TODO: add ability to attack the first, last, strongest, or weakest enemy
         
        void setTarget()
        {
            if (targetList.Count!=0)
            {
                currentTarget = targetList[0];
            }
        }
        void attack()
        {
            GameObject projectileShot = (GameObject)Instantiate(projectilePrefab, m_shootPosition, )
        }
    }
}
*/

namespace Assets.scripts
{
    class activeTower : MonoBehaviour
    {
        [Header("Active Tower Attributes")]
        public float shotSpeed = 1; //fire rate of the tower
        //TODO: add a projectile object that takes in the tower damage
        public float baseDamage = 1; //the base damage a tower deals 
        public float attackRadius = 5;
        private GameObject currentTarget;
        private List<GameObject> targetList = new List<GameObject>(); //a list of enemies in the attack radius
        private Vector3 towerPosition;
        private SphereCollider attackArea;

        // "p_" refers to variables used to configure projectile mechanics
        [Header("Projectile Setup")]
        public GameObject p_projectilePrefab;
        public Transform p_shootPosition;
            


        /**
         * initialize the tower 
         * call functions to initialize projectile
         **/
        void Start()
        {
            attackArea = gameObject.AddComponent<SphereCollider>();
            towerPosition = transform.position;
            createAttackArea();
            Debug.Log("Tower Placed");
        }
        /**
         * set the target of a tower to the first element in the target list
         * TODO: add ability to attack the first, last, strongest, or weakest enemy
         **/
        void setTarget()
        {
            if (targetList.Count != 0)
            {
                currentTarget = targetList[0];
                Debug.Log("Primary target set");
            }
        }
        void attack()
        {
            /**This is a temporary position configuration for the prototype only
            *   this will produce awkward graphics since the projectile will be launched from the same coordinate as the tower.
            **/
            p_shootPosition.position = towerPosition; 
            GameObject projectileShot = (GameObject)Instantiate(p_projectilePrefab, p_shootPosition);
            projectile projectile = projectileShot.GetComponent<projectile>();

            if(projectile != null)
            {
                projectile.trace(currentTarget.transform);
            }
        }

        void createAttackArea()
        {
            attackArea.enabled = true;
            attackArea.isTrigger = true;
            attackArea.radius = attackRadius;
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "enemy")
            {

                try
                {
                    targetList.Add(col.gameObject);
                    Debug.Log("new target added to list");
                    setTarget();
                }
                catch (System.Exception e) { }
            }
        }
        void OnTriggerExit(Collider col)
        {
            if (targetList.Contains(col.gameObject))
            {
                targetList.Remove(col.gameObject);
                Debug.Log("Target removed from list");
                setTarget();
            }
        }

   
    }
}