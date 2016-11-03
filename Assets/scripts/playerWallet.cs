using UnityEngine;
using System.Collections;

public class playerWallet : MonoBehaviour {

    [Header("Wallet Attributes")]
    public int m_playerMoneyTotal = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void setPlayerMoneyTotal(int newTotal)
    {
        m_playerMoneyTotal = newTotal;
    }
    public int getPlayerMoneyTotal()
    {
        return m_playerMoneyTotal;
    }
}
