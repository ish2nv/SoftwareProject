using UnityEngine;

public class RotationController : MonoBehaviour {


	//Original rotation controller,  time based.

	private InstantTrackingController _controller;
	private Transform _activeObject = null;

	private Vector3 _touch1StartGroundPosition;
	private Vector3 _touch2StartGroundPosition;
	private Vector3 _startObjectScale;

	public float speed = 10f;

	private void Start () {
		_controller = GetComponent<InstantTrackingController>();
	}
	
	// Update is called once per frame
	private void Update () {

		//If they are both two finger gestures how do I differentiate between rotating and scaling?? Maybe rotate would have to be 3 fingers...
		//currently scale is 2 and rotate is 3 now.

		//below taken from ScaleController - commenting here for my understanding of the code.
		//Two touches as it's using 2 fingers for scale, pinching.
		if (Input.touchCount >= 3) {		//Changed to 3 for testing
			Touch touch1 = Input.GetTouch (0);
			Touch touch2 = Input.GetTouch (1);
			Touch touch3 = Input.GetTouch (2);	//added for third finger
			Transform hitTransform;
			//If there is no currently active object already...
			if (_activeObject == null) {
				if (GetTouchObject (touch1.position, out hitTransform)) {	//Run the GetTouchObject function, which returns true/false
					SetTouchObject (hitTransform);							//If that finds an object - assign it as the active object.
					//Then it checks touch two, and if that sitll doesnt find something it checks the center point between the two fingers for an object.
				} else if (GetTouchObject (touch2.position, out hitTransform)) {
					SetTouchObject (hitTransform);
				} else if (GetTouchObject (touch3.position, out hitTransform)) {		//third finger
					SetTouchObject (hitTransform);
				} else if (GetTouchObject ((touch1.position + touch2.position + touch3.position) / 3, out hitTransform)) {		//Edited, see scale for original.
					SetTouchObject (hitTransform);
				}
			}

			if (_activeObject != null) {
				_activeObject.transform.Rotate (Vector3.up, speed * Time.deltaTime);		//Just rotating based on time, want to do with fingers really.
			}

		} else {
			_activeObject = null;
		}

	}
		
	private bool GetTouchObject(Vector2 touchPosition, out Transform hitTransform) {
		var touchRay = Camera.main.ScreenPointToRay(touchPosition);
		touchRay.origin -= touchRay.direction * 100.0f;

		RaycastHit hit;
		if (Physics.Raycast(touchRay, out hit)) {
			hitTransform = hit.transform;
			return true;
		}

		hitTransform = null;
		return false;
	}

	private void SetTouchObject (Transform newObject)
	{
		if (_controller.ActiveModels.Contains (newObject.gameObject)) {
			_activeObject = newObject;
		}
	}
}

