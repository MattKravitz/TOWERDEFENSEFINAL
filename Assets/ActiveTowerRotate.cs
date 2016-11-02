using UnityEngine;
using System.Collections;

public class ActiveTowerRotate : MonoBehaviour {

    public Transform body; //used to interact with the player-controlled tower
    public Transform bullet; //used to generate projectiles from the bullet prefab
    private float turn; //used to control how fast it's rotating

    public proceduralGeneration proceduralGeneration
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    /// <summary>
    /// Rotates the tower and shoots projectiles based on user input
    /// </summary>
    void Update () {

        //if the user presses the w key, create a bullet with the same rotation as the tower
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            Instantiate(bullet, body.position, body.rotation);
        }

        //if the d key is pressed, rotate right
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.A))) {

            turn = 5;
        }
        //if the a key is pressed, rotate left
        else if(Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.D))) {

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
