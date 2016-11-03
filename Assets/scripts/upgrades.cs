using UnityEngine;
using System.Collections;


public class upgrades : MonoBehaviour
{
    private int m_upgradeCost;
    private string m_upgradeName;
    private string m_upgradeScope;

    public int getUpgradeCost()
    {
        return m_upgradeCost;
    }

    public string getUpgradeName()
    {
        return m_upgradeName;
    }

    public string getUpgradeScope()
    {
        return m_upgradeScope;
    }
}
