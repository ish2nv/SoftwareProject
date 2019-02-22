using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController: MonoBehaviour {

	//This simply removes the grid when dragging furniture out into the world.

	private InstantTrackingController trackerScript;
	//private GameObject ButtonsParent;

	// Use this for initialization
	void Start () {
		trackerScript = GameObject.Find ("Controller").gameObject.GetComponent<InstantTrackingController> ();
		trackerScript._gridRenderer.enabled = false;
	}
		
}
