using UnityEngine;
using System.Collections.Generic;

public class damageTower : MonoBehaviour {
    private int damage;
    private int damageIncrease = 5;
    private LineRenderer laser;
    public List<GameObject> towerList = new List<GameObject>();
    private Vector3 towerPosition; //position that the tower is located
    private Vector3 targetPosition; //position of the target tower
    private int i;
    private int j = 0;
    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () {
        towerPosition = transform.position;
        
        laser = GetComponent<LineRenderer>();
        laser.SetWidth(.1f, .1f);
        laser.SetPosition(0, towerPosition);
        laser.SetPosition(1, towerPosition);
    }
    /// <summary>
    /// Called when [trigger enter].
    /// </summary>
    /// <param name="col">The col.</param>
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "activeTower")
        {
            /*
            LineRenderer newLaser = gameObject.AddComponent<LineRenderer>();
            newLaser = GetComponent<LineRenderer>();
            newLaser.SetWidth(.1f, .1f);
            newLaser.SetPosition(0, towerPosition);
            */
            towerList.Add(col.gameObject);
            damage = col.gameObject.GetComponent<tesLaserScript>().getDamage();
            col.gameObject.GetComponent<tesLaserScript>().setDamage(damage + damageIncrease);
            targetPosition = col.gameObject.transform.position;
            
            //newLaser.SetPosition(1, targetPosition);
        }
    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update () {
        transform.Rotate(0, 0, 1);

        j++;
        if (j >= 60)
        {
            if (towerList.Count >= 1)
            {
                laser.SetPosition(1, towerList[i].transform.position);
                i++;

            }
            if (i == towerList.Count)
            {
                i = 0;
            }
            j = 0;
        }
	}
}
