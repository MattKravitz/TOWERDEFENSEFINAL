using UnityEngine;
using System.Collections;

public class ActiveTowerRotate : MonoBehaviour {

    private Rigidbody body;
    private float speed = 10f;
    private static string inputName = "Horizontal";
    private float inputValue;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        inputValue = 0f;
        body.isKinematic = false;
    }
    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        inputValue = Input.GetAxis(inputName);
        
	}

    private void FixedUpdate()
    {
        Turn();
    }

    private void Turn()
    {
        if(inputValue != 0)
        {
            float turn = speed * Time.deltaTime;

            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f); //Turns the tower around the y-axis

            body.MoveRotation(body.rotation * turnRotation);
        }
        
    }
}
