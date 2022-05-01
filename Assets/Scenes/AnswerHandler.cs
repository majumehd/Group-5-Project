using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{
    public static string input;
    public static bool finish = false;
    public static bool win = false;
    void Start()
    {
       

    }

    void Update()
    {
        if (finish && !win)
        {
            Debug.Log(input);
            if (input.ToUpper() == "NEWYORK")
            {
                Debug.Log("CONGRATS");
                win = true;
            }
            else
            {
                finish = false;
            }
        }
    }

    public void OnClick()
    {
        Text inputField = GameObject.FindGameObjectWithTag("input").GetComponent<Text>();
        input = inputField.text;
        finish = true;
       // Debug.Log(input);
    }
}
