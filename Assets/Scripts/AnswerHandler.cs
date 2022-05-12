using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerHandler : MonoBehaviour
{
    Text inputField;
    public static string input;
    public static bool finish = false;
    public static bool win = false;
    public InputField answerInput;
    public Text correctTxt;
    public Text incorrectTxt;
    void Start()
    {
       if(inputField == null)
        inputField = GameObject.FindGameObjectWithTag("input").GetComponent<Text>();

    }

    void Update()
    {
       /* if (finish && !win)
        {
            Debug.Log(input);
            
            if (answerInput.text.ToUpper() == Letters.values[0])
            {
                Debug.Log("CONGRATS");
                win = true;
                finish = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
            
                finish = false;
                answerInput.text = "";
                incorrectTxt.StartCoroutine(FadeIncorrect());
            }

        }*/

        

    }

    public void OnClick()
    {

        input = answerInput.text;
        finish = true;
        if (finish && !win)
        {
            Debug.Log(input);
            if (answerInput.text.ToUpper() == Letters.values[0])
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
    }


        public void LetterClick(string letter)
    {
        answerInput.text += letter;

        Debug.Log(letter);
    }
    IEnumerator Correct()
    {
        Debug.Log("CONGRATS");
        
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

        yield return new WaitForSeconds(0);
        win = true;
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
