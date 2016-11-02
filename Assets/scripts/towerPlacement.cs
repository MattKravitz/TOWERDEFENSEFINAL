using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class towerPlacement : MonoBehaviour {

    private Vector3 placement;
    private Vector3 down;
    private int j;
    public Transform tower;
    public Transform stand;
    public static int[] towerCheck = new int[256];

    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start () {

	    //0s mean thereis not a tower spawned here, 1 means there is
        placement = this.transform.position;
        Vector2 temp = new Vector2(placement.x, placement.z);
        for (int i = 0; i < towerCheck.Length; i++)
        {
            towerCheck[i] = 0;
        }
        //---------------------------------------------------------
        //Checks all spots on the game board
        for (int i = 0; i < 255; i++)
        {

            Vector2 temp2 = new Vector2(proceduralGeneration.points[i].position.x, proceduralGeneration.points[i].position.z);
            if (temp == temp2) //If one of the spots is clicked, stores what index it was
            {
                j = i;

            }
        }

    }

    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update () {
	
        


	}


    /// <summary>
    /// Called when [mouse down].
    /// </summary>
    void OnMouseDown()
    {

        if (towerCheck[j] == 0)
        {
            //Fills the spot on the game board with a tower
            Instantiate(tower, proceduralGeneration.redpoints[j].position + Vector3.up, proceduralGeneration.redpoints[j].rotation);
            Instantiate(stand, proceduralGeneration.points[j].position + Vector3.up/10, proceduralGeneration.points[j].rotation);
            towerCheck[j] = 1;
        }
    }
}
