using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HoverDetection : MonoBehaviour
{
    /// <summary>
    /// Object that contains information on the specific part based on a specified part number.
    /// </summary>
    public PartLoader partLoader;
    /// <summary>
    /// UI Object that contains the pop up infographic window that appears when you mouse over a game object. This is used in this script to make the infographic visible and invisible.
    /// </summary>
    public GameObject popupWindow;
    /// <summary>
    /// Text object that will contain the text displayed in the pop up infographic.
    /// </summary>
    public Text infoText;
    /// <summary>
    /// A string set in the editor that will allow the application to pull part information from a spreadsheet.
    /// </summary>
    public string partNumber;
    /// <summary>
    /// This is a copy of the company logo. It is the standard logo that appears when the pop up infographic is not currently displayed.
    /// </summary>
    public GameObject logo;
    /// <summary>
    /// This is a reference to the camera controller so that we can tell the camera it needs to focus on the station this script is attached to.
    /// </summary>
    public CamPan camController;

    /// <summary>
    /// On script start, the pop up window will not be visible.
    /// </summary>
    void Start()
    {
        popupWindow.SetActive(false);
    }
    /// <summary>
    /// When the mouse is over the station this script is attached to, the pop up window will appear and the standard logo will dissapear.
    /// </summary>
    void OnMouseOver()
    {
        logo.SetActive(false);
        popupWindow.SetActive(true);
        Part part = partLoader.FindPart(partNumber);
        infoText.text = part.info;
    }
    /// <summary>
    /// When the mouse is clicked while over this game object, the camera will look at the object based on this objects pivot point orientation.
    /// </summary>
    void OnMouseDown()
    {
        camController.setTarget(this.gameObject);
    }   
    /// <summary>
    /// When the mouse is no longer over this object, the pop up window will dissapear and the standard logo will reapear.
    /// </summary>   
    void OnMouseExit()
    {
        logo.SetActive(true);
        popupWindow.SetActive(false);
    }
}
