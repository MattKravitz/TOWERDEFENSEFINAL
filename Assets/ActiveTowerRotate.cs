using UnityEngine;
using System.Collections;

public class ActiveTowerRotate : MonoBehaviour {

    public Transform body; //used to interact with the player-controlled tower
    public Transform bullet; //used to generate projectiles from the bullet prefab
    private float turn; //used to control how fast it's rotating
	
    /// <summary>
    /// Rotates the tower and shoots projectiles based on user input
    /// </summary>
	void Update () {

        //if the user presses the up key, create a bullet with the same rotation as the tower
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            Instantiate(bullet, body.position, body.rotation);
        }

        //if the right arrow is pressed, rotate right
        if (Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftArrow))) {

            turn = 5;
        }
        //if the left arrow is pressed, rotate left
        else if(Input.GetKey(KeyCode.LeftArrow) && !(Input.GetKey(KeyCode.RightArrow))) {

            turn = -5;
        }
        //otherwise, don't rotate
        else
        {
            turn = 0;
        }
        //rotate by the turn factor
        body.Rotate(0, turn, 0);

    }
    
}
