﻿using UnityEngine;
using System.Collections;

public class onHoverStart : MonoBehaviour {

    Color startColor;
   

	// Use this for initialization
	void Start () {
	    Color startColor = this.gameObject.GetComponent<Renderer>().material.color; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
