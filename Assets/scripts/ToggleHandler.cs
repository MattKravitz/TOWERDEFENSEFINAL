using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ToggleHandler : MonoBehaviour {
    public Toggle laser;
    public Toggle laser1;
    public Toggle laser2;
    public Toggle laser3;

    public Toggle gunner;

    public Toggle passive;
    public Toggle passive1;
    public Toggle passive2;
    public Toggle passive3;

    private int thisTower;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void whichTower()
    {
        if (laser.isOn) { thisTower = 0; }
        else if (laser1.isOn) { thisTower = 1; }
        else if (laser2.isOn) { thisTower = 2; }
        else if (laser3.isOn) { thisTower = 3; }

        else if (gunner.isOn) { thisTower = 4; }

        else if (passive.isOn) { thisTower = 5; }
        else if (passive1.isOn) { thisTower = 6; }
        else if (passive2.isOn) { thisTower = 7; }
        else if (passive3.isOn) { thisTower = 8; }
    }

    public int getTower()
    {
        return thisTower;
    }
}
