using UnityEngine;
using System.Collections;

public class onHover : MonoBehaviour {

    private bool meow;
	// Use this for initialization
	void Start () {
        meow = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (meow == false)
        {
            GetComponent<Renderer>().material.color = new Color(255, 255, 255);
           

        }
        else
        {
            meow = false;
        }
    }

    void OnMouseOver()
    {

        Debug.Log("mewo");
        GetComponent<Renderer>().material.color = new Color(0, 0, 255);
        meow = true;


    }
}
