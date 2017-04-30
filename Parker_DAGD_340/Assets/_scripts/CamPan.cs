using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// The CamPan (Camera Pan) Script Houses the code responsible for moving the camera between preset points.
/// Point1: Prior Position
/// Point2: Target Position
/// </summary>
public class CamPan : MonoBehaviour {

    /// <summary>
    /// The main camera that is passed in from the editor.
    /// </summary>
    public Camera mainCam;
    /// <summary>
    /// UI Object passed in from Editor so it can be accessed in this script.
    /// </summary>
    public Dropdown dropdown;
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
    /// Distance between target and camera on last frame.
    /// </summary>
    Vector3 priorDis;
    /// <summary>
    /// Position of target destination for camera
    /// </summary>
    Vector3 targetPos;
    /// <summary>
    /// Rotation of target rotation for camera
    /// </summary>
    Quaternion targetRot;
    /// <summary>
    /// Distance between camera and target.
    /// </summary>
    Vector3 targetDis;
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
    /// <summary>
    /// Stores Forward button for access within script.
    /// </summary>
    public GameObject forwardBttn;
    /// <summary>
    /// Stores Backward button for access within script.
    /// </summary>
    public GameObject backBttn;
    /// <summary>
    /// ccRight is the maximum a camera can scroll right.
    /// </summary>
    float ccRight;
    /// <summary>
    /// ccLeft is the maximum a camera can scroll left.
    /// </summary>
    float ccLeft;
    /// <summary>
    /// ccUp is the maximum a camera can pan up;
    /// </summary>
    float ccUp;
    /// <summary>
    /// ccDown is the maxium a camera can pan down.
    /// </summary>
    float ccDown;
    /// <summary>
    /// Fov is just a local copy of the main cameras fov.
    /// </summary>
    float fov;
    /// <summary>
    /// Used to check if we have exceeded the clamp values for a certain camera position. Updates when camera station is changed.
    /// </summary>
    Vector3 clamp;
    /// <summary>
    /// Whether or not the user is focusing on a specific part
    /// </summary>
    bool focused = false;


    // Use this for initialization
    /// <summary>
    /// When software starts, will set both prior and target to the same spot.
    /// </summary>
    void Start () {
        priorPos = transform.position;
        priorRot = transform.rotation;
        priorDis = transform.GetChild(0).transform.localPosition;
        targetPos = transform.position;
        targetRot = transform.rotation;
        targetDis = transform.GetChild(0).transform.localPosition;

        //easy unlimited rotation (not likely for user to reach this in signle session.
        ccLeft = gameObject.transform.eulerAngles.y - 9999999;
        ccRight = gameObject.transform.eulerAngles.y + 9999999;
        ccUp = gameObject.transform.eulerAngles.x + 20;
        ccDown = gameObject.transform.eulerAngles.x - 10;

        fov = mainCam.fieldOfView;

        forwardBttn.SetActive(false);
        backBttn.SetActive(false);
    }
	
