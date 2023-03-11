using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TotalQuantsScript : MonoBehaviour
{

    public string quantsMessage; //the string to be printed
    public Text txt;            //the text variable of this object
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        Debug.Log(txt);
        FormatText(0, 0, 0, 0);
    }

    /*public void LateStart() 
    {
        txt = gameObject.GetComponent<Text>();
        Debug.Log(txt);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FormatText(int cost, int weight, int carbon, float totTensileStrength)
    {
        txt.text = "Total Cost:     " + cost + "\nTotal Weight: " + weight + "\nTotal C02:      " + carbon + "\nTotal str:      " + totTensileStrength;
        //Debug.Log(txt.text);

    }
}
