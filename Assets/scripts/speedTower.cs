using UnityEngine;
using System.Collections.Generic;

public class speedTower : MonoBehaviour {
    private Vector3 towerPosition; //position that the tower is located
    private float targetSpeed;
    private enemy target;
    // Use this for initialization
    void Start () {
        towerPosition = transform.position + Vector3.up;
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 1);
	}
    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "enemy")
        {
            Debug.Log("Enemy Slowed");
            target = collide.gameObject.GetComponent<enemy>();
            targetSpeed = target.getSpeed();
            targetSpeed = targetSpeed * .5f;
            target.setSpeed(targetSpeed);
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == "enemy")
        {
            Debug.Log("Enemy Speed Restored");
            target = collide.gameObject.GetComponent<enemy>();
            targetSpeed = target.getSpeed();
            targetSpeed = ((targetSpeed) * 2);
            target.setSpeed(targetSpeed);
        }
    }
}
