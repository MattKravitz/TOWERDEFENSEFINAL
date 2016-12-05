using UnityEngine;
using System.Collections.Generic;

public class damageTower : MonoBehaviour {
    private int damage;
    private int damageIncrease = 5;
    //private LineRenderer laser;
    public List<GameObject> towerList = new List<GameObject>();
    private Vector3 towerPosition; //position that the tower is located
    private Vector3 targetPosition; //position of the target tower
    // Use this for initialization
    void Start () {
        towerPosition = transform.position + Vector3.up;
        /**
        laser = GetComponent<LineRenderer>();
        laser.SetWidth(.1f, .1f);
        laser.SetPosition(0, towerPosition);**/
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "activeTower")
        {
            /**LineRenderer newLaser = gameObject.AddComponent<LineRenderer>();
            newLaser = GetComponent<LineRenderer>();
            newLaser.SetWidth(.1f, .1f);
            newLaser.SetPosition(0, towerPosition);**/
            towerList.Add(col.gameObject);
            damage = col.gameObject.GetComponent<tesLaserScript>().getDamage();
            col.gameObject.GetComponent<tesLaserScript>().setDamage(damage + damageIncrease);
            targetPosition = col.gameObject.transform.position;
            //newLaser.SetPosition(1, targetPosition);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
