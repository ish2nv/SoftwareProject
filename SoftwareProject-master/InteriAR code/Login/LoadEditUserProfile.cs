using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEditUserProfile : MonoBehaviour {

	// Used to load any scene within our program
	public void loadscene (string a) {
		SceneManager.LoadScene(a);

	}
}
