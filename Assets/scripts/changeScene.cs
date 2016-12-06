using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeToGame()
    {
        Application.LoadLevel(1);
    }

    public void changeToStart()
    {
        Application.LoadLevel(0);
    }
}
