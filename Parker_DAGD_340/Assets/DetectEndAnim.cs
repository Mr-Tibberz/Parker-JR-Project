using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEndAnim : MonoBehaviour {
    public GameObject startAnimBttn = null; //set in editor
                                            // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void animEnded()
    {
        GetComponent<Animator>().SetBool("IsIdle", true);
        startAnimBttn.SetActive(true);
        print("returning to idle");
    }
}
