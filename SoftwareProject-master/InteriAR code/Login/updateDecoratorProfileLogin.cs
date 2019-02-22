using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine.UI;
using MongoDB.Driver.Builders;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;


public class updateDecoratorProfileLogin : MonoBehaviour {

	public Text mr;
	public InputField fname;
	public InputField lname;
	public InputField uname;
	public InputField age;
	public InputField pword;

	public InputField cname;
	public InputField jtitle;
	public InputField mail;



	public void generator() //when user has finished editing their profile and presses the submit button, this method essentially
	                      //updates the users account on the database with the new information user has provided
	{
		var name = "ishtiyaq";
		var pass = "1234";
		var dbname = "decorators";
		var uri = "mongodb://" + name + ":" + pass + "@ds119268.mlab.com:19268/decorators";

		MongoClient client = new MongoClient(uri);

		var server = client.GetServer();
		var db = server.GetDatabase(dbname);
		var collection = db.GetCollection<BsonDocument>("systemdecorators");

		MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
		md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pword.text));
		byte[] result = md5.Hash;
		StringBuilder str = new StringBuilder();
		for (int i = 1; i < result.Length; i++)
		{
			str.Append(result[i].ToString("x2"));
		}


		collection.Update(Query.And(
			Query.EQ("username", PlayerPrefs.GetString("unme"))
		), Update<fields6>.
			Set(s => s.title, mr.text).
			Set(s => s.firstname, fname.text).
			Set(s => s.lastname, lname.text).
			Set(s => s.username, uname.text).
			Set(s => s.age, age.text).
			Set(s => s.companyname, cname.text).
			Set(s => s.jobtitle, jtitle.text).
			Set(s => s.eaddress, mail.text).
			Set(s => s.password, str.ToString()).
			Set(s => s.cpassword, str.ToString()));



		PlayerPrefs.SetString("unme", uname.text);


		SceneManager.LoadScene ("decoratorProfileLogin");



	}



}

