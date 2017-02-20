using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// The Master Class. Current Functionallity allows a UI Button to start the main animation. This will ultimately turn into a Animation Controller script to play various individual animations.
/// </summary>
public class WorldController : MonoBehaviour {
    /// <summary>
    /// Pass in a Animator from editor so we can tell it to play.
    /// </summary>
    public Animator machine_1; //set in editor
    /// <summary>
    /// Pass in a UI Button so we can modify it through script (aka switch to invisible on play)
    /// </summary>
    public GameObject startAnimBttn = null; //set in editor

	// Use this for initialization
    /// <summary>
    /// On startup, sets Animator(s) to idle so it does not automatically play.
    /// </summary>
	void Start () {
        machine_1.SetBool("IsIdle", true);
    }
	
	// Update is called once per frame
    /// <summary>
    /// Currently, this is just checking to see if the user presses space. If they do, it will start the animation.
    /// </summary>
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) animStart();
    }
    
    /// <summary>
    /// This is triggered from a UI button or called in code. Causes the main animation to start.
    /// </summary>
    public void animStart()
    {
        machine_1.SetBool("IsIdle", false);
        print("animation starting");

        startAnimBttn.SetActive(false);
    }

}
