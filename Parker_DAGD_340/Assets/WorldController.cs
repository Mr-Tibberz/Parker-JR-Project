using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    public Animator machine_1;
    AnimationEvent ae = new AnimationEvent(); 

	// Use this for initialization
	void Start () {
        machine_1.SetBool("IsIdle", true);
        ae.messageOptions = SendMessageOptions.DontRequireReceiver;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            machine_1.SetBool("IsIdle", false);
            print("test");        
        }
        
	}

    public void animEnded()
    {
        machine_1.SetBool("IsIdle", true);
    }
}
