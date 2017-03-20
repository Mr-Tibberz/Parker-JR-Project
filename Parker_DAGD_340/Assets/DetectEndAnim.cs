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

    public void animEnded()
    {
        GetComponent<Animator>().SetBool("IsIdle", true);
        startAnimBttn.GetComponentInChildren<Text>().text = "►";
        //startAnimBttn.SetActive(true);
        print("returning to idle 33");
    }
}
