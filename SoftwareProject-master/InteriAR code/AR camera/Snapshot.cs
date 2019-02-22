using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//put non capture stuff in a diff class.
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

 class Snapshot : MonoBehaviour {
//
//	private Texture2D ss;
//	private byte[] Bytes_File;
//	private string path;
//	public bool isPressed = false;
//	private string na = "test.png";
	private int counter = 0;

	//notifcation
	public GameObject notification;

	public void capture(){
		//assigning popup object
		//notification = GameObject.Find("SnapshotPopup");

		//Making the UI invisible
		GameObject.Find("SnapshotButton").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("DeleteButton").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("BackButton").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find ("Reinitialise").transform.localScale = new Vector3 (0, 0, 0);
		GameObject.Find("Furniture").transform.localScale = new Vector3(0, 0, 0);

		//Giving the SS a name based on date/time
		counter++;
		string file_name = "Screenshot_" + counter + ".jpg";
		//Saving this SS to the device.
		ScreenCapture.CaptureScreenshot (file_name);
		//As CaptureScreenshot is asynchronus, a delay must be used to make sure the UI isn't made visible before the SS happens.
		StartCoroutine (ssDelay ());

		StartCoroutine (ssNotification ());

	}



	public void addimgtoDB() {
		var name = "ishtiyaq";
		var pass = "1234";
		var dbname = "decorators";
		var uri = "mongodb://" + name + ":" + pass + "@ds119268.mlab.com:19268/decorators";

		MongoClient client = new MongoClient(uri);

		var server = client.GetServer();
		var db = server.GetDatabase(dbname);
		var collection = db.GetCollection<BsonDocument>("systemdecorators");



		if (counter == 1) {
			var fileName = Application.persistentDataPath + "/" + "Screenshot_1.jpg";

			collection.Update (Query.And (
				Query.EQ ("username", PlayerPrefs.GetString ("unme"))
			), Update<fields2>.
				Set (s => s.directory1, fileName));
		}
		if (counter == 2) {
			var fileName = Application.persistentDataPath + "/" + "Screenshot_2.jpg";

			collection.Update (Query.And (
				Query.EQ ("username", PlayerPrefs.GetString ("unme"))
			), Update<fields2>.
				Set (s => s.directory2, fileName));
		}
		if (counter == 3) {
			var fileName = Application.persistentDataPath + "/" + "Screenshot_3.jpg";

			collection.Update (Query.And (
				Query.EQ ("username", PlayerPrefs.GetString ("unme"))
			), Update<fields2>.
				Set (s => s.directory3, fileName));
		}
		if (counter == 4) {
			var fileName = Application.persistentDataPath + "/" + "Screenshot_4.jpg";

			collection.Update (Query.And (
				Query.EQ ("username", PlayerPrefs.GetString ("unme"))
			), Update<fields2>.
				Set (s => s.directory4, fileName));
		}

		if (counter == 5) {
			var fileName = Application.persistentDataPath + "/" + "Screenshot_5.jpg";

			collection.Update (Query.And (
				Query.EQ ("username", PlayerPrefs.GetString ("unme"))
			), Update<fields2>.
				Set (s => s.directory5, fileName));
		}
		if (counter == 6) {
			var fileName = Application.persistentDataPath + "/" + "Screenshot_6.jpg";

			collection.Update (Query.And (
				Query.EQ ("username", PlayerPrefs.GetString ("unme"))
			), Update<fields2>.
				Set (s => s.directory6, fileName));
		}
			

	}

	private IEnumerator ssDelay(){
		yield return 0;		//waits for next frame
		//Making the UI visible again.
		GameObject.Find("SnapshotButton").transform.localScale = new Vector3(0.1f, 0.5f, 1);
		GameObject.Find("DeleteButton").transform.localScale = new Vector3(0.1f, 0.5f, 1);
		GameObject.Find("BackButton").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("Furniture").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("Reinitialise").transform.localScale = new Vector3(1, 1, 1);
	}

	private IEnumerator ssNotification(){
		yield return 0;
		notification.SetActive(true);
		yield return new WaitForSeconds (3);
		notification.SetActive(false);
	}
		



		
//	void showSS(string name){
//		path = System.IO.Path.Combine (Application.persistentDataPath, name);
// 		Bytes_File = System.IO.File.ReadAllBytes(path);
//		ss = new Texture2D(0, 0, TextureFormat.DXT1, false);
//		ss.LoadImage (Bytes_File);
//		print (ss == null);
//		na = name;
//		print (isPressed);
//		isPressed = true;
//		print (isPressed);
//
//	}

//	void Update(){
//		if (Input.touches.Length > 0) {
//			isPressed = true;
//		}
//	}
//
//	void OnGUI(){
//		//print (isPressed);
//		if (isPressed) {
//			path = System.IO.Path.Combine (Application.persistentDataPath, na);
//			Bytes_File = System.IO.File.ReadAllBytes (path);
//			ss = new Texture2D (0, 0, TextureFormat.DXT1, false);
//			ss.LoadImage (Bytes_File);
//			isPressed = false;
//			//print (ss == null);
//		}
//
//
//		if (ss != null) {
//			GUI.DrawTexture (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 150, 400, 300), ss);	
//		} else {
//			//print (ss == null);
//		}
//	}

}
