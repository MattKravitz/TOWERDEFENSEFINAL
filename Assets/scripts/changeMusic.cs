using UnityEngine;
using System.Collections;

public class changeMusic : MonoBehaviour {

    public AudioClip slow;
    public AudioClip fast;
    private AudioSource sound;
    private int a = 0;

	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();
        sound.clip = slow;
        sound.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(GameObject.FindGameObjectWithTag("enemy") == null && a ==0)
        {
            a = 1;
            sound.Stop();
            sound.clip = slow;
            sound.Play();
        }
        else if (GameObject.FindGameObjectWithTag("enemy") != null && a == 1)
        {
            a = 0;
            sound.Stop();
            sound.clip = fast;
            sound.Play();
            
        }
    
    }
}
