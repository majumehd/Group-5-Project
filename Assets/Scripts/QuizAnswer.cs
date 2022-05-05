using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizAnswer : MonoBehaviour
{
    Text inputField;
    public static string input;
    QuizScoring questions;
    public static bool finish = false;
    public static bool win = false;
    void Start()
    {
        if (inputField == null)
        {
            inputField = GameObject.FindGameObjectWithTag("input").GetComponent<Text>();
            questions = GameObject.Find("Question").GetComponent<QuizScoring>();
        }
    }

    void Update()
    {
        if (finish && !win)
        {
            Debug.Log(input);
            if (input.ToUpper() == QuizScript.values[0])
            {
                Debug.Log("This is quiz");
                Debug.Log("CONGRATS");
                win = true;
                finish = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);                
            }
            else
            {
                finish = false;
            }
        }
    }

    public void OnClick()
    {

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
