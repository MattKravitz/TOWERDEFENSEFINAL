using UnityEngine;
using System.Collections;
using System;

public class BulletBehavior : MonoBehaviour {

    public Transform bullet;
    private double angle;
    private static float speed = 10;
    private double x_multiplier;
    private double z_multiplier;
    private Vector3 translater;

    public Transform player;
    public Transform enemy;

	// Use this for initialization
	void Start () {

        x_multiplier = Mathf.Cos(Mathf.Deg2Rad * bullet.rotation.y);
        z_multiplier = - Mathf.Sin(Mathf.Deg2Rad * bullet.rotation.y);


    }
	
	// Update is called once per frame
	void Update () {
        
        if  (
            bullet.position.x > 10 
            ||
            bullet.position.x < -15 
            ||
            bullet.position.z < -10 
            ||
            bullet.position.z > 25
        )
        {
            Destroy(bullet.gameObject);
        }

        translater = 
            (Vector3.forward * (float)(speed * z_multiplier * Time.deltaTime))
            + 
            (Vector3.right * (float)(speed * x_multiplier * Time.deltaTime));

        bullet.Translate(translater);

    }
}