	// Update is called once per frame
    /// <summary>
    /// Standard Update Loop. All code is ran once per frame.
    /// </summary>
	void Update () {

        //Testing for switching between stations.
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            dropdown.value = 0;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            dropdown.value = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            dropdown.value = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            dropdown.value = 3;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            dropdown.value = 4;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5)) 
        {
            dropdown.value = 5;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6)) 
        {
            dropdown.value = 6;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7)) 
        {
            dropdown.value = 7;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            dropdown.value = 8;
        }
        
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
            fov = Mathf.Lerp(fov, 60, perc/15);
            transform.position = Vector3.Lerp(priorPos, targetPos, perc);
            transform.rotation = Quaternion.Lerp(priorRot, targetRot, perc);
            transform.GetChild(0).transform.localPosition = Vector3.Lerp(priorDis, targetDis, perc);
        } else
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {

                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                transform.eulerAngles += new Vector3(0, mouseX);
                transform.eulerAngles += new Vector3(mouseY, 0);

                clamp.y = Mathf.Clamp(clamp.y + mouseX, ccLeft, ccRight);
                clamp.x = Mathf.Clamp(clamp.x - mouseY, ccDown, ccUp);
                transform.eulerAngles = clamp;

            }
            
            fov -= Input.GetAxis("Mouse ScrollWheel") * 35;
            fov = Mathf.Clamp(fov, 40, 70);
            
        }

        mainCam.fieldOfView = fov;
    }
    /// <summary>
    /// SetTarget: This function takes a target and will then immediately execute a camera transition as soon as it has been triggered.
    /// </summary>
    /// <param name="stationNum">integer that will tell the camera which preset position it needs to go to.</param>
    /// 
    public void setTarget(GameObject station) //used to zoom into specific parts
    {
        focused = true;
        backBttn.SetActive(true);
        forwardBttn.SetActive(false);
        targetPos = station.gameObject.transform.position;
        targetRot = station.gameObject.transform.rotation;
        targetRot.eulerAngles += new Vector3(20, 180, 0);
        targetDis = new Vector3(0, 0, -1.2f);
        

        ccLeft = targetRot.eulerAngles.y - 45;
        ccRight = targetRot.eulerAngles.y + 45;
        ccUp = targetRot.eulerAngles.x + 20;
        ccDown = targetRot.eulerAngles.x - 10;

        clamp.x = targetRot.eulerAngles.x;
        clamp.y = targetRot.eulerAngles.y;
        clamp.z = targetRot.eulerAngles.z;
        transitioning = true;
        panCam();
    }
    public void setTarget(int stationNum) // used to zoom into larger, preset stations
    {
        focused = false;
        if (stationNum == 0 || stationNum == 8)
        {
            //bttns vis false
            backBttn.SetActive(false);
            forwardBttn.SetActive(false);
            
        }
        else
        {
            //bttns vis true
            forwardBttn.SetActive(true);
            backBttn.SetActive(true);
        }
        transitioning = true;
        switch (stationNum)
        {
            case 0: //SKYVIEW
                targetPos = camPosSky.gameObject.transform.position;
                targetRot = camPosSky.gameObject.transform.rotation;
                targetDis = camPosSky.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight  = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
            case 1:
                targetPos = camPos1.gameObject.transform.position;
                targetRot = camPos1.gameObject.transform.rotation;
                targetDis = camPos1.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight  = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
            case 2:
                targetPos = camPos2.gameObject.transform.position;
                targetRot = camPos2.gameObject.transform.rotation;
                targetDis = camPos2.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
            case 3:
                targetPos = camPos3.gameObject.transform.position;
                targetRot = camPos3.gameObject.transform.rotation;
                targetDis = camPos3.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
            case 4:
                targetPos = camPos4.gameObject.transform.position;
                targetRot = camPos4.gameObject.transform.rotation;
                targetDis = camPos4.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
            case 5:
                targetPos = camPos5.gameObject.transform.position;
                targetRot = camPos5.gameObject.transform.rotation;
                targetDis = camPos5.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
            case 6:
                targetPos = camPos6.gameObject.transform.position;
                targetRot = camPos6.gameObject.transform.rotation;
                targetDis = camPos6.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
            case 7:
                targetPos = camPos7.gameObject.transform.position;
                targetRot = camPos7.gameObject.transform.rotation;
                targetDis = camPos7.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
            case 8: //HMI
                targetPos = camPosHMI.gameObject.transform.position;
                targetRot = camPosHMI.gameObject.transform.rotation;
                targetDis = camPosHMI.gameObject.transform.GetChild(0).transform.localPosition;

                ccLeft = targetRot.eulerAngles.y - 45;
                ccRight = targetRot.eulerAngles.y + 45;
                ccUp = targetRot.eulerAngles.x + 20;
                ccDown = targetRot.eulerAngles.x - 10;
                clamp.x = targetRot.eulerAngles.x;
                clamp.y = targetRot.eulerAngles.y;
                clamp.z = targetRot.eulerAngles.z;
                break;
        }
        panCam();
    }
    /// <summary>
    /// Resets the "lerp" code so the transition will start over from the current position.
    /// </summary>
    public void panCam() //triggered by UI or SPACE when debugging
    {
        priorPos = transform.position;
        priorRot = transform.rotation;
        priorDis = transform.GetChild(0).transform.localPosition;
        currentLerpTime = 0f;
        
    }
    public void changeDropDown(int ddv)
    {
        dropdown.value = ddv;
    }
    /// <summary>
    /// UI Function that sets current station selection.
    /// </summary>
    public void useDropDown()
    {
        
        setTarget(dropdown.value);
    }
    /// <summary>
    /// Function that sets current station to sky view. (convenience)
    /// </summary>
    public void clickSky()
    {
        dropdown.value = 0;
    }
    /// <summary>
    /// Function that sets current station to HMI. (convenience)
    /// </summary>
    public void clickHMI()
    {
        dropdown.value = 8;
    }
    /// <summary>
    /// Arrow button that progresses to next station in order of operation.
    /// </summary>
    public void nextStation()
    {
        if (dropdown.value == 0 || dropdown.value == 8) return;
        else if (dropdown.value == 7) dropdown.value = 1;
        else dropdown.value++;
    }
    /// <summary>
    /// Arrow button that progresses to previous station in order of operation.
    /// </summary>
    public void prevStation()
    {
        if (!focused)
        {
            if (dropdown.value == 0 || dropdown.value == 8) return;
            else if (dropdown.value == 1) dropdown.value = 7;
            else dropdown.value--;
        }
        else
        {
            setTarget(dropdown.value);
        }
    }
}
