using UnityEngine;
using System.Collections;

public class ActiveTowerRotate : MonoBehaviour {

    public Transform body;
    public Transform bullet;
    private float speed = 210f;
    private static string inputName = "Horizontal";
    private float inputValue;

    private float turn;

    void Awake()
    {
        inputValue = 0f;
    }
    // Use this for initialization
	void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(bullet, body.position, body.rotation);
        }

        if (Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftArrow))) {

            turn = 5;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && !(Input.GetKey(KeyCode.RightArrow))) {

            turn = -5;
        }
        else
        {
            turn = 0;
        }

        body.Rotate(0, turn, 0);

    }
    
}
