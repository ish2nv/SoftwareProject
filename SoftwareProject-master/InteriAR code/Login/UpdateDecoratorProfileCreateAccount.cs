using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;
using MongoDB.Driver.Builders;
using System.Text.RegularExpressions;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class UpdateDecoratorProfileCreateAccount : MonoBehaviour
{
	public int counter = 0;

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
	public InputField cname;
	public InputField jtitle;

	public Text Title;
	public Text mrstt;


	public Text login;

	public void scenes()  //when user has finished editing their profile and presses the submit button, this method essentially
	                      //updates the users account on the database with the new information user has provided
	{
		counter = 0;
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

		fields6 document = new fields6
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
			companyname = cname.text,
			jobtitle = jtitle.text

		};
		collection.Update (Query.And (
			Query.EQ ("username", PlayerPrefs.GetString ("username"))
		), Update<fields6>.
			Set (s => s.title, Title.text).
			Set (s => s.firstname, fname.text).
			Set (s => s.lastname, lname.text).
			Set (s => s.username, uname.text).
			Set (s => s.age, myage.text).
			Set (s => s.eaddress, mail.text).
			Set (s => s.password, str.ToString ()).
			Set (s => s.cpassword, str.ToString ()).
			Set (s => s.companyname, cname.text).
			Set (s => s.jobtitle, jtitle.text));


		PlayerPrefs.SetString("fname", fname.text);
		PlayerPrefs.SetString("lname", lname.text);
		PlayerPrefs.SetString("username", uname.text);
		PlayerPrefs.SetString("age", myage.text);
		PlayerPrefs.SetString("eaddress", mail.text);
		PlayerPrefs.SetString("mr", Title.text);

		PlayerPrefs.SetString("companyname", cname.text);
		PlayerPrefs.SetString("jobtitle", jtitle.text);


		SceneManager.LoadScene ("decoratorProfile");

	}

}
