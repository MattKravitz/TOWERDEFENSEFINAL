using UnityEngine;



public class enemy : MonoBehaviour {

    private float speed = 2f;
    private Vector3 target;
    private int wavepointIndex = 0;

    private int health = 0;
    private int moneyValue = 0;
    
 


    void Start()
    {
        //this is just the basic way of how im going to give every enemy its attributes
        target = proceduralGeneration.myWaypointsPositions[0];
        speed = Random.Range(1, 5);
       
        
        if(speed == 1)
        {
            health = 5;
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (speed == 2)
        {
            health = 4;
            
        }
        if (speed == 3)
        {
            health = 3;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
        if (speed == 4)
        {
            health = 2;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    void Update()
    {   
        //This code to traverse through wavepoints was found in a video on youtube by Brackeys-------------------------------
        Vector3 dir = target - this.transform.position;
       
        this.transform.Translate(dir.normalized * speed * .5f * Time.deltaTime , Space.World );
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
    //our getters and setters
    public int getHealth()
    {
        return health;
    }
    public void setHealth(int h)
    {
        health = h;
    }
    public int getMoneyValue()
    {
        return moneyValue;
    }
    public void setMoneyValue(int m)
    {
        moneyValue = m;
    }
    public float getSpeed()
    {
        return speed;
    }
    public void setSpeed(int s)
    {
        speed = s;
    }
}
