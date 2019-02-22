using UnityEngine;

public class FurnitureType : MonoBehaviour {

	//This script handles the differing furniture sections in the menu. The individual methods are attached to buttons.

	public GameObject Seating;
	public GameObject Tables;
	public GameObject Storage;

	public void ToggleSeating(){
		Tables.SetActive (false);
		Storage.SetActive (false);
		Seating.SetActive(true);
	}

	public void ToggleTables(){
		Tables.SetActive (true);
		Storage.SetActive (false);
		Seating.SetActive(false);
	}

	public void ToggleStorage(){
		Tables.SetActive (false);
		Storage.SetActive (true);
		Seating.SetActive(false);
	}
}
