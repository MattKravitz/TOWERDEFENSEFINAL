using UnityEngine;
using System.Collections;

public class marketHandler : MonoBehaviour {

    [Header("Player Money Attributes")]
    public playerWallet gameWallet;

    [Header("Purchase Handling Variables")]
    int m_userChoice;

    public upgrades[,] upgradesMatrix = new upgrades[5, 5];

    // Use this for initialization
    void Start () {
        gameWallet.setPlayerMoneyTotal(600);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}


