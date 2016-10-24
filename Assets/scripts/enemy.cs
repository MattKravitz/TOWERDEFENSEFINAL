using UnityEngine;



public class enemy : MonoBehaviour {

    private float speed = 2f;
    private Vector3 target;
    private int wavepointIndex = 0;
    private int health = 0;
 


    void Start()
    {
        //this is just the basic way of how im going to give every enemy its attributes
        target = proceduralGeneration.myWaypointsPositions[0];
        speed = Random.Range(1, 5);
        health = 2;
        if(speed == 4)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if(speed == 1)
        {
            health = 5;
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
       
    }
    void Update()
    {   
        //This code to traverse through wavepoints was found in a video on youtube by Brackeys-------------------------------
        Vector3 dir = target - this.transform.position;
       
        this.transform.Translate(dir.normalized * speed * Time.deltaTime , Space.World );
        if(Vector3.Distance(this.transform.position, target) <= .2f)
        {
            GetNextWaypoint();
            
        }
        //------------------------------------------------------------------------------------

    }
    void GetNextWaypoint()
    {
        //The basic if statement to destroy the gameobject and the wavepoint incrementation was found in a video on youtube by Brackeys-------------------------------
        if (wavepointIndex >= proceduralGeneration.myWaypoints.Count - 1)
        {
            Destroy(this.gameObject);
            return;
        }
        wavepointIndex++;
        target = proceduralGeneration.myWaypointsPositions[wavepointIndex];
       
        //------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
