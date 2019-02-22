using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.IO;
using UnityEngine.UI;
using System;

public class StoreImage : ImageNav {
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



	public void Start() //this method searches the database to find the users account so it can find the images they took on the 
		            //AR camera and display them in their profile
	{
		var name = "ishtiyaq";
		var pass = "1234";
		var dbname = "decorators";
		var uri = "mongodb://" + name + ":" + pass + "@ds119268.mlab.com:19268/decorators";

		MongoClient client = new MongoClient(uri);

		var server = client.GetServer();
		var db = server.GetDatabase(dbname);
		var collection = db.GetCollection<BsonDocument>("systemdecorators");
	


		var entityQuery = Query.And(
			Query.EQ("username", PlayerPrefs.GetString("unme"))
		);
		var find = collection.FindOne(entityQuery);
		string ar = find.ToString();
		ar = ar.Replace(",", "");
		ar = ar.Replace('"', ' ');

		string[] words = ar.Split(' ');

		try {
		var dir1 = words[106];
		byte[] byteArray = File.ReadAllBytes(dir1);
		Texture2D texture = new Texture2D(8, 8);
		texture.LoadImage(byteArray);
		Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
		Img.sprite = s;
		}
		catch(Exception e) {

			Debug.Log ("file1 not found");
		}

		try {
		var dir2 = words[113];

		byte[] byteArray2 = File.ReadAllBytes(dir2);
		Texture2D texture2 = new Texture2D(8, 8);
		texture2.LoadImage(byteArray2);
		Sprite s2 = Sprite.Create(texture2, new Rect(0, 0, texture2.width, texture2.height), Vector2.zero, 1f);
		Img2.sprite = s2;
		}
		catch(Exception e) {

			Debug.Log ("file2 not found");

		}

		try {
		var dir3 = words[120];

		byte[] byteArray3 = File.ReadAllBytes(dir3);
		Texture2D texture3 = new Texture2D(8, 8);
		texture3.LoadImage(byteArray3);
		Sprite s3 = Sprite.Create(texture3, new Rect(0, 0, texture3.width, texture3.height), Vector2.zero, 1f);
		Img3.sprite = s3;
		}

		catch(Exception e) {

			Debug.Log ("file3 not found");

		}

		try {
		var dir4 = words[127];

		byte[] byteArray4 = File.ReadAllBytes(dir4);
		Texture2D texture4 = new Texture2D(8, 8);
		texture4.LoadImage(byteArray4);
		Sprite s4 = Sprite.Create(texture4, new Rect(0, 0, texture4.width, texture4.height), Vector2.zero, 1f);
		Img4.sprite = s4;
		}

		catch(Exception e) {

			Debug.Log ("file4 not found");

		}

		try {
		var dir5 = words[134];

		byte[] byteArray5 = File.ReadAllBytes(dir5);
		Texture2D texture5 = new Texture2D(8, 8);
		texture5.LoadImage(byteArray5);
		Sprite s5 = Sprite.Create(texture5, new Rect(0, 0, texture5.width, texture5.height), Vector2.zero, 1f);
		Img5.sprite = s5;
		}
		catch(Exception e) {

			Debug.Log ("file5 not found");

		}

		try {
		var dir6 = words[141];

		byte[] byteArray6 = File.ReadAllBytes(dir6);
		Texture2D texture6 = new Texture2D(8, 8);
		texture6.LoadImage(byteArray6);
		Sprite s6 = Sprite.Create(texture6, new Rect(0, 0, texture6.width, texture6.height), Vector2.zero, 1f);
		Img6.sprite = s6;
		}
		catch(Exception e) {

			Debug.Log ("file6 not found");

		}
		Img_1.onClick.AddListener (img1_counter);
		Img_2.onClick.AddListener (img2_counter);
		Img_3.onClick.AddListener (img3_counter);
		Img_4.onClick.AddListener (img4_counter);
		Img_5.onClick.AddListener (img5_counter);
		Img_6.onClick.AddListener (img6_counter);

	}
		

	public void img1_counter() {  //initialise counter to 1

		counter = 1;
	}
	public void img2_counter() { //initialise counter to 2

		counter = 2;
	}	public void img3_counter() { //initialise counter to 3

		counter = 3;
	}	public void img4_counter() { //initialise counter to 4

		counter = 4;
	}	public void img5_counter() { //initialise counter to 5

		counter = 5;
	}	public void img6_counter() { //initialise counter to 6

		counter = 6;
	}

}
