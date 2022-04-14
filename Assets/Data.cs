using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    //ID, random version, trivia
    Dictionary<int, string> states = new Dictionary<int, string>();

    static public int currentQuestion = 1;

    // Start is called before the first frame update
    void Start()
    {
       states.Add(1, "1,NEWYORK,It is on the east side, SLOGAN: THE \"EMPIRE STATE\", STATE BIRD: EASTERN BLUEBIRD, Flags/NEWYORK");
    }

    public Dictionary<int,string> data()
    {
        return states;
    }
}
