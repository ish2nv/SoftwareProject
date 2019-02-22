using UnityEngine;

public class MyMenu : MonoBehaviour {

	public GameObject myMenu;

	public void ToggleMenu(){
		myMenu.SetActive(!myMenu.activeInHierarchy);
	}
}
