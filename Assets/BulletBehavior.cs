using UnityEngine;
using System.Collections;
using System;

public class BulletBehavior : MonoBehaviour {

    public Transform bullet; //the transform that is moving
    private static float speed = 2.5f; //the speed at which the object travels

    //These control how much to move in x and z directions based on the angle of the bullet
    private float x_multiplier;
    private float z_multiplier;
    private float startTime;
    private Vector3 translater; //used to translate the object
    private Vector3 original;

    /// <summary>
    /// Initialize the ratio between movement in x and z directions based on angle
    /// </summary>
    void Start () {

        x_multiplier = Mathf.Cos(Mathf.Deg2Rad * bullet.eulerAngles.y);
        z_multiplier = - Mathf.Sin(Mathf.Deg2Rad * bullet.eulerAngles.y);

        Vector3 original = bullet.position;

        startTime = Time.time;

    }

    /// <summary>
    ///  Update is called once per frame, controls translation of the bullet
    /// </summary>
    void Update () {
        
        //Deletes the bullet if it goes outside of the boundary
        if(bullet.position.y < 2)
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
        float v_vertical = Mathf.Sin(Mathf.Deg2Rad * bullet.eulerAngles.z) * speed;
        float v_horizontal = Mathf.Cos(Mathf.Deg2Rad * bullet.eulerAngles.z) * speed;
   
        //Debug.Log("horizontal component: "+v_horizontal);
        //Debug.Log("vertical component: " + v_vertical);

        translater =
            new Vector3(
               (v_horizontal * x_multiplier * timeIncrement)
               ,((v_vertical * timeIncrement) + (-4.9f * timeIncrement * timeIncrement))
               ,(v_horizontal * z_multiplier * timeIncrement) );

        bullet.Translate(translater, Space.World);
        
    }

    private bool HitGround()
    {
        int layerMask = (1 << 8);
        Collider[] hitColliders = Physics.OverlapSphere(bullet.transform.position, 3,layerMask);

        Debug.Log("Enemies hit: " + hitColliders.Length);

        Destroy(bullet.gameObject);

        for(int i=0; i < hitColliders.Length; i++)
        {
            hitColliders[i].gameObject.GetComponent<enemy>().attackEnemy(20);
        }

        return true;
    }
    
}
