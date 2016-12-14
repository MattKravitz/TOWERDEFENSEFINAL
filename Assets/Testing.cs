using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {

    private bool tests_running;
    public GameObject bullet;
    private Vector3 aboutTheCenter;
    public GameObject startTower;
    public GameObject playerWallet;
    
    // Use this for initialization
	void Start () {

        tests_running = false;
        aboutTheCenter = new Vector3(-8, 5, 8);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && !tests_running)
        {
            Debug.Log("Starting tests");
            tests_running = true;
            check_initial_board();
            StartCoroutine(test_enemy_spawn());
            StartCoroutine(bullet_test());

 
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerWallet.GetComponent<playerWallet>().addMoney(100);
        }

    }

    private void check_initial_board()
    {
        if (GameObject.Find("tower(Clone)") != null)
        {
            Debug.Log("Passed: Tower object found");
        }
        else
        {
            Debug.Log("Failed: Tower object not found");
        }

        if (GameObject.Find("START(Clone)") != null)
        {
            Debug.Log("Passed: START TOWER object found");
        }
        else
        {
            Debug.Log("Failed: START TOWER object not found");
        }

        if (GameObject.Find("PlayerShoot(Clone)") != null)
        {
            Debug.Log("Passed: PlayerShoot object found");
        }
        else
        {
            Debug.Log("Failed: PlayerShoot object not found");
        }

        if (GameObject.Find("waypoint(Clone)") != null)
        {
            Debug.Log("Passed: waypoint object found");
        }
        else
        {
            Debug.Log("Failed: waypoint object not found");
        }

        if (GameObject.Find("enemyPath(Clone)") != null)
        {
            Debug.Log("Passed: enemyPath object found");
        }
        else
        {
            Debug.Log("Failed: enemyPath object not found");
        }

        if (GameObject.Find("terrain(Clone)") != null)
        {
            Debug.Log("Passed: terrain object found");
        }
        else
        {
            Debug.Log("Failed: terrain object not found");
        }

        if (GameObject.Find("PlayerWallet") != null)
        {
            Debug.Log("Passed: PlayerWallet object found");
        }
        else
        {
            Debug.Log("Failed: PlayerWallet object not found");
        }

        if (GameObject.Find("Sun") != null)
        {
            Debug.Log("Passed: Sun object found");
        }
        else
        {
            Debug.Log("Failed: Sun object not found");
        }

        if (GameObject.Find("Moon") != null)
        {
            Debug.Log("Passed: Moon object found");
        }
        else
        {
            Debug.Log("Failed: Moon object not found");
        }

        if (GameObject.Find("GameBoardSpawnPoints") != null)
        {
            Debug.Log("Passed: GameBoardSpawnPoints object found");
        }
        else
        {
            Debug.Log("Failed: GameBoardSpawnPoints object not found");
        }

        if (GameObject.Find("2ndLevelSpawns") != null)
        {
            Debug.Log("Passed: 2ndLevelSpawns object found");
        }
        else
        {
            Debug.Log("Failed: 2ndLevelSpawns object not found");
        }

        if (GameObject.Find("Canvas") != null)
        {
            Debug.Log("Passed: Canvas object found");
        }
        else
        {
            Debug.Log("Failed: Canvas object not found");
        }

        if (GameObject.Find("GameMaster") != null)
        {
            Debug.Log("Passed: GameMaster object found");
        }
        else
        {
            Debug.Log("Failed: GameMaster object not found");
        }

    }

    private IEnumerator bullet_test()
    {
        GameObject bullet_clone = (GameObject) Instantiate(bullet, aboutTheCenter, Quaternion.Euler(1, 0, 0));
        yield return new WaitForSeconds(2.0f);
        if (bullet_clone == null)
        {
            Debug.Log("Test Passed: bullet created and destroyed successfully.");
        }
        else
        {
            Debug.Log("Test Failed: bullet created, but not destroyed correctly.");
        }

        yield return new WaitForSeconds(1.0f);
        bullet_clone = (GameObject)Instantiate(bullet, aboutTheCenter, Quaternion.Euler(1, 0, 0));
        bullet_clone.GetComponent<BulletBehavior>().setSpeed(1);
        yield return new WaitForSeconds(0.1f);
        if (bullet_clone.transform.position != aboutTheCenter)
        {
            Debug.Log("Test Passed: bullet created and moved successfully.");
        }
        else
        {
            Debug.Log("Test Failed: bullet created, but did not move when it was supposed to.");
        }
    }

    private IEnumerator test_enemy_spawn()
    {
        startTower.GetComponent<onStartButtonClick>().OnMouseDown();
        yield return new WaitForSeconds(1.0f);
        if (GameObject.Find("enemy(Clone)") != null)
        {
            Debug.Log("Test Passed: wave started successfully by clicking on tower.");
        }
        else
        {
            Debug.Log("Test Failed: wave didn't start by clicking on tower.");
        }

    }

   
}
