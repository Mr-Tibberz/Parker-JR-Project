using UnityEngine;
using System.Collections;
/// <summary>
/// The CamPan (Camera Pan) Script Houses the code responsible for moving the camera between preset points.
/// Point1: Prior Position
/// Point2: Target Position
/// </summary>
public class Gardei_CamPan : MonoBehaviour {

    /// <summary>
    /// Target lerp position for station 1.
    /// </summary>
    public GameObject camPos1; //set in editor please
    /// <summary>
    /// Target lerp position for station 2.
    /// </summary>
    public GameObject camPos2; //set in editor please
    /// <summary>
    /// Target lerp position for station 3.
    /// </summary>
    public GameObject camPos3; //set in editor please
    /// <summary>
    /// Target lerp position for station 4.
    /// </summary>
    public GameObject camPos4; //set in editor please
    /// <summary>
    /// Target lerp position for station 5.
    /// </summary>
    public GameObject camPos5; //set in editor please
    /// <summary>
    /// Target lerp position for station 6.
    /// </summary>
    public GameObject camPos6; //set in editor please
    /// <summary>
    /// Target lerp position for station 7.
    /// </summary>
    public GameObject camPos7; //set in editor please
    /// <summary>
    /// Target lerp position for Skyview.
    /// </summary>
    public GameObject camPosSky; //set in editor please
    /// <summary>
    /// Target lerp position for HMI.
    /// </summary>
    public GameObject camPosHMI; //set in editor please
    /// <summary>
    /// Position of camera on last frame
    /// </summary>
    Vector3 priorPos;
    /// <summary>
    /// Rotation of camera on last frame 
    /// </summary>
    Quaternion priorRot;
    /// <summary>
    /// Position of target destination for camera
    /// </summary>
    Vector3 targetPos;
    /// <summary>
    /// Rotation of target rotation for camera
    /// </summary>
    Quaternion targetRot;
    /// <summary>
    /// Maximum value of a lerp sequence.
    /// </summary>
    float lerpTime = 1f;
    /// <summary>
    /// Value between 0 and 1 will guide the camera through a transition to a new location.
    /// </summary>
    float currentLerpTime;
    /// <summary>
    /// Returns whether or not a transition is taking place.
    /// </summary>
    bool transitioning = false;

	// Use this for initialization
    /// <summary>
    /// When software starts, will set both prior and target to the same spot.
    /// </summary>
	void Start () {
        priorPos = transform.position;
        priorRot = transform.rotation;

        targetPos = transform.position;
        targetRot = transform.rotation;
	}
	
	// Update is called once per frame
    /// <summary>
    /// Standard Update Loop. All code is ran once per frame.
    /// </summary>
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
                transitioning = false;
            }

            float perc = currentLerpTime / lerpTime; //percent 0 - 1
            perc = perc*perc*perc * (perc * (6f*perc - 15f) + 10f); //ease in, ease out maths (Creates s curve on a graph)

        if (transitioning)
        {
            transform.position = Vector3.Lerp(priorPos, targetPos, perc);
            transform.rotation = Quaternion.Lerp(priorRot, targetRot, perc);
        }
            
	}
    /// <summary>
    /// SetTarget: This function takes a target and will then immediately execute a camera transition as soon as it has been triggered.
    /// </summary>
    /// <param name="stationNum">integer that will tell the camera which preset position it needs to go to.</param>
    public void setTarget(int stationNum)
    {
        transitioning = true;
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
