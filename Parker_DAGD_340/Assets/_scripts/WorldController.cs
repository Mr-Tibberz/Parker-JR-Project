using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// The Master Class. Handles any and all basic functions that pertain to the game world.
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
    public GameObject HMIStartAnimBttn = null;

    bool playAnim = false;
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

        //Juicy Pause/Play code
        if (!playAnim)
        {
            machine_1.speed *= .95f;
        }
        if(playAnim)
        {
            machine_1.speed += .00001f; //when 0, we just need to kick it a little bit to get it started.
            machine_1.speed *= 1.2f;
            if (machine_1.speed >= 1) machine_1.speed = 1;
        }
    }
    
    /// <summary>
    /// This is triggered from a UI button or called in code. Causes the main animation to start.
    /// </summary>
    public void animStart()
    {
        if (playAnim == false) playAnim = true;
        else playAnim = false;
        

        if (playAnim)
        {
            machine_1.SetBool("IsIdle", false);            
            startAnimBttn.GetComponentInChildren<Text>().text = "ll";
            HMIStartAnimBttn.GetComponentInChildren<Text>().text = "STOP";
            HMIStartAnimBttn.GetComponent<Image>().color = Color.red;
        } else
        {
            startAnimBttn.GetComponentInChildren<Text>().text = "►";
            HMIStartAnimBttn.GetComponentInChildren<Text>().text = "START";
            HMIStartAnimBttn.GetComponent<Image>().color = Color.green;
        }

        //print("animation starting");


        
    }

    public void exitApp()
    {
        Application.Quit();
    }

}
