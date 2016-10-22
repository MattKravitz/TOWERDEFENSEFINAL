using UnityEngine;
using System.Collections;

public class onHover : MonoBehaviour {
    
    private Vector3 initialPosition;
    private Vector3 endPosition;
    private Vector3 dir;
    private Vector3 dir2;
    
	// Use this for initialization
	void Start () {
        
        initialPosition = this.transform.position;
        endPosition = this.transform.position + Vector3.up * .5f;  
    }
	
    void OnMouseOver()
    {
        if (this.transform.position != endPosition)
        {
            dir2 = endPosition - this.transform.position;
            this.transform.Translate(dir2.normalized * Time.deltaTime * 6f, Space.World);

        }
        if (Vector3.Distance(this.transform.position, endPosition) <= .1f)
        {
            this.transform.position = endPosition;
        }
    }
    void OnMouseExit()
    {
        this.transform.position = initialPosition;
    }
    
    

    
}
