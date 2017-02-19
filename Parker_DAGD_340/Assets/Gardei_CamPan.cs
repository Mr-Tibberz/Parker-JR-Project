using UnityEngine;
using System.Collections;

public class Gardei_CamPan : MonoBehaviour {
    //ideas - use vector 3 lerp / Exponential slide to move camera

    //Notes from web

    /*
        https://chicounity3d.wordpress.com/2014/05/23/how-to-lerp-like-a-pro/

        Ease Out with Sinerp
        float t = currentLerpTime / lerpTime;
        t = Mathf.Sin(t * Mathf.PI * 0.5f);
     
        Ease In with Coserp
        t = 1f - Mathf.Cos(t * Mathf.PI * 0.5f)
     
     */

    /// <summary>
    /// camPos1: Target lerp position for station 1.
    /// camPos2: Target lerp position for station 2.
    /// camPos3: Target lerp position for station 3.
    /// camPos4: Target lerp position for station 4.
    /// camPos5: Target lerp position for station 5.
    /// camPos6: Target lerp position for station 6.
    /// camPos7: Target lerp position for station 7.
    /// camPosSky: Target lerp position for Skyview.
    /// camPosHMI: Target lerp position for HMI.
    /// priorPos: position of camera on last frame
    /// priorRot: rotation of camera on last frame 
    /// targetPos: position of target destination for camera
    /// targetRot: rotation of target rotation for camera
    /// moveCam: yes/no is the camera transitioning to a new position.
    /// lerpTime: maximum value of a lerp sequence.
    /// currentLerpTime: value between 0 and 1 will guide the camera through a transition to a new location.
    /// </summary>

    public GameObject camPos1; //set in editor please
    public GameObject camPos2; //set in editor please
    public GameObject camPos3; //set in editor please
    public GameObject camPos4; //set in editor please
    public GameObject camPos5; //set in editor please
    public GameObject camPos6; //set in editor please
    public GameObject camPos7; //set in editor please
    public GameObject camPosSky; //set in editor please
    public GameObject camPosHMI; //set in editor please
    
    Vector3 priorPos;
    Quaternion priorRot;
    Vector3 targetPos;
    Quaternion targetRot;

    bool moveCam = false;

    float lerpTime = 1f;
    float currentLerpTime;

	// Use this for initialization
	void Start () {
        priorPos = transform.position;
        priorRot = transform.rotation;

        targetPos = transform.position;
        targetRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        //Testing for switching between stations.
        if (Input.GetKeyDown(KeyCode.Keypad1)) setTarget(1);
        if (Input.GetKeyDown(KeyCode.Keypad2)) setTarget(2);
        if (Input.GetKeyDown(KeyCode.Keypad3)) setTarget(3);
        if (Input.GetKeyDown(KeyCode.Keypad4)) setTarget(4);
        if (Input.GetKeyDown(KeyCode.Keypad5)) setTarget(5);
        if (Input.GetKeyDown(KeyCode.Keypad6)) setTarget(6);
        if (Input.GetKeyDown(KeyCode.Keypad7)) setTarget(7);
        if (Input.GetKeyDown(KeyCode.Keypad8)) setTarget(8);
        if (Input.GetKeyDown(KeyCode.Keypad9)) setTarget(9);
        //divide to slow down, or multiply to speed transition up
        currentLerpTime += Time.deltaTime / 2;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime; //percent 0 - 1
            perc = perc*perc*perc * (perc * (6f*perc - 15f) + 10f); //ease in, ease out maths (Creates s curve on a graph)

            transform.position = Vector3.Lerp(priorPos, targetPos, perc);
            transform.rotation = Quaternion.Lerp(priorRot, targetRot, perc);
	}
    /// <summary>
    /// SetTarget: This function takes a target and will then immediately execute a camera transition as soon as it has been triggered.
    /// </summary>
    /// <param name="stationNum">integer that will tell the camera which preset position it needs to go to.</param>
    public void setTarget(int stationNum)
    {
        switch (stationNum)
        {
            case 1:
                targetPos = camPos1.gameObject.transform.position;
                targetRot = camPos1.gameObject.transform.rotation;
                break;
            case 2:
                targetPos = camPos2.gameObject.transform.position;
                targetRot = camPos2.gameObject.transform.rotation;
                break;
            case 3:
                targetPos = camPos3.gameObject.transform.position;
                targetRot = camPos3.gameObject.transform.rotation;
                break;
            case 4:
                targetPos = camPos4.gameObject.transform.position;
                targetRot = camPos4.gameObject.transform.rotation;
                break;
            case 5:
                targetPos = camPos5.gameObject.transform.position;
                targetRot = camPos5.gameObject.transform.rotation;
                break;
            case 6:
                targetPos = camPos6.gameObject.transform.position;
                targetRot = camPos6.gameObject.transform.rotation;
                break;
            case 7:
                targetPos = camPos7.gameObject.transform.position;
                targetRot = camPos7.gameObject.transform.rotation;
                break;
            case 8: //SKYVIEW
                targetPos = camPosSky.gameObject.transform.position;
                targetRot = camPosSky.gameObject.transform.rotation;
                break;
            case 9: //HMI
                targetPos = camPosHMI.gameObject.transform.position;
                targetRot = camPosHMI.gameObject.transform.rotation;
                break;
        }
        panCam();
    }
    /// <summary>
    /// Resets the "lerp" code so the transition will start over from the current position.
    /// </summary>
    public void panCam() //triggered by UI or SPACE when debugging
    {

        currentLerpTime = 0f;
        //set prior transform values
        priorPos = transform.position;
        priorRot = transform.rotation;
    }

}
