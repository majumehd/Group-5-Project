using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerHandler : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, firstLetter, lastLetter, hintBar, AnswerBar;
    public static int heart;
    Text inputField;
    public static string input;
    public static bool finish = false;
    public static bool win = false;
    public static bool failed = false;
    public InputField answerInput;
    public Text correctTxt;
    public Text incorrectTxt;
    void Start()
    {
       heart = 3;
       heart1.gameObject.SetActive(true);
       heart2.gameObject.SetActive(true);
       heart1.gameObject.SetActive(true);
       heart1.gameObject.SetActive(true);
       heart1.gameObject.SetActive(true);
       hintBar.gameObject.SetActive(false);
       AnswerBar.gameObject.SetActive(false);
       lastLetter.gameObject.SetActive(false);
       firstLetter.gameObject.SetActive(false);

        if (inputField == null)
        inputField = GameObject.FindGameObjectWithTag("input").GetComponent<Text>();


    }

    void Update()
    {
        switch (heart)
        {
            case 2:
                
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                hintBar.gameObject.SetActive(true);
                firstLetter.gameObject.SetActive(true);
                firstLetter.gameObject.GetComponentInChildren<Text>().text = Letters.values[0][0].ToString();
                break;
            case 1:
                
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                lastLetter.gameObject.SetActive(true);
                lastLetter.gameObject.GetComponentInChildren<Text>().text = Letters.values[0][Letters.values[0].Length - 1].ToString();
                break;
           
            case 0:
                
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                hintBar.gameObject.SetActive(false);
                AnswerBar.gameObject.SetActive(true);
                AnswerBar.gameObject.GetComponentInChildren<Text>().text = Letters.values[0].ToString();
                Invoke("DelayedAction", 1.5f);
                break;

        }
 

        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnClick();
            Debug.Log("Return key was released");
        }
        

    }


    void DelayedAction()
    {
        failed = true;
        Data.generateQuestion();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                decreaseHearts();

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

    public void decreaseHearts()
    {
        heart -= 1;
    }
}
