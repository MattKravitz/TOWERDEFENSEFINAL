using UnityEngine;
using System.Collections;

public class lowerLevelSpawns : MonoBehaviour {

    public static Transform[] points;
    public static int[] enemyPaths;
    public static int[] possibleMoves;

    public Transform gamePiece;
    public Transform spawnPoint;
    public Transform enemyStart;
    public Transform tower;
    public Transform enemyPath;

    private int start = 0;
    private int finished = 0;
    private int currentPosition = 0;
    private int previousPosition = 0;
    private int pickDir = 0;
    private int meow = 0;

    void Start()
    {   
        //create an array that stores all the spawnpoints(hidden green diamonds) for our gamepieces
        //create an array that stores whether or not a position is an enemy path or not by using 1s and 0s
        enemyPaths = new int[256];
        points = new Transform[spawnPoint.childCount];

        for (int i = 0; i < enemyPaths.Length; i++)
        {
            enemyPaths[i] = 0;
        }

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = spawnPoint.GetChild(i);
        }

        

        //pick a random number between 1 and 4
        start = Random.Range(1, 5);

        //set the start position from the enemy spawn point
        //----------------------------------------------------------------------------------------------
        if (start == 1)
        {
            enemyPaths[1] = 1;
            Instantiate(enemyPath, points[1].position, points[1].rotation);
            currentPosition = 1;
        }

        else if (start == 2)
        {
            enemyPaths[18] = 1;
            Instantiate(enemyPath, points[18].position, points[18].rotation);
            currentPosition = 18;
        }

        else if (start == 3)
        {
            enemyPaths[33] = 1;
            Instantiate(enemyPath, points[33].position, points[33].rotation);
            currentPosition = 33;
        }

        else
        {
            enemyPaths[16] = 1;
            Instantiate(enemyPath, points[16].position, points[16].rotation);
            currentPosition = 16;
        }

        //set start and end point
       
        Instantiate(enemyStart, points[17].position, points[17].rotation);
        
        Instantiate(tower, points[238].position, points[238].rotation);
        
        //----------------------------------------------------------------------------------------------

        algorthm(currentPosition);

        //fill in the enemy positions
        //----------------------------------------------------------------------------------------------
        for (int i = 0; i < enemyPaths.Length; i++)
        {
            if (enemyPaths[i] == 1)
            {
                Instantiate(enemyPath, points[i].position, points[i].rotation);
            }

        }
        //----------------------------------------------------------------------------------------------


        //fill in the rest of the defense tower positions
        //----------------------------------------------------------------------------------------------
        for (int i = 0; i < points.Length; i++)
        {
            if (enemyPaths[i]==0)
            {
                Instantiate(gamePiece, points[i].position , points[i].rotation);
            }

        }
        //----------------------------------------------------------------------------------------------

    }
    void algorthm(int currentPosition)
    {
        
        while(meow <= 25)
        {
           

            checkNextMove(currentPosition);

            

            pickDir = Random.Range(1, 5);

            switch (pickDir)
            {
                case 1:
                    if(possibleMoves[2] == 1)
                    {
                        currentPosition = currentPosition + 1;
                    }
                    else if (possibleMoves[3] == 1)
                    {
                        currentPosition = currentPosition + 16;
                    }
                    else if (possibleMoves[0] == 1)
                    {
                        currentPosition = currentPosition - 1;
                    }
                    else if (possibleMoves[1] == 1)
                    {
                        currentPosition = currentPosition - 16;
                    }
                    break;
                case 2:
                    if (possibleMoves[1] == 1)
                    {
                        currentPosition = currentPosition - 16;
                    }
                    else if (possibleMoves[2] == 1)
                    {
                        currentPosition = currentPosition + 1;
                    }
                    else if (possibleMoves[3] == 1)
                    {
                        currentPosition = currentPosition + 16;
                    }
                    else if (possibleMoves[0] == 1)
                    {
                        currentPosition = currentPosition - 1;
                    }
                    
                    break;
                case 3:
                    if (possibleMoves[0] == 1)
                    {
                        currentPosition = currentPosition - 1;
                    }
                    else if (possibleMoves[1] == 1)
                    {
                        currentPosition = currentPosition - 16;
                    }
                    else if (possibleMoves[2] == 1)
                    {
                        currentPosition = currentPosition + 1;
                    }
                    else if (possibleMoves[3] == 1)
                    {
                        currentPosition = currentPosition + 16;
                    }
                    

                    break;
                case 4:
                    if (possibleMoves[3] == 1)
                    {
                        currentPosition = currentPosition + 16;
                    }
                    else if (possibleMoves[0] == 1)
                    {
                        currentPosition = currentPosition - 1;
                    }
                    else if (possibleMoves[1] == 1)
                    {
                        currentPosition = currentPosition - 16;
                    }
                    else if (possibleMoves[2] == 1)
                    {
                        currentPosition = currentPosition + 1;
                    }
                  

                    break;
            }

            enemyPaths[currentPosition] = 1;

            //previousPosition = currentPosition;


            Debug.Log(currentPosition);
            meow++;

            /*
            if(enemyPaths[237] == 1 || enemyPaths[222] == 1 || enemyPaths[254] == 1 || enemyPaths[239] == 1)
            {
                finished = 1;
            }
            */
        }

    }

    void checkNextMove(int currentPosition)
    {

        //creates a possible moves array for each current position
        //index 0 for left move, 1 for up move, 2 for right move, and 3 for down move
        possibleMoves = new int[4];
        for (int i = 0; i < 4; i++)
        {
            possibleMoves[i] = 0;
        }

        //for left turn
        if (currentPosition % 16 == 0 || enemyPaths[currentPosition - 1] == (1) || currentPosition == 18)
        {
            possibleMoves[0] = 0;

        }
        else
        {

            possibleMoves[0] = 1;
        }
        //for up turn
        if (currentPosition <= 15 || currentPosition == 33 || enemyPaths[currentPosition - 16] == (1))
        {
            possibleMoves[1] = 0;

        }
        else
        {
            possibleMoves[1] = 1;

        }
        //for right turn
        if (currentPosition % 16 == 15 || currentPosition == 16 || enemyPaths[currentPosition + 1] == (1))
        {
            possibleMoves[2] = 0;

        }
        else
        {
            possibleMoves[2] = 1;

        }
        //for down turn
        if (currentPosition >= 240 || currentPosition == 1 || enemyPaths[currentPosition + 16] == (1))
        {
            possibleMoves[3] = 0;
        }
        else
        {
            possibleMoves[3] = 1;
        }

    }


}
