using UnityEngine;
using System.Collections;

public class damageTower : MonoBehaviour {
    private int damage;
    private int damageIncrease = 5;
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        damage = col.gameObject.GetComponent<tesLaserScript>().getDamage();
        col.gameObject.GetComponent<tesLaserScript>().setDamage(damage+damageIncrease);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
