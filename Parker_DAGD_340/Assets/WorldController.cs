using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour {

    public Animator machine_1;
    //AnimationEvent ae = new AnimationEvent(); 
    public GameObject startAnimBttn = null; //set in editor

	// Use this for initialization
	void Start () {
        machine_1.SetBool("IsIdle", true);
        //ae.messageOptions = SendMessageOptions.DontRequireReceiver;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            machine_1.SetBool("IsIdle", false);
            print("animation starting");        
        }
        
	}
    
    public void animStart()
    {
        machine_1.SetBool("IsIdle", false);
        print("animation starting");

        startAnimBttn.SetActive(false);
    }

    //note this animEnd code does not run in this script. It had to be placed in a script attached to the specific game object that is being animated.
    public void animEnded()
    {
        machine_1.SetBool("IsIdle", true);
        startAnimBttn.SetActive(true);
    }
}
