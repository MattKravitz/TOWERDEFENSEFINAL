using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class laserTower : Assets.scripts.activeTower
{
    public Toggle laser;
    public Toggle laser1;
    public Toggle laser2;
    public Toggle laser3;

    public Toggle gunner;

    public Toggle passive;
    public Toggle passive1;
    public Toggle passive2;
    public Toggle passive3;

    public int tower = 0;
    // Use this for initialization
    /// <summary>
    /// initialize the tower
    /// call function to make the attack area
    /// </summary>
    void Start () {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update () {
        Debug.Log(tower);
	}

    public void whichTower()
    {
        if (laser.isOn) { tower = 0; }
        else if (laser1.isOn) { tower = 1; }
        else if (laser2.isOn) { tower = 2; }
        else if (laser3.isOn) { tower = 3; }
        else if (gunner.isOn) { tower = 4; }
        else if (passive.isOn) { tower = 5; }
        else if (passive1.isOn) { tower = 6; }
        else if (passive2.isOn) { tower = 7; }
        else if (passive3.isOn) { tower = 8; }
        
    }
}
