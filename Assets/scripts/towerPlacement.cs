using UnityEngine;
using System.Collections;

public class towerPlacement : MonoBehaviour {

    private Vector3 placement;
    private Vector3 down;
    private int j;
    public Transform automatedTower;
    public static int[] towerCheck = new int[256];

    // Use this for initialization
    void Start () {

	    //0s mean thereis not a tower spawned here, 1 means there is
        placement = this.transform.position;
        for (int i = 0; i < towerCheck.Length; i++)
        {
            towerCheck[i] = 0;
        }
        //---------------------------------------------------------

        
	}
	
	// Update is called once per frame
	void Update () {
	
        


	}

    void OnMouseDown()
    {
        
        for (int i = 0; i < 255; i++)
        {
            if (placement == proceduralGeneration.points[i].position)
            {
                 j = i;
            
            }
        }

        Instantiate(automatedTower, proceduralGeneration.redpoints[j].position + Vector3.up, proceduralGeneration.redpoints[j].rotation);
        towerCheck[j] = 1;

    }
}
