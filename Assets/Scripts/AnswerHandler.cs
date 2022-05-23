using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerHandler : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, heart4, heart5, gameOver;
    public static int heart;
    Text inputField;
    public static string input;
    public static bool finish = false;
    public static bool win = false;
    public InputField answerInput;
    public Text correctTxt;
    public Text incorrectTxt;
    void Start()
    {
       heart = 5;
       heart1.gameObject.SetActive(true);
       heart2.gameObject.SetActive(true);
       heart1.gameObject.SetActive(true);
       heart1.gameObject.SetActive(true);
       heart1.gameObject.SetActive(true);
       gameOver.gameObject.SetActive(false);

        if (inputField == null)
        inputField = GameObject.FindGameObjectWithTag("input").GetComponent<Text>();


    }

    void Update()
    {
        if (heart > 5)
            heart = 5;
        switch (heart)
        {
            case 5:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;
            case 4:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(false);
                break;
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                Time.timeScale = 3f;
                gameOver.gameObject.SetActive(true);
                SceneManager.LoadScene("LevelSelect");
                break;

        }
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
