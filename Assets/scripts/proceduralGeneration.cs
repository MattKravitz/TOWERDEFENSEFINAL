using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class proceduralGeneration : MonoBehaviour {

    public static Transform[] points;
    public static Transform[] redpoints;
    public static Transform[] waypoints;
    public static int[] enemyPaths;
    public static int[] possibleMoves;

    public Transform gamePiece;
    public Transform spawnPoint;
    public Transform enemyStart;
    public Transform tower;
    public Transform towerHead;
    public Transform secondLevelSpawnPoint;
    public Transform enemyPath;
    public Transform waypoint;
    public List<Transform> myWaypoints = new List<Transform>();
    public List<Vector3> myWaypointsPositions = new List<Vector3>();

    private int start = 0;
    private int currentPosition = 0;
    private int previousPosition = 0;
    private int rand = 0;
    private int meow = 0;
    private int incrementor = 0;

    public lowerLevelSpawns lowerLevelSpawns
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public waveSpawner waveSpawner
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
    /// Starts this instance.
    /// </summary>
    void Start()
    {
        //create an array that stores all the spawnpoints(hidden green diamonds) for our gamepieces
        //create an array that stores whether or not a position is an enemy path or not by using 1s and 0s
        //create an array that stores the red spawnpoints
        enemyPaths = new int[256];
        points = new Transform[spawnPoint.childCount];
        redpoints = new Transform[spawnPoint.childCount];

        for (int i = 0; i < enemyPaths.Length; i++)
        {
            enemyPaths[i] = 0;
        }

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = spawnPoint.GetChild(i);
        }
        for (int i = 0; i < redpoints.Length; i++)
        {
            redpoints[i] = secondLevelSpawnPoint.GetChild(i);
        }

        //set the start position from the enemy spawn point
        //----------------------------------------------------------------------------------------------
        enemyPaths[18] = 1;
        Instantiate(enemyPath, points[18].position, points[18].rotation);
        currentPosition = 18;
        addWaypoint(currentPosition);

        //set start and end point

        Instantiate(enemyStart, points[17].position, points[17].rotation);
        Instantiate(tower, points[238].position+Vector3.up, points[238].rotation);
        Instantiate(towerHead, points[238].position+3*Vector3.up, points[238].rotation);

        //----------------------------------------------------------------------------------------------

        algorithm();

        //fill in the enemy positions
        //----------------------------------------------------------------------------------------------
        
        for (int i = 0; i < enemyPaths.Length; i++)
        {
            enemyPaths[238] = 1;
            enemyPaths[17] = 1;

            if (enemyPaths[i] == 1)
            {
                Instantiate(enemyPath, points[i].position, points[i].rotation);
            }

        }
        addWaypoint(238);
        //----------------------------------------------------------------------------------------------


        //fill in the rest of the defense tower positions
        //----------------------------------------------------------------------------------------------
        for (int i = 0; i < points.Length; i++)
        {
            if (enemyPaths[i] == 0)
            {
                spawnTowerSpace(i);
            }

        }
        Debug.Log(myWaypoints.Count);
        //----------------------------------------------------------------------------------------------
        
    }

    /// <summary>
    /// Algorithms this instance.
    /// </summary>
    void algorithm()
    {
        //meow means you got to the end
        while(meow == 0 )
        {
            //we move right first
            moveRight();
            
            
            //move left second if we can
            if (enemyPaths[237] != 1 || enemyPaths[222] != 1 || enemyPaths[254] != 1 || enemyPaths[239] != 1 )
            {
                if (currentPosition <= 223)
                {
                    moveLeft();
                }
            }
           
            //then we end it if we get to the player tower
            if (enemyPaths[237] == 1 || enemyPaths[222] == 1 || enemyPaths[254] == 1 || enemyPaths[239] ==1 )
            {
                meow = 1;
            }
        }

    }

    /// <summary>
    /// Moves the right.
    /// </summary>
    void moveRight()//this is all the code for moving right in the algoithm
    {
        rand = 0;
        rand = Random.Range(1, 7);
        while (rand != 1 && currentPosition % 16 !=15 && currentPosition != 237)
        {
            enemyPaths[currentPosition + 1] = 1;
            currentPosition = currentPosition + 1;
            addWaypoint(currentPosition);
            rand = Random.Range(1, 8);

        }
        if (currentPosition <= 223)
        {
            enemyPaths[currentPosition + 16] = 1;
            currentPosition = currentPosition + 16;
            addWaypoint(currentPosition);
            if (currentPosition <= 208)
            {
                enemyPaths[currentPosition + 16] = 1;
                currentPosition = currentPosition + 16;
                addWaypoint(currentPosition);
            }
        }
    }
    /// <summary>
    /// Moves the left.
    /// </summary>
    void moveLeft()//all the code for moving left in the algorithm
    {
        rand = 0;
        rand = Random.Range(1, 6);
        while (rand != 1 && currentPosition % 16 != 0)
        {
            enemyPaths[currentPosition - 1] = 1;
            currentPosition = currentPosition - 1;
            addWaypoint(currentPosition);
            //Debug.Log(currentPosition);
            rand = Random.Range(1, 8);

        }
        if (currentPosition <= 223)
        {

            enemyPaths[currentPosition + 16] = 1;
            addWaypoint(currentPosition +16);
            enemyPaths[currentPosition + 32] = 1;
            currentPosition = currentPosition + 32;
            addWaypoint(currentPosition);
        }
        
    }
    /// <summary>
    /// Adds the waypoint.
    /// </summary>
    /// <param name="currentPosition">The current position.</param>
    void addWaypoint(int currentPosition)//this how we add a waypoint to the map that the enemies follow
    {
        
        Instantiate(this.waypoint, redpoints[currentPosition].position, redpoints[currentPosition].rotation);
        myWaypoints.Add(this.waypoint);
        myWaypointsPositions.Add(redpoints[currentPosition].position);
    }
    /// <summary>
    /// Spawns the tower space.
    /// </summary>
    /// <param name="i">The i.</param>
    void spawnTowerSpace(int i)//this is how we get the different height terrain tiles on the mao
    {
        int rand2 = Random.Range(1, 11);
        Instantiate(gamePiece, points[i].position+Vector3.up*rand2/40, points[i].rotation);
    }
}
