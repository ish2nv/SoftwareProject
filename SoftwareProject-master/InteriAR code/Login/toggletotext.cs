using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggletotext : MonoBehaviour {

    public Toggle mr;
    public Toggle mrs;
    public Toggle miss;
    public Toggle other;

    public Toggle decorator;
    public Toggle user;


    public Text togtotext;

    public Text togtotext2;


    public Text mrtxt;
    public Text mrstxt;
    public Text miss2;
    public Text other2;


    public Text decorator2;
    public Text user2;


    public void Start () {  //temp method (NOT CORE METHOD i.e. not important)

        if (mr.isOn == true)
        {
            togtotext.text = mrtxt.text;
        }

        if(mrs.isOn == true)
        {
            togtotext.text = mrstxt.text;

        }
        if (miss.isOn == true)
        {
            togtotext.text = miss2.text;

        }
        if (other.isOn == true)
        {
            togtotext.text = other2.text;

        }

        else if(mr.isOn == false && mrs.isOn == false && miss.isOn == false && other.isOn == false)
        {
            togtotext.text = "Not Specified";
        }
   
        if(decorator.isOn == true)
        {
            togtotext2.text = decorator2.text;

        }

        if(user.isOn == true)
        {
            togtotext2.text = user2.text;
        }

    }
	
	
}
