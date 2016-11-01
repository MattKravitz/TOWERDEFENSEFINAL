using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBehavior : MonoBehaviour {

    public Transform CameraGroup; //Game object that contains the 4 cameras
    public Transform[] Cameras; //used to store the 4 cameras in CameraGroup

    private int current_camera; //used to designate the active camera

    /// <summary>
    /// Initializes the cameras
    /// </summary>
    public void Awake() 
    {
        current_camera = 0;

        Cameras = new Transform[CameraGroup.childCount];

        //store the cameras in the CameraGroup in this array
        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i] = CameraGroup.GetChild(i);
        }

        EnableCamera(); //enables the current camera
    }
	
	/// <summary>
    /// Used to keep track of user input
    /// </summary>
	public void Update () {

        if (Input.GetKeyDown(KeyCode.Q)) //if the q key is pressed, increment current_camera
        {
            if (current_camera > 2) //make sure it is a valid index
            {
                current_camera = 0;
            }
            else
            {
                current_camera += 1;
            }
            EnableCamera(); //enable camera
        }
        else if (Input.GetKeyDown(KeyCode.E)) //if the e key is pressed, increment downwards
        {
            if (current_camera < 1)
            {
                current_camera = 3;
            }
            else
            {
                current_camera -= 1;
            }
            EnableCamera();
        }
    }

    /// <summary>
    ///  Used to enable the camera at index current_camera
    /// </summary>
    public void EnableCamera()
    {
        foreach (Transform camera in Cameras){ //disable all cameras
            camera.gameObject.SetActive(false);
        }
        Cameras[current_camera].gameObject.SetActive(true); //enable the active camera
    }


    
}
