using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts
{
    class activeTower : MonoBehaviour
    {
        public float shotSpeed = 1; //fire rate of the tower
        //TODO: add a projectile object that takes in the tower damage
        public float baseDamage = 1; //the base damage a tower deals 
        private enemy currentTarget;
        private List<enemy> targetList = new List<enemy>(); //a list of enemies in the attack radius

        /**
         * initialize the tower 
         * call functions to initialize projectile
         **/
        void placeTower()
        {

        }
        /**
         * set the target of a tower to the first element in the target list
         * TODO: add ability to attack the first, last, strongest, or weakest enemy
         **/
        void setTarget()
        {
            if (targetList.Count!=0)
            {
                currentTarget = targetList[0];
            }
        }
        void attack()
        {
            //attack currentTarget
        }
    }
}
