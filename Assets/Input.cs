using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    string word = null;
    int wordIndex = 0;
    string alpha;

    public Text answerDisplay = null;
    string answer;

    Dictionary<string, string> data = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if (data == null)
        {
            data = GameObject.Find("Question").GetComponent<Data>().data();
            Debug.Log(data["NewYork"]);
        }
        displayScramble();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void output(string letters)
    {
        wordIndex++;
        word = word + letters;
        answerDisplay.text = word;
        Debug.Log("Question");
    }

    public void displayScramble()
    {
        string[] values = data["NewYork"].Split(',');
        for (int i = 0; i < values[1].Length; i++)
        {
            char c = values[1][i];
            string location = $"Prefab/{c}";
            var letterRender = Resources.Load(location);
            Instantiate(letterRender, new Vector3(0.5f + (1.2f * i), -2.0f, 0), Quaternion.identity);
        }
    }
}
