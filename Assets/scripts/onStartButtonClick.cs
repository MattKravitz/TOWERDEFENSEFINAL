﻿using UnityEngine;
using System.Collections;

public class onStartButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnMouseDown()
    {
        waveSpawner.setStart();
        Debug.Log("wave starting...");
    }
}