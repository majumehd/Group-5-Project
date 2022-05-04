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
            if (input.ToUpper() == Letters.values[0])
            {
                Debug.Log("CONGRATS");
                win = true;
                finish = false;
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

    public void LetterClick(string letter)
    {
        Text inputField = GameObject.FindGameObjectWithTag("input").GetComponent<Text>();
        inputField.text = "A";

        Debug.Log(letter);
    }
}
