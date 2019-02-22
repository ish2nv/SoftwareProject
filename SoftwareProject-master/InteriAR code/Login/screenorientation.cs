using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenorientation : MonoBehaviour {

	// orientate the screen portrait (for all screens other than the AR camera)
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;
	}
	

}
