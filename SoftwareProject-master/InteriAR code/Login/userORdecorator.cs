using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;
using MongoDB.Driver.Builders;
using System.Text.RegularExpressions;

public class fields2 
{
    public ObjectId Id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string cpassword { get; set; }
	public string day { get; set; }
	public string month { get; set; }
	public string year { get; set; }


    public string age { get; set; }
    public string eaddress { get; set; }
	public string phonenumber { get; set; }

    public string title { get; set; }
    public string account { get; set; }
    public string companyname { get; set; }
    public string jobtitle { get; set; }


	public string directory1 { get; set; }
	public string directory2 { get; set; }

	public string directory3 { get; set; }
	public string directory4 { get; set; }
	public string directory5 { get; set; }
	public string directory6 { get; set; }



}

public class userORdecorator : MonoBehaviour
{
    public int counter = 0;
    public Toggle user;
    public Toggle decorator;

    public Toggle title;
    public Toggle title2;
    public Toggle title3;
    public Toggle title4;

    public InputField inputitle;

    public InputField mail;
    public InputField fname;
    public InputField lname;
    public InputField uname;
    public InputField pword;
    public InputField cpword;
    public InputField myage;
    public InputField companyname;
    public InputField jobtitle;

    public Text Title;
    public Text mrstt;

    public Text accounts;
    public Text login;

	public Text errormessage;

	public GameObject loading;
	public GameObject errormessage2;

    public void scenes() //if user toggle in create account screen was on (i.e. ticked), then store it in the database as a user account 
                         //and load up theuserProfile screen. Else if decorator toggle in create account screen was on 
			 //(i.e. ticked), then store it in the database as a decorator account and load up the decoratorProfile screen
    {
        counter = 0;
        if (user.isOn == true)
        {
            Debug.Log("successful");
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

            fields2 document = new fields2
            {
                Id = ObjectId.GenerateNewId(),
                username = uname.text,
                firstname = fname.text,
                lastname = lname.text,
                eaddress = mail.text,
                password = str.ToString(),
                cpassword = str.ToString(),
                age = myage.text,
                title = Title.text,
                account = accounts.text

            };
            collection.Save(document);
            PlayerPrefs.SetString("fname", fname.text);
            PlayerPrefs.SetString("lname", lname.text);
            PlayerPrefs.SetString("username", uname.text);
            PlayerPrefs.SetString("age", myage.text);
            PlayerPrefs.SetString("eaddress", mail.text);
            PlayerPrefs.SetString("mr", Title.text);
            PlayerPrefs.SetString("account", accounts.text);

            SceneManager.LoadScene("userProfileCreateAccount");

        }
        else if (decorator.isOn == true)
        {
            Debug.Log("successful");
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

            fields2 document = new fields2
            {
                Id = ObjectId.GenerateNewId(),
                username = uname.text,
                firstname = fname.text,
                lastname = lname.text,
                eaddress = mail.text,
                password = str.ToString(),
                cpassword = str.ToString(),
                age = myage.text,
                title = Title.text,
                account = accounts.text,
                companyname = companyname.text,
                jobtitle = jobtitle.text

            };
            collection.Save(document);
            PlayerPrefs.SetString("fname", fname.text);
            PlayerPrefs.SetString("lname", lname.text);
            PlayerPrefs.SetString("username", uname.text);
            PlayerPrefs.SetString("age", myage.text);
            PlayerPrefs.SetString("eaddress", mail.text);
            PlayerPrefs.SetString("mr", Title.text);
            PlayerPrefs.SetString("account", accounts.text);
            PlayerPrefs.SetString("companyname", companyname.text);
            PlayerPrefs.SetString("jobtitle", jobtitle.text);

            SceneManager.LoadScene("decoratorProfile");


        }
    }


    public void ourmethod() //evaluates the username and password inputted in the login screen. if it exists in the database, then it will
                            //load up the users profile. if it doesn't exist, then an error message is displayed and user still be stuck on
			    //the login screen, until they input a valid username and password
	{
		var name = "ishtiyaq";
		var pass = "1234";
		var dbname = "decorators";
		var uri = "mongodb://" + name + ":" + pass + "@ds119268.mlab.com:19268/decorators";

		MongoClient client = new MongoClient (uri);

		var server = client.GetServer ();
		var db = server.GetDatabase (dbname);
		var collection = db.GetCollection<BsonDocument> ("systemdecorators");


		MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider ();
		md5.ComputeHash (ASCIIEncoding.ASCII.GetBytes (pword.text));
		byte[] result = md5.Hash;
		StringBuilder str = new StringBuilder ();

		for (int i = 1; i < result.Length; i++) {
			str.Append (result [i].ToString ("x2"));
		}
		fields2 a = new fields2 {
			username = uname.text,
			password = str.ToString ()
		};
		var entityQuery = Query.And (
			                        Query.EQ ("username", a.username),
			                        Query.EQ ("password", a.password)
		                        );
		var find = collection.FindOne (entityQuery);
		if (find == null) {
			errormessage2.SetActive (true);
		} else {

			errormessage2.SetActive (false);

		}
		string ar = find.ToString ();
		int count = new Regex (Regex.Escape (a.username)).Matches (ar).Count;
		int count2 = new Regex (Regex.Escape (a.password)).Matches (ar).Count;
		loading.SetActive (false);


		if (count > 0 && count2 > 0) {
			loading.SetActive (true);

			ar = ar.Replace (",", "");
			ar = ar.Replace ('"', ' ');
			string[] words = ar.Split (' ');
			if (words [89] == "User") {
				PlayerPrefs.SetString ("unme", uname.text);
				PlayerPrefs.SetString ("pword4", pword.text);
				Invoke( "ChangeLevel", 4.0f );
			} else if (words [89] == "Decorator") {
				PlayerPrefs.SetString ("unme", uname.text);
				PlayerPrefs.SetString ("pword4", pword.text);
				Invoke( "ChangeLevel2", 4.0f );
			} 
      
		}
	}
	void ChangeLevel() {
		Application.LoadLevel ("userProfile");  
	}
	void ChangeLevel2() {
		Application.LoadLevel ("decoratorProfileLogin");  
	}

			}
