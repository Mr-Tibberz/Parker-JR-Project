using UnityEngine;
using System.Collections;
using UnityEngine.UI;


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
