using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Uihandler : MonoBehaviour {

    private float counter;
    private int counter2;
    private int moneyVal;
    private int healthVal;

    public Text time;
    public Text money;
    public Text health;
	// Use this for initialization
	void Start () {
        counter = Time.deltaTime;
        moneyVal = playerWallet.getPlayerMoneyTotal();
        healthVal = ActiveTowerRotate.getHealth();
        
	}
	
	// Update is called once per frame
	void Update () {
        counter = Time.deltaTime + counter;
        counter2 = Mathf.RoundToInt(counter);
        moneyVal = playerWallet.getPlayerMoneyTotal();
        healthVal = ActiveTowerRotate.getHealth();

        time.text = counter2.ToString();
        money.text = string.Concat("$", moneyVal.ToString());
        health.text = healthVal.ToString();
	}
}
