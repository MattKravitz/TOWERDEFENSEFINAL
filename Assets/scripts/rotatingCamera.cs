using UnityEngine;
using System.Collections;

public class rotatingCamera : MonoBehaviour {

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
        transform.RotateAround(Vector3.zero, new Vector3(2, 2, 4), 1f * Time.deltaTime); //Rotates around on a Vector with 2 2 4 as its XYZ coordinates
        transform.LookAt(Vector3.zero);
    }
}
