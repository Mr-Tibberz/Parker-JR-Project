using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The faceCam script has one simple task. It makes whatever gameObject it's attached to look at the main camera. (Or whatever you pass into the target).
/// </summary>
public class FaceCam : MonoBehaviour {

    /// <summary>
    /// This is the object that you want the object with this script attached to look at.
    /// </summary>
    public Transform target;

		
	// Update is called once per frame
    /// <summary>
    /// Every Frame, camera will rotate to look at target object.
    /// </summary>
	void Update () {
        transform.rotation = Quaternion.LookRotation(transform.position - target.position);
	}
}
