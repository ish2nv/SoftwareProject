using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Linq;

public class fields3 
{
	public string username { get; set; }
}

public class createAccount : MonoBehaviour {

    [SerializeField]
    public InputField mail;
    public InputField fname;
    public InputField lname;
    public InputField uname;
    public InputField pword;
    public InputField cpword;
    public InputField myage;
	public InputField cname;
	public InputField jtitle;


	public Text unameerrormessage;
	public Text pworderrormessage;
	public Text emailerrormessage;


	public GameObject mainerrormessage;



	public Toggle mr, mrs, miss, other;
	public Toggle user, decorator;

    [SerializeField]
    public Button sendButton;

    System.Text.RegularExpressions.Regex mailValidator = new System.Text.RegularExpressions.Regex(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$");

   
    public void Update()    //this method essentially just validates all input fields whenever user edits their profile. for example,
	                    //the password and confirm password fields much match. if not, then an error message will display and the
                            //button that allows you to create an account will be disabled until it is corrected!
    {
		if (user.isOn == true) {
			if (mailValidator.IsMatch (mail.text) && fname.text.Length > 1 && lname.text.Length > 1 && uname.text.Length > 5 && pword.text.Length > 7 && cpword.text.Length > 7 && cpword.text == pword.text && age () > 17  && myage.text.Length > 1) {
				mainerrormessage.SetActive (false);

				sendButton.interactable = true;
			} else {
				mainerrormessage.SetActive (true);

				sendButton.interactable = false;

			}

			if (cpword.text != pword.text) {
				pworderrormessage.color = new Color (255, 0, 0);

				pworderrormessage.text = "error in password!";
			} else {
				pworderrormessage.color = new Color (0, 0, 0);

				pworderrormessage.text = "min 8 characters long";
			}

			if (!mailValidator.IsMatch (mail.text) && mail.text.Length > 0) {
				emailerrormessage.color = new Color (255, 0, 0);

				emailerrormessage.text = "Invalid email! Try again";
			} else {
				emailerrormessage.color = new Color (0, 0, 0);

				emailerrormessage.text = "e.g. hello@gmail.com";
			}


		} else if (decorator.isOn == true) {
			if (mailValidator.IsMatch (mail.text) && fname.text.Length > 1 && lname.text.Length > 1 && uname.text.Length > 5 && pword.text.Length > 7 && cpword.text.Length > 7 && cpword.text == pword.text && age () > 17  && myage.text.Length > 1  && jtitle.text.Length > 3 && cname.text.Length > 2) {
				mainerrormessage.SetActive (false);

				sendButton.interactable = true;
			} else {

				mainerrormessage.SetActive (true);
				sendButton.interactable = false;

			}
			if (cpword.text != pword.text) {
				pworderrormessage.color = new Color (255, 0, 0);

				pworderrormessage.text = "error in password!";
			} else {
				pworderrormessage.color = new Color (0, 0, 0);

				pworderrormessage.text = "min 8 characters long";
			}
			if (!mailValidator.IsMatch (mail.text) && mail.text.Length > 0) {
				emailerrormessage.color = new Color (255, 0, 0);

				emailerrormessage.text = "Invalid email! Try again";
			} else {
				emailerrormessage.color = new Color (0, 0, 0);

				emailerrormessage.text = "e.g. hello@gmail.com";
			}	

		}

		if (user.isOn == false && decorator.isOn == false) {

			sendButton.interactable = false;

		} 
		else if (mr.isOn == false && mrs.isOn == false && miss.isOn == false && other.isOn == false) {
			sendButton.interactable = false;


		}


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

		fields3 document = new fields3
		{
			username = uname.text

		};

		var entityQuery = Query.And(
			Query.EQ("username", uname.text)
		);
		var find = collection.FindOne(entityQuery);
		if (find == null) {

			unameerrormessage.color = new Color (0, 0, 0);

			unameerrormessage.text = "min 6 characters long";
		}


		string ar = find.ToString();
	

		ar = ar.Replace(",", "");
		ar = ar.Replace('"', ' ');

		string[] words = ar.Split(' ');

		if (uname.text == words [27]) {
			unameerrormessage.color = new Color (255, 0, 0);
			unameerrormessage.text = "username already taken!";
			sendButton.interactable = false;

		} 
			
    }
		


    public int age() //turns  the age input field from a string into an integer
    {

		int age = int.Parse(myage.text);
       
		return age;
        
    }
		
}
