using UnityEngine;
using System.Collections;
using System;

public class BulletBehavior : MonoBehaviour {

    public Transform bullet;
    private double angle;
    private static float speed = 10f;
    private double x_multiplier;
    private double z_multiplier;
    private Vector3 translater;

	// Use this for initialization
	void Start () {

        x_multiplier = Math.Sin(bullet.eulerAngles.y * Math.PI / 180);
        z_multiplier = Math.Cos(bullet.eulerAngles.y * Math.PI / 180);


    }
	
	// Update is called once per frame
	void Update () {

        translater = 
            Vector3.forward * (float)(speed * z_multiplier * Time.deltaTime)
          + Vector3.right * (float)(speed * x_multiplier * Time.deltaTime);

        bullet.Translate(translater);

    }
}
