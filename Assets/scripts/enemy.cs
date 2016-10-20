using UnityEngine;



public class enemy : MonoBehaviour {

    public float speed = .2f;
    private Vector3 target;
    private int wavepointIndex = 0;
 


    void Start()
    {
        target = proceduralGeneration.myWaypointsPositions[0];
       
    }
    void Update()
    {   

        Vector3 dir = target - this.transform.position;
       
        this.transform.Translate(dir.normalized * speed * Time.deltaTime , Space.World );
        if(Vector3.Distance(this.transform.position, target) <= .2f)
        {
            GetNextWaypoint();
            Debug.Log("gsfdgsfg");
        }
        

    }
    void GetNextWaypoint()
    {
        if(wavepointIndex >= proceduralGeneration.myWaypoints.Count - 1)
        {
            Destroy(this.gameObject);
            return;
        }
        wavepointIndex++;
        target = proceduralGeneration.myWaypointsPositions[wavepointIndex];
        Debug.Log(wavepointIndex);
    }
}
