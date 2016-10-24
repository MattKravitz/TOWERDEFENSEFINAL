using UnityEngine;
using System.Collections;

public class ActiveTowerRotate : MonoBehaviour {

    private Rigidbody body;
    private float speed = 180f;
    private static string inputName = "Horizontal";
    private float inputValue;

    void Awake()
    {
        inputValue = 0f;
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
        
            float turn = inputValue * speed * Time.deltaTime;

            this.transform.Rotate(0f, turn, 0f);
        
        
    }
}
