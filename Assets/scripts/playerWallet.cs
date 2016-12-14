using UnityEngine;
using System.Collections;

public class playerWallet : MonoBehaviour {

    [Header("Wallet Attributes")]
    public static int m_playerMoneyTotal = 100;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    /// <summary>
    /// Sets the player money total.
    /// </summary>
    /// <param name="newTotal">The new total.</param>
    public void setPlayerMoneyTotal(int newTotal)
    {
        m_playerMoneyTotal = newTotal;
    }
    /// <summary>
    /// Gets the player money total.
    /// </summary>
    /// <returns></returns>
    public static int getPlayerMoneyTotal()
    {
        return m_playerMoneyTotal;
    }
    /// <summary>
    /// Adds the money.
    /// </summary>
    /// <param name="amount">The amount.</param>
    public void addMoney(int amount)
    {
        m_playerMoneyTotal += amount;
    }
    /// <summary>
    /// Subtracts the money.
    /// </summary>
    /// <param name="amount">The amount.</param>
    public static void subtractMoney(int amount)
    {
        m_playerMoneyTotal -= amount;
    }
}
