﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tesLaserScript : MonoBehaviour {
    private LineRenderer laser;
    public List<GameObject> targetList = new List<GameObject>();
    private Vector3 towerPosition; //position that the tower is located
    private Vector3 targetPosition; //position of the primary target
    private GameObject currentTarget;

    public GameObject ballisticsEffect;

    private AudioSource sound;

    private float nextTime = 0;
    private float interval = 1;
    private float counter = 0;
    public int damage = 5;

    private int a = 0;

    // Use this for initialization
    void Start () {
        towerPosition = transform.position + Vector3.up;
        counter = Time.deltaTime;
        sound = gameObject.GetComponent<AudioSource>();

        laser = GetComponent<LineRenderer>();
        laser.SetWidth(.1f, .1f);
        laser.SetPosition(0, towerPosition);
    }
	
	// Update is called once per frame
	void Update () {
        counter = counter + Time.deltaTime;
        
        if(targetList.Count > 0 && a == 0)
        {
            sound.Play();
            a = 1;
        }
        else if(targetList.Count == 0 && a == 1)
        {
            sound.Stop();
            a = 0;
        }




        if (targetList.Count != 0)
        {
            while (currentTarget == null)
            {
                if(targetList.Count == 0)
                {
                    break;
                }
                targetList.Remove(currentTarget);
                setTarget();
            }
            if (targetList.Count != 0)
            {
                //-----this is where its fucking up
                targetPosition = currentTarget.transform.position;
                laser.SetPosition(1, targetPosition);
                transform.Rotate(0, 0, 5);
                if (counter >= nextTime)
                {
                    
                    GameObject ballisticEffect = (GameObject)Instantiate(ballisticsEffect, targetPosition, transform.rotation);
                    currentTarget.GetComponent<enemy>().setHealth(currentTarget.gameObject.GetComponent<enemy>().getHealth() - damage);
                    nextTime += interval;
                    Destroy(ballisticEffect, .5f);
                }
                
            }
        }
        else
        {
            laser.SetPosition(1, towerPosition);
        }
    }

    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "enemy")
        {
            targetList.Add(collide.gameObject);
            setTarget();
            
           
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == "enemy")
        {
            targetList.Remove(collide.gameObject);
            setTarget();
        }
    }

    void setTarget()
    {
        if (targetList.Count != 0)
        {
            currentTarget = targetList[0];
        }
    }
    public int getDamage()
    {
        return damage;
    }
    public void setDamage(int newDamageValue)
    {
        damage = newDamageValue;
    }

}
