using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boostTower : towerBaseClass {

    public List<GameObject> towersInRangeList = new List<GameObject>();

    public delegate void boostToApply(GameObject towerToBoost);

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("refreshTarget", 2f, .5f);
              
	}

    public override void refreshTarget()
    {
        GameObject[] towersArray = GameObject.FindGameObjectsWithTag(towersTag);
        foreach(GameObject tower in towersArray)
        {
            float towerDistance = Vector3.Distance(transform.position, tower.transform.position);
            if(towerDistance < towerRange)
            {
                towersInRangeList.Add(tower);
            }
        }

    }

    virtual public void applyBoost(boostToApply boost)
    {
        foreach(GameObject tower in towersInRangeList)
        {
            boost(tower);
        }
    }

}
