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

    public Text tlaser;
    public Text tlaser1;
    public Text tlaser2;
    public Text tlaser3;

    public Text tgunner;

    public Text tpassive;
    public Text tpassive1;
    public Text tpassive2;
    public Text tpassive3;

    public static int cost = 100;

    private static int thisTower;

    public laserTower laserTower
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public damageTower damageTower
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public healthTower healthTower
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public towerPlacement towerPlacement
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (laser.isOn) { thisTower = 0; cost = 100; }
        else if (laser1.isOn) { thisTower = 1; cost = 200; }
        else if (laser2.isOn) { thisTower = 2; cost = 300; }
        else if (laser3.isOn) { thisTower = 3; cost = 400; }

        else if (gunner.isOn) { thisTower = 4; cost = 50; }

        else if (passive.isOn) { thisTower = 5; cost = 200; }
        else if (passive1.isOn) { thisTower = 6; cost = 300; }
        else if (passive2.isOn) { thisTower = 7; cost = 400; }
        else if (passive3.isOn) { thisTower = 8; cost = 500; }

        if(playerWallet.getPlayerMoneyTotal() >= 50)
        {
            tgunner.GetComponent <Text>().color = Color.green;
        }
        else
        {
            tgunner.GetComponent<Text>().color = Color.red;
        }
        if (playerWallet.getPlayerMoneyTotal() >= 100)
        {
            tlaser.GetComponent<Text>().color = Color.green;
        }
        else
        {
            tlaser.GetComponent<Text>().color = Color.red;
        }
        if (playerWallet.getPlayerMoneyTotal() >= 200)
        {
            tlaser1.GetComponent<Text>().color = Color.green;
            tpassive.GetComponent<Text>().color = Color.green;
        }
        else
        {
            tlaser1.GetComponent<Text>().color = Color.red;
            tpassive.GetComponent<Text>().color = Color.red;
        }
        if (playerWallet.getPlayerMoneyTotal() >= 300)
        {
            tlaser2.GetComponent<Text>().color = Color.green;
            tpassive1.GetComponent<Text>().color = Color.green;
        }
        else
        {
            tlaser2.GetComponent<Text>().color = Color.red;
            tpassive1.GetComponent<Text>().color = Color.red;

        }
        if (playerWallet.getPlayerMoneyTotal() >= 400)
        {
            tlaser3.GetComponent<Text>().color = Color.green;
            tpassive2.GetComponent<Text>().color = Color.green;
        }
        else
        {
            tlaser3.GetComponent<Text>().color = Color.red;
            tpassive2.GetComponent<Text>().color = Color.red;
        }
        if (playerWallet.getPlayerMoneyTotal() >= 500)
        {
            tpassive3.GetComponent<Text>().color = Color.green;
        }
        else
        {
            tpassive3.GetComponent<Text>().color = Color.red;
        }

    }


    /// <summary>
    /// Gets the tower.
    /// </summary>
    /// <returns></returns>
    public static int getTower()
    {
        return thisTower;
    }

    /// <summary>
    /// Gets the cost.
    /// </summary>
    /// <returns></returns>
    public static int getCost()
    {
        return cost;
    }
}
