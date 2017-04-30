using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This script should only be attached to gameobjects with embeded animations. It contains various functions
/// </summary>
public class AnimEventController : MonoBehaviour {
    /// <summary>
    /// A button passed in from the Unity Editor that you want to reappear when the animation has completed.
    /// </summary>
    public GameObject startAnimBttn = null; //set in editor
    public GameObject hmiStartAnimBttn = null;
    public GameObject followBttn = null;
    /// <summary>
    /// UI Object passed in from Editor so it can be accessed in this script. This value is modified in this script for the follow mode.
    /// </summary>
    public Dropdown dropdown;
    int stationNum = 1;
    bool follow = false;
    
    /// <summary>
    /// function fires when the animation has ended. This is fired by an event attached to a specific animation file.
    /// </summary>
    public void animEnded()
    {
        GetComponent<Animator>().SetBool("IsIdle", true);
        startAnimBttn.GetComponentInChildren<Text>().text = "►";
        //startAnimBttn.SetActive(true);
        hmiStartAnimBttn.GetComponent<Image>().color = Color.green;
        hmiStartAnimBttn.GetComponentInChildren<Text>().text = "START";
        print("returning to idle 33");
        stationNum = 1;
        dropdown.value = 0;
        follow = false;
        followBttn.GetComponentInChildren<Text>().text = "Follow";
    }
    /// <summary>
    /// This should be called from an event timeline on a specific animation.
    /// </summary>
    public void nextStation()
    {
        stationNum++;
        if (follow)
        {
            if (stationNum == 0 || stationNum == 8)
            {
                stationNum = 1;
                dropdown.value = 1;
            }
            else if (stationNum == 8)
            {
                //Return to Sky
                stationNum = 0;
                dropdown.value = 0;
            }
            else dropdown.value = stationNum;           
        }
        
    }
    public void followToggle()
    {
        if (!follow)
        {
            follow = true;
            followBttn.GetComponentInChildren<Text>().text = "Unfollow";
            dropdown.value = stationNum;
        }
        else
        {
            follow = false;
            followBttn.GetComponentInChildren<Text>().text = "Follow";
        }
    }
    public void changeDropDown(int ddv)
    {
        dropdown.value = ddv;
    }
}
