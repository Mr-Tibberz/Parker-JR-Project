using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HoverDetection : MonoBehaviour
{
    public PartLoader partLoader;
    public GameObject popupWindow;
    public Text infoText;
    public Text partText;
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
        partText.text = "Part Number: " + part.number;
    }
    void OnMouseDown()
    {
        camController.setTarget(this.gameObject);
    }    
    void OnMouseExit()
    {
        logo.SetActive(true);
        popupWindow.SetActive(false);
    }
}
