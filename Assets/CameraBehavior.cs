using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBehavior : MonoBehaviour {

    public Transform CameraGroup;
    public Transform[] Cameras;

    private static string inputName = "Camera";
    private float inputValue;

    private int current_camera;

    public void Awake()
    {
        current_camera = 0;

        Cameras = new Transform[CameraGroup.childCount];

        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i] = CameraGroup.GetChild(i);
        }

        EnableCamera();


    }

    // Use this for initialization
    public void Start () {
        
    }
	
	// Update is called once per frame
	public void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(current_camera > 2)
            {
                current_camera = 0;
            }
            else
            {
                current_camera += 1;
            }
            EnableCamera();
        }
        else if (Input.GetKeyDown(KeyCode.D))
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
            Debug.Log(current_camera);
        }

        
    }

    public void EnableCamera()
    {

        foreach (Transform camera in Cameras){
            camera.gameObject.SetActive(false);
        }

        Cameras[current_camera].gameObject.SetActive(true);
    }


    
}
