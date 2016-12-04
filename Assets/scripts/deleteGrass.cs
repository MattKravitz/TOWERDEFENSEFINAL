using UnityEngine;
using System.Collections;

public class deleteGrass : MonoBehaviour {
    private int j = 0;

	// Use this for initialization
	void Start () {
        Vector3 placement = this.transform.position;
        Vector2 temp = new Vector2(placement.x, placement.z);

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
	void Update () {
        
    }
    void OnMouseDown()
    {
        if (this.gameObject.GetComponent<towerPlacement>().towerCheck[j] == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
