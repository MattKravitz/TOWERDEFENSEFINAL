using UnityEngine;
using System.Collections;

public class moneyTower : MonoBehaviour {
    //private GameObject playerWallet;
    private GameObject thisGame;
    private waveSpawner wSpawner;
    private marketHandler pWallet;
    private static float countdown = 10f;
    private float currCoundown = countdown;
    private int moneyValue = 1;
    
    // Use this for initialization
    void Start () {
        thisGame = GameObject.Find("GameMaster");
        wSpawner = thisGame.GetComponentInChildren<waveSpawner>();
        pWallet = thisGame.GetComponentInChildren<marketHandler>();
    }
	
	// Update is called once per frame
	void Update () {
        if(wSpawner.getWaveState() == true)
        {
            if (currCoundown <= 0f)
            {
                pWallet.gameWallet.addMoney(getMoneyValue());
                currCoundown = countdown;
            }
            currCoundown -= Time.deltaTime;//decrement the countdown by time passed
        }
    }
    public int getMoneyValue()
    {
        return moneyValue;
    }
    public void setMoneyValue(int newValue)
    {
        moneyValue = newValue;
    }
}
