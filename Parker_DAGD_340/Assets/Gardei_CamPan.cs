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
    public Transform camPos1; //set in editor please
    
    /// <summary>
    /// priorPos: position of camera on last frame
    /// priorRot: rotation of camera on last frame
    /// </summary>
    Vector3 priorPos = Vector3.zero;
    Vector3 priorRot = Vector3.zero;

    /// <summary>
    /// moveCam: yes/no is the camera transitioning to a new position.
    /// </summary>
    bool moveCam = false;

    float lerpTime = 1f;
    float currentLerpTime;

	// Use this for initialization
	void Start () {
        priorPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveCam = true;
            currentLerpTime = 0f;
            //set prior transform values
            priorPos = transform.position;
            priorRot = transform.rotation.eulerAngles;
        }
        
        if (moveCam)
        {
            //divide to slow down, or multiply to speed up
            currentLerpTime += Time.deltaTime / 2;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime; //percent 0 - 1
            perc = perc*perc*perc * (perc * (6f*perc - 15f) + 10f);
            //SETUP SWITCH HERE TO CONTROL MULTIPLE POINTS.
            transform.position = Vector3.Lerp(priorPos, camPos1.transform.position, perc);
            transform.eulerAngles = Vector3.Lerp(priorRot, camPos1.eulerAngles, perc);
        }
        
	}
}
