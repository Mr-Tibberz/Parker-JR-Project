using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEndAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void animEnded()
    {
        GetComponent<Animator>().SetBool("IsIdle", true);
        print("triggered");
    }
}
