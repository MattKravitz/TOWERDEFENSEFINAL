using UnityEngine;
using System.Collections;

public class towerPlacement : MonoBehaviour {

    private Vector3 placement;
    private Vector3 down;
    private int j;
    public Transform tower;

    // Use this for initialization
    void Start () {
	
        placement = this.transform.position;
        
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

        Instantiate(tower, proceduralGeneration.redpoints[j].position + Vector3.up, proceduralGeneration.redpoints[j].rotation);

    }
}
