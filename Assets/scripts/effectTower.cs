using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class effectTower : towerBaseClass {

    public delegate void effectToApply(GameObject effectTarget);

    public List<GameObject> enemyInRangeList = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("refreshTarget", 2f, .5f);
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    public override void refreshTarget()
    {

        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag(enemiesTag);

        foreach (GameObject enemy in enemiesArray)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < towerRange)
            {
                enemyInRangeList.Add(enemy);

            }
        }
    }

   virtual public void applyEffect(effectToApply function)
    {
        foreach (GameObject enemy in enemyInRangeList)
        {
            function(enemy);
        }
    }

}
