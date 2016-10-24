using UnityEngine;
using System.Collections;

public class sun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(Vector3.zero, new Vector3(2, 2, 4), 1f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
	}
}
