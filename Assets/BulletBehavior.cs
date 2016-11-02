using UnityEngine;
using System.Collections;
using System;

public class BulletBehavior : MonoBehaviour {

    public Transform bullet; //the transform that is moving
    private static float speed = 10; //the speed at which the object travels

    //These control how much to move in x and z directions based on the angle of the bullet
    private double x_multiplier;
    private double z_multiplier;

    private Vector3 translater; //used to translate the object

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

    public Assets.scripts.activeTower activeTower
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
    /// Initialize the ratio between movement in x and z directions based on angle
    /// </summary>
    void Start () {

        x_multiplier = Mathf.Cos(Mathf.Deg2Rad * bullet.rotation.y);
        z_multiplier = - Mathf.Sin(Mathf.Deg2Rad * bullet.rotation.y);
    }

    /// <summary>
    ///  Update is called once per frame, controls translation of the bullet
    /// </summary>
    void Update () {
        
        //Deletes the bullet if it goes outside of the boundary
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

        //used to move the bullet along the angle based on speed variable
        translater = 
            (Vector3.forward * (float)(speed * z_multiplier * Time.deltaTime))
            + 
            (Vector3.right * (float)(speed * x_multiplier * Time.deltaTime));

        bullet.Translate(translater);
    }
}
