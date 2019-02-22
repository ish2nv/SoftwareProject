
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class togglesuser : MonoBehaviour
{
    public Toggle user;
    public Toggle decorator;

    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    public GameObject i;
    public GameObject j;
    public GameObject k;
    public GameObject l;
    public GameObject m;
	public GameObject n;
	public GameObject o;
	public GameObject p;
	public GameObject q;


    public void showfields()
    {
        if (user.isOn == true) //if in the create account screen, the user profile toggle is on (i.e. ticked), then make all input
                               //fields stored from letters a to o visible and make letters p and q still invisible (these two input fields
			       //are for decorators only.) else make all input fields stored from letters a to q invisible
        {
            a.SetActive(true);
            b.SetActive(true);
            c.SetActive(true);
            d.SetActive(true);
            e.SetActive(true);
            f.SetActive(true);
            g.SetActive(true);
            h.SetActive(true);
            i.SetActive(true);
            j.SetActive(true);
            k.SetActive(true);
			n.SetActive(true);
			o.SetActive(true);
		
			Debug.Log ("user toggle is on");

        }
        else
        {
            a.SetActive(false);
            b.SetActive(false);
            c.SetActive(false);
            d.SetActive(false);
            e.SetActive(false);
            f.SetActive(false);
            g.SetActive(false);
            h.SetActive(false);
            i.SetActive(false);
            j.SetActive(false);
            k.SetActive(false);
            l.SetActive(false);
            m.SetActive(false);
			n.SetActive(false);
			o.SetActive(false);
			p.SetActive(false);
			q.SetActive(false);
	
        }

    }
}
