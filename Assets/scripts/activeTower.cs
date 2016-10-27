using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    class activeTower : MonoBehaviour
    {
        public float shotSpeed = 1; //fire rate of the tower
        //TODO: add a projectile object that takes in the tower damage
        public float baseDamage = 1; //the base damage a tower deals 
        public float attackRadius = 5;
        private GameObject currentTarget;
        private List<GameObject> targetList = new List<GameObject>(); //a list of enemies in the attack radius
        private Vector3 towerPosition;
        private SphereCollider attackArea;
        /**
         * initialize the tower 
         * call functions to initialize projectile
         **/
        void Start()
        {
            attackArea = gameObject.AddComponent<SphereCollider>();
            towerPosition = transform.position;
            createAttackArea();
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
            }
        }
        void attack()
        {
            //attack currentTarget
        }

        void createAttackArea()
        {
            attackArea.enabled = true;
            attackArea.isTrigger = true;
            attackArea.radius = attackRadius;
        }

        void OnTriggerEnter(Collision col)
        {
            if (col.gameObject.name == "enemy")
            {
                //enemy newEnemy = col.gameObject;
                try
                {
                    targetList.Add(col.gameObject);
                }
                catch (System.Exception e) { }
            }
        }
        void OnTriggerExit(Collision col)
        {
            if (targetList.Contains(col.gameObject))
            {
                targetList.Remove(col.gameObject);
            }
        }
    }
}
