using UnityEngine;
using System.Collections;

public class isGameOver : MonoBehaviour {

    private int Health;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    Health = ActiveTowerRotate.getHealth();

        if(Health < 1)
        {
            Application.LoadLevel(2); 
        }
    }

    public void checkHealth()
    {
    
    }
}
