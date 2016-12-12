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

    /// <summary>
    /// Gets or sets the player wallet.
    /// </summary>
    /// <value>
    /// The player wallet.
    /// </value>
    /// <exception cref="System.NotImplementedException"></exception>
    public playerWallet playerWallet
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    /// <summary>
    /// Gets or sets the active tower.
    /// </summary>
    /// <value>
    /// The active tower.
    /// </value>
    /// <exception cref="System.NotImplementedException"></exception>
    public Assets.scripts.activeTower activeTower
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    /// <summary>
    /// Gets or sets the wave spawner.
    /// </summary>
    /// <value>
    /// The wave spawner.
    /// </value>
    /// <exception cref="System.NotImplementedException"></exception>
    public waveSpawner waveSpawner
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
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () {
        counter = Time.deltaTime;
        moneyVal = playerWallet.getPlayerMoneyTotal();
        //initialHealth = GameObject.FindGameObjectWithTag("playerTower").GetComponent<ActiveTowerRotate>().getHealth();

    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update () {
        waveNumber = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<waveSpawner>().getWave();
        counter = Time.deltaTime + counter;
        counter2 = Mathf.RoundToInt(counter);
        moneyVal = playerWallet.getPlayerMoneyTotal();
        healthVal = GameObject.FindGameObjectWithTag("playerTower").GetComponent<ActiveTowerRotate>().getHealth();

        time.text = counter2.ToString();
        money.text = string.Concat("$", moneyVal.ToString());
        health.text = string.Concat(healthVal.ToString(), "/" , "100");
        wave.text = string.Concat("WAVE ", waveNumber.ToString());
	}
}
