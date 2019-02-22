using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARDecoratorORUser : MonoBehaviour { 

	public static int counter = 0;

	public void loadAR() {   //this method loads up the AR camera, when the camera button is clicked in either the decorator profile
		                 //or the user profile. if it is clicked in the user profile, then set counter to 1. else set counter
		                 //to 2.

		Scene current = SceneManager.GetActiveScene ();

		string sceneName = current.name;

		if (sceneName == "userProfile") {

			counter = 1;
			SceneManager.LoadScene ("main");


		} 
		if (sceneName == "decoratorProfileLogin") {

			counter = 2;
			SceneManager.LoadScene ("main");

		}
	}

	public void loadProfile() { //this method loads up either the user profile or the decorator profile. if, from previous method
		                    //the counter was set to 1, then load the user profile. else load the decorator profile

		Debug.Log (counter);
		if (counter == 1) {


			SceneManager.LoadScene ("userProfile");

		} else if (counter == 2) {


			SceneManager.LoadScene ("decoratorProfileLogin");


		}


	}

}
