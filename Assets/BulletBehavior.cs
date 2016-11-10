using UnityEngine;
using System.Collections;
using System;

public class BulletBehavior : MonoBehaviour {

    public Transform bullet; //the transform that is moving
    private static float speed = 1f; //the speed at which the object travels

    //These control how much to move in x and z directions based on the angle of the bullet
    private double x_multiplier;
    private double z_multiplier;
    private float startTime;
    private Vector3 translater; //used to translate the object
    private Vector3 original;

    /// <summary>
    /// Initialize the ratio between movement in x and z directions based on angle
    /// </summary>
    void Start () {

        x_multiplier = Mathf.Cos(Mathf.Deg2Rad * bullet.rotation.y);
        z_multiplier = - Mathf.Sin(Mathf.Deg2Rad * bullet.rotation.y);

        Vector3 original = bullet.position;

        startTime = Time.time;

    }

    /// <summary>
    ///  Update is called once per frame, controls translation of the bullet
    /// </summary>
    void Update () {
        
        //Deletes the bullet if it goes outside of the boundary
        if(bullet.position.y < 3)
        {
            HitGround();
        }
        else if  (
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

        
    }

    public void FixedUpdate()
    {

        //used to move the bullet along the angle based on speed variable
        float timeIncrement = Time.time - startTime;
        //float v_vertical = Mathf.Sin(Mathf.Deg2Rad * bullet.eulerAngles.z) * speed;
        //float v_horizontal = Mathf.Cos(Mathf.Deg2Rad * bullet.eulerAngles.z) * speed;

        //float v_horizontal = speed * Mathf.Cos(bullet.eulerAngles.x);
        translater =
            (Vector3.forward * speed * (float)(z_multiplier * timeIncrement))
            +
            (Vector3.right * speed * (float)(x_multiplier * timeIncrement)
            +
            (Vector3.up * ( (speed * timeIncrement) + (-4.9f * timeIncrement * timeIncrement) ) ));

        bullet.Translate(translater);
        
    }

    private bool HitGround()
    {
        int layerMask = (1 << 8);
        Collider[] hitColliders = Physics.OverlapSphere(bullet.transform.position, 2,layerMask);

        Debug.Log(hitColliders.Length);

        Destroy(bullet.gameObject);

        //TODO: Detect all objects within radius and apply damage

        return true;
    }
    
}
