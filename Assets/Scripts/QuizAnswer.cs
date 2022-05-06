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
    public InputField answerInput;
    public Text correctTxt;
    public Text incorrectTxt;
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
     /*   if (finish && !win)
        {
            Debug.Log(input);
            if (answerInput.text.ToUpper() == QuizScript.values[0])
            {
                StartCoroutine(Correct());
               
            }
            else
            {
                finish = false;
                answerInput.text = "";
                incorrectTxt.StartCoroutine(FadeIncorrect());
               
            }
        } */
    }

    public void OnClick()
    {

        input = answerInput.text;
        finish = true;
        if (finish && !win)
        {
            Debug.Log(input);
            if (answerInput.text.ToUpper() == QuizScript.values[0])
            {
                StartCoroutine(Correct());

            }
            else
            {
                finish = false;
                answerInput.text = "";
                incorrectTxt.StartCoroutine(FadeIncorrect());

            }
        }

        // Debug.Log(input);
    }

    public void LetterClick(string letter)
    {
        Text inputField = GameObject.FindGameObjectWithTag("input").GetComponent<Text>();
        inputField.text = "A";

        Debug.Log(letter);
    }

    IEnumerator Correct()
    {
        Debug.Log("This is quiz");
        Debug.Log("CONGRATS");
        win = true;
        finish = false;

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            correctTxt.color = new Color(1, 1, 1, i);
            yield return null;
        }
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            correctTxt.color = new Color(1, 1, 1, i);
            yield return null;
        }

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator FadeIncorrect()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            incorrectTxt.color = new Color(1, 1, 1, i);
            yield return null;
        }
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            incorrectTxt.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
