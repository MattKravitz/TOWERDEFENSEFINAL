using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class onStartButtonClick : MonoBehaviour
{

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () {
       
	}

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update () {
	
	}

    /// <summary>
    /// Called when [mouse down].
    /// </summary>
    void OnMouseDown()
    {
        waveSpawner.setStart();//this starts the wave
        Debug.Log("wave starting...");
    }
}
