using UnityEngine;
using System.Collections;

public class ActiveTowerRotate : MonoBehaviour {

    public Transform body;
    public Transform bullet;
    private float speed = 210f;
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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(bullet, body.position, body.rotation);
        }
        
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
