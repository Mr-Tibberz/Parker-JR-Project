using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This Script's sole purpose is to fire when the full loop animation has ended. It will reset the machine animation and will adjust the UI to allow user to play the animation again.
/// </summary>
public class DetectEndAnim : MonoBehaviour {
    /// <summary>
    /// A button passed in from the Unity Editor that you want to reappear when the animation has completed.
    /// </summary>
    public GameObject startAnimBttn = null; //set in editor
    public GameObject followBttn = null;
    /// <summary>
    /// UI Object passed in from Editor so it can be accessed in this script. This value is modified in this script for the follow mode.
    /// </summary>
    public Dropdown dropdown;
    int stationNum = 1;
    bool follow = false;
    

    public void animEnded()
    {
        GetComponent<Animator>().SetBool("IsIdle", true);
        startAnimBttn.GetComponentInChildren<Text>().text = "►";
        //startAnimBttn.SetActive(true);
        print("returning to idle 33");
        stationNum = 1;
        dropdown.value = 0;
        follow = false;
        followBttn.GetComponentInChildren<Text>().text = "Follow";
    }
    //called when animation reaches a certain point on timeline so that the camera better follows the bottole.
    /// <summary>
    /// This should be called as an event 
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
