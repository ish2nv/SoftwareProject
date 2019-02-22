using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createAccountDecoratorProfile : MonoBehaviour {

    public Text mr;
    public Text fname;
    public Text lname;
    public Text uname;
    public Text age;
    public Text eaddress;
    public Text cname;
    public Text jtitle;
    void Start()  //stores all information inputted in create account screen within the users profile 
    {
        fname.text = fname.text + " " + PlayerPrefs.GetString("fname");
        lname.text = lname.text + " " + PlayerPrefs.GetString("lname");
        uname.text = uname.text + " " + PlayerPrefs.GetString("username");
        age.text = age.text + " " + PlayerPrefs.GetString("age");
        eaddress.text = eaddress.text + " " + PlayerPrefs.GetString("eaddress");
        mr.text = mr.text + " " + PlayerPrefs.GetString("mr");
        cname.text = cname.text + " " + PlayerPrefs.GetString("companyname");
        jtitle.text = jtitle.text + " " + PlayerPrefs.GetString("jobtitle");



    }
}
