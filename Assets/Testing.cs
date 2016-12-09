using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {

    private bool tests_running;
    public GameObject bullet;
    private Vector3 aboutTheCenter;
    
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

            StartCoroutine(bullet_test());

            
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

   
}
