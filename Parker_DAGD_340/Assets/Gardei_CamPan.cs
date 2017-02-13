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



    //float t = currentLerpTime / lerpTime;
    //t = Mathf.Sin(t* Mathf.PI * 0.5f);


    /// <summary>
    /// Transform: camPos1 Target lerp position for station 1.
    /// </summary>
    public GameObject camPos1; //set in editor please
    public GameObject camPos2; //set in editor please
    public GameObject camPos3; //set in editor please

    /// <summary>
    /// priorPos: position of camera on last frame
    /// priorRot: rotation of camera on last frame
    /// 
    /// targetPos: position of target destination for camera
    /// targetRot: rotation of target rotation for camera
    /// </summary>
    Vector3 priorPos;
    Vector3 priorRot;

    Vector3 targetPos;
    Vector3 targetRot;

    /// <summary>
    /// moveCam: yes/no is the camera transitioning to a new position.
    /// </summary>
    bool moveCam = false;

    float lerpTime = 1f;
    float currentLerpTime;

	// Use this for initialization
	void Start () {
        priorPos = transform.position;
        priorRot = transform.rotation.eulerAngles;

        targetPos = transform.position;
        targetRot = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

        //Testing for switching between stations.
        if (Input.GetKeyDown(KeyCode.Keypad1)) setTarget(1);
        if (Input.GetKeyDown(KeyCode.Keypad2)) setTarget(2);
        if (Input.GetKeyDown(KeyCode.Keypad3)) setTarget(3);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //setTarget(1);
            
            /* DEBUG TESTING FOR ROTATION ISSUE
             * 
             * Found when trying to set a negative rotation, it automatically goes up to a positive number and thus can never turn left if you have to go from 0 to 360. May need to create a dummy angle value that can go negative to feed into lerp function?
            print("1: " + priorRot);
            print("2: " + camPos1.gameObject.transform.eulerAngles);

            print("CamY Rotation: " + camPos1.gameObject.transform.eulerAngles.y);
            if (camPos1.gameObject.transform.eulerAngles.y >= priorRot.y + 180)
            {
                print("OverRot Detected");
                print("CamY: " + camPos1.gameObject.transform.eulerAngles.y);
                camPos1.transform.eulerAngles = new Vector3(
                    camPos1.transform.eulerAngles.x,
                    camPos1.transform.eulerAngles.y,
                    camPos1.transform.eulerAngles.z
                    );
                print("CamY: " + camPos1.gameObject.transform.eulerAngles.y);
            }
            print("CamY Rotation: " + camPos1.gameObject.transform.eulerAngles.z);
            */
        }
        
        
            
            
            //divide to slow down, or multiply to speed up
            currentLerpTime += Time.deltaTime / 2;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime; //percent 0 - 1
            perc = perc*perc*perc * (perc * (6f*perc - 15f) + 10f);
            //SETUP SWITCH HERE TO CONTROL MULTIPLE POINTS.
            transform.position = Vector3.Lerp(priorPos, targetPos, perc);
            transform.eulerAngles = Vector3.Lerp(priorRot, targetRot, perc);
        
        
	}

    public void panCam() //triggered by UI or SPACE when debugging
    {
        
        currentLerpTime = 0f;
        //set prior transform values
        priorPos = transform.position;
        priorRot = transform.rotation.eulerAngles;
    }

    public void setTarget(int stationNum)
    {
        switch (stationNum)
        {
            case 1:
                targetPos = camPos1.gameObject.transform.position;
                targetRot = camPos1.gameObject.transform.eulerAngles;
                break;
            case 2:
                targetPos = camPos2.gameObject.transform.position;
                targetRot = camPos2.gameObject.transform.eulerAngles;
                break;
            case 3:
                targetPos = camPos3.gameObject.transform.position;
                targetRot = camPos3.gameObject.transform.eulerAngles;
                break;
        }
        panCam();
    }

}
