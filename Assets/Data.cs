using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    //ID, random version, trivia
    Dictionary<string, string> states = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
       states.Add("NewYork", "1,NEWYORK,It is on the east side");
    }

    public Dictionary<string,string> data()
    {
        return states;
    }
}
