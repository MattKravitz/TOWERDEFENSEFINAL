using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour
{

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
    {

    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update () {
	
	}

    /// <summary>
    /// Changes to game.
    /// </summary>
    public void changeToGame()
    {
        Application.LoadLevel(1);
    }

    /// <summary>
    /// Changes to start.
    /// </summary>
    public void changeToStart()
    {
        Application.LoadLevel(0);
    }
}
