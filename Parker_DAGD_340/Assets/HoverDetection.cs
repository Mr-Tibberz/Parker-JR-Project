using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/*
public class HoverDetection : MonoBehaviour
{
    public PartLoader partLoader;
    public GameObject popupWindow;
    public Gardei_CamPan cameraController;

    public string partName = "";

    void Start()
    {
        popupWindow.SetActive(false);
    }
    void OnMouseOver()
    {
        popupWindow.SetActive(true);
        //popupWindow.GetComponentInChildren<Text>().text = "Hi there";
    }
    void OnMouseExit()
    {
        popupWindow.SetActive(false);
        //popupWindow.GetComponentInChildren<Text>().text = "";
    }
    void OnMouseDown()
    {
        print("click");
    }
}


public class HoverDetection : MonoBehaviour
{
    public PartLoader partLoader;
    public GameObject popupWindow;

    public string partName = "";

    void Start()
    {
        popupWindow.SetActive(false);
    }
    void OnMouseOver()
    {
        popupWindow.SetActive(true);
        popupWindow.GetComponentInChildren<Text>().text = "Hi there";
    }
    void OnMouseExit()
    {
        popupWindow.SetActive(false);
        popupWindow.GetComponentInChildren<Text>().text = "";
    }
}
*/

public class HoverDetection : MonoBehaviour
{
    public PartLoader partLoader;
    public GameObject popupWindow;
    public Text infoText;
    public string partNumber;
    public GameObject logo;
    public Gardei_CamPan camController;

    void Start()
    {
        popupWindow.SetActive(false);
    }
    void OnMouseOver()
    {
        logo.SetActive(false);
        popupWindow.SetActive(true);
        Part part = partLoader.FindPart(partNumber);
        infoText.text = part.info;
    }
    void OnMouseDown()
    {
        print("BOOM");
        camController.setTarget(this.gameObject);
    }    
    void OnMouseExit()
    {
        logo.SetActive(true);
        popupWindow.SetActive(false);
    }
}
