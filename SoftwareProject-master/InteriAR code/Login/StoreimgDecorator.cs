using MongoDB.Driver.Builders;
using System.IO;
using UnityEngine.UI;
using MongoDB.Driver;
using MongoDB.Bson;
using UnityEngine;
using System;

public class StoreimgDecorator : ImageNav {
	public Image Img;
	public Image Img2;
	public Image Img3;

	public Button Img_1;
	public Button Img_2;
	public Button Img_3;

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
		Debug.Log (find);

		string ar = find.ToString();
		ar = ar.Replace(",", "");
		ar = ar.Replace('"', ' ');

		string[] words = ar.Split(' ');

		try {
		var dir1 = words[110];

		byte[] byteArray = File.ReadAllBytes(dir1);
		Texture2D texture = new Texture2D(8, 8);
		texture.LoadImage(byteArray);
		Sprite s = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
		Img.sprite = s;
		}

		catch(Exception e) {

			Debug.Log ("file1 not found");
		}


		try{
		var dir2 = words[117];

		byte[] byteArray2 = File.ReadAllBytes(dir2);
		Texture2D texture2 = new Texture2D(8, 8);
		texture2.LoadImage(byteArray2);
		Sprite s2 = Sprite.Create(texture2, new Rect(0, 0, texture2.width, texture2.height), Vector2.zero, 1f);
		Img2.sprite = s2;
		}
		catch(Exception e) {

			Debug.Log ("file2 not found");
		}
		try{
		var dir3 = words[124];

		byte[] byteArray3 = File.ReadAllBytes(dir3);
		Texture2D texture3 = new Texture2D(8, 8);
		texture3.LoadImage(byteArray3);
		Sprite s3 = Sprite.Create(texture3, new Rect(0, 0, texture3.width, texture3.height), Vector2.zero, 1f);
		Img3.sprite = s3;
		}
		catch(Exception e) {

			Debug.Log ("file3 not found");
		}
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
		Img_1.onClick.AddListener (img1_counter);
		Img_2.onClick.AddListener (img2_counter);
		Img_3.onClick.AddListener (img3_counter);

	}
	public void img1_counter() {  //initialises counter to 1

		counter = 1;
	
	}
	public void img2_counter() {//initialises counter to 2

		counter = 2;
	}	public void img3_counter() {//initialises counter to 3

		counter = 3;
	}


}
