using UnityEngine;
using System.Collections;

public class startWave : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void start()
    {
        GameObject.FindGameObjectWithTag("gamemaster").GetComponent<waveSpawner>().setStart();//this starts the wave
        Debug.Log("wave starting...");
    }
}
