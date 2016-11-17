using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Uihandler : MonoBehaviour {

    private float counter;
    private int counter2;
    private int moneyVal;
    private int healthVal;
    private int initialHealth;
    private int waveNumber;

    public Text time;
    public Text money;
    public Text health;
    public Text wave;
	// Use this for initialization
	void Start () {
        counter = Time.deltaTime;
        moneyVal = playerWallet.getPlayerMoneyTotal();
        initialHealth = ActiveTowerRotate.getHealth();

        
	}
	
	// Update is called once per frame
	void Update () {
        waveNumber = waveSpawner.getWave();
        counter = Time.deltaTime + counter;
        counter2 = Mathf.RoundToInt(counter);
        moneyVal = playerWallet.getPlayerMoneyTotal();
        healthVal = ActiveTowerRotate.getHealth();

        time.text = counter2.ToString();
        money.text = string.Concat("$", moneyVal.ToString());
        health.text = string.Concat(healthVal.ToString(), "/" , initialHealth.ToString());
        wave.text = string.Concat("WAVE ", waveNumber.ToString());
	}
}
