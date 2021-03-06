﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    public class activeTower : MonoBehaviour
    {

        private LineRenderer laser;

        public float shotSpeed = 1; //fire rate of the tower
        //TODO: add a projectile object that takes in the tower damage
        public float baseDamage = 1; //the base damage a tower deals 
        private float attackRadius = 2f; //distance the tower can attack 
        private int m_health = 100;//health of player tower
        private GameObject currentTarget; //the primary target of the tower
        private List<GameObject> targetList = new List<GameObject>(); //a list of enemies in the attack radius
        private Vector3 towerPosition; //position that the tower is located
        private Vector3 targetPosition; //position of the primary target
        private Vector3 attackDirection; //a vector between the tower and its' target
        private SphereCollider attackArea;
        int count;

        /// <summary>
        /// Gets or sets the bullet behavior.
        /// </summary>
        /// <value>
        /// The bullet behavior.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public BulletBehavior BulletBehavior
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the player shoot.
        /// </summary>
        /// <value>
        /// The player shoot.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public PlayerShoot PlayerShoot
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the active tower rotate.
        /// </summary>
        /// <value>
        /// The active tower rotate.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public ActiveTowerRotate ActiveTowerRotate
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// initialize the tower
        /// call function to make the attack area
        /// </summary>
        void Start()
        {
            attackArea = gameObject.AddComponent<SphereCollider>();
            towerPosition = transform.position+Vector3.up;
            createAttackArea();
            Debug.Log("Tower Placed");

            laser = GetComponent<LineRenderer>();
            laser.SetWidth(.1f, .1f);
            laser.SetPosition(0, towerPosition);
        }
        /// <summary>
        /// set the primary target of the tower
        /// </summary>
        void setTarget()
        {
            if (targetList.Count != 0)
            {
                currentTarget = targetList[0];
                Debug.Log("Primary target set");
            }
        }
        /// <summary>
        /// have the tower attack its' primary target
        /// </summary>
        void attack()
        {
            targetPosition = currentTarget.transform.position;
            attackDirection = targetPosition + towerPosition;
        }
        /// <summary>
        /// add a trigger with the size of the tower's attack radius
        /// </summary>
        void createAttackArea()
        {
            attackArea.enabled = true;
            attackArea.isTrigger = true;
            attackArea.radius = attackRadius;
        }
        /// <summary>
        /// when enemy enters the attack area then add to the enemy list
        /// </summary>
        /// <param name="col">used to retrieve the game object</param>
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "enemy")
            {

                try
                {
                    targetList.Add(col.gameObject);
                    Debug.Log("new target added to list");
                    if (currentTarget == null)
                    {
                        setTarget();
                    }
                }
                catch (System.Exception e) { }
            }
        }
        /// <summary>
        /// remove enemy from list when exiting attack radius
        /// </summary>
        /// <param name="col">collider to interact with game object</param>
        void OnTriggerExit(Collider col)
        {
            if (targetList.Contains(col.gameObject))
            {
                targetList.Remove(col.gameObject);
                Debug.Log("Target removed from list");
                setTarget();
            }
        }
        /// <summary>
        /// Updates this instance.
        /// </summary>
        void Update()
        {
            if(targetList.Count != 0)
            {
                targetPosition = currentTarget.transform.position;
                laser.SetPosition(1, targetPosition);
            }
            else
            {
                laser.SetPosition(1, towerPosition);
            }
        }



        
    }
}
