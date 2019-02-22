using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ifimgspritenull : MonoBehaviour {

	public Image Img;
	public Image Img2;
	public Image Img3;
	public Image Img4;
	public Image Img5;
	public Image Img6;


	public Button Img_1;
	public Button Img_2;
	public Button Img_3;
	public Button Img_4;
	public Button Img_5;
	public Button Img_6;

	void Start () {  //if user has not yet taken any images with the AR camera, then make all Image Objects non-interactable. else if
		         //user has taken images with the AR camera, then make all Image Objects interactable so user can enter the gallery


		if (Img.sprite == null) {

			Img_1.interactable = false;
	
		
		} else {

			Img_1.interactable = true;

		}

		if (Img2.sprite == null) {

			Img_2.interactable = false;


		} else {

			Img_2.interactable = true;

		}

		if (Img3.sprite == null) {

			Img_3.interactable = false;


		} else {

			Img_3.interactable = true;

		}
		if (Img4.sprite == null) {

			Img_4.interactable = false;


		} else {

			Img_4.interactable = true;

		}
		if (Img5.sprite == null) {

			Img_5.interactable = false;


		} else {

			Img_5.interactable = true;

		}
		if (Img6.sprite == null) {

			Img_6.interactable = false;


		} else {

			Img_6.interactable = true;

		}
	}
	

}
