using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine.UI;
using MongoDB.Driver.Builders;
using System.Linq;

public class dontdestroy : MonoBehaviour {

    public Text mr;
    public Text fname;
    public Text lname;
    public Text uname;
    public Text age;
    public Text eaddress;



     void Start()  //this method stores all information about the user within their profile, once they have successfully logged in.
	            //it querys the username & password inputted and if it exists in the database, it will get all information from 
	            //the document that it is stored in within MongoDB and display it in the users profile
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
        uname.text = uname.text + " " + words[27];
        fname.text = fname.text + " " + words[13];
        lname.text = lname.text + " " + words[20];
        age.text = age.text + " " + words[63];
        eaddress.text = eaddress.text + " " + words[70];
        mr.text = mr.text + " " + words[82];


		Debug.Log (mr.text);
		Debug.Log (fname.text);
		Debug.Log (lname.text);
		Debug.Log (uname.text);
		Debug.Log (age.text );
		Debug.Log (eaddress.text);




    }

  

}
