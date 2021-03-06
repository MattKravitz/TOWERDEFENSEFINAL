﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class onHover : MonoBehaviour {
    
    private Vector3 initialPosition;
    private Vector3 endPosition;
    private Vector3 dir;
    private Vector3 dir2;
    private int j = 0;
    private int a = 0;

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () {

        initialPosition = this.transform.position;
        endPosition = this.transform.position + Vector3.up * .5f;

        //this is just to find the index at which this object is with respect to our spawn arrays
        for (int i = 0; i < 255; i++)
        {
            if (initialPosition == proceduralGeneration.points[i].position)
            {
                j = i;
            }
        }
        //----------------------------------------------------------------------------------------

    }

    /// <summary>
    /// Called when [mouse over].
    /// </summary>
    void OnMouseOver()
    {
        if (a == 0)
        {
            this.transform.GetComponent<AudioSource>().Play();
            a = 1;
        }
        //if there isnt a tower at this position, then exectute this onmousedown
        if (this.gameObject.GetComponent<towerPlacement>().towerCheck[j] != 1)
        {
            if (this.transform.position != endPosition)
            {
                dir2 = endPosition - this.transform.position;
                this.transform.Translate(dir2.normalized * Time.deltaTime * 5f, Space.World);

            }
            if (Vector3.Distance(this.transform.position, endPosition) <= .1f)
            {
                this.transform.position = endPosition;
               
            }
        }
    }
    /// <summary>
    /// Called when [mouse exit].
    /// </summary>
    void OnMouseExit()
    {
        this.transform.position = initialPosition;
        a = 0;
    }
    
    

    
}
