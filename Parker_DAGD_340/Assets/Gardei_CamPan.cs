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

    public Transform row1;
    //public Transform row2;
    //public Transform row3;

    Vector3 priorPos = Vector3.zero;
    Vector3 priorRot = Vector3.zero;
    bool lerping = false;
    float lerp = 0;
    float expSlide = .02f;

	// Use this for initialization
	void Start () {
        print(row1.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        print(lerping);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            lerping = true;
            priorPos = transform.position;
            priorRot = transform.rotation.eulerAngles;
            
        }
        if (lerping)
        {

            transform.position = Vector3.Lerp(priorPos, row1.transform.position, lerp);
            //transform.rotation.eulerAngles = new Vector3(Mathf.Lerp(priorRot.x, row1.transform.rotation.eulerAngles.x, lerp),0,0);
            //expSlide /= 1.03f;
            lerp += expSlide;
            if (lerp >= 1)
            {
                lerp = 1;
                lerping = false;
            }
        }
        else lerp = 0;
	}
}
