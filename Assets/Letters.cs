using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    string word = null;
    int wordIndex = 0;
    string alpha;

    public Text answerDisplay = null;
    public static int wordSize;
    public static int counter = 0;

    Dictionary<string, string> data = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if (data == null)
        {
            data = GameObject.Find("Question").GetComponent<Data>().data();
            Debug.Log(data["NewYork"]);
        }
        displayPlaceHolder();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void displayPlaceHolder()
    {
        string[] values = data["NewYork"].Split(',');
        wordSize = values[1].Length;
        for (int i = 0; i < values[1].Length; i++)
        { 
            var letterSlot = Resources.Load("Prefab/Placeholder");
            if (values[1].Length >= 5 && values[1].Length < 8)
            {
                //Instantiate(letter, new Vector3(-5.0f + (1.6f * i), 1.5f, 0), Quaternion.identity);
                GameObject newSlot = Instantiate(letterSlot, new Vector3(-200.0f + (75.6f * i), 1.8f, 0), Quaternion.identity) as GameObject;
                newSlot.GetComponent<LetterSlot>().slotIndex = i;
                newSlot.transform.localScale = new Vector3(1, 1, 1);
                newSlot.transform.SetParent(GameObject.FindGameObjectWithTag("SlotHolder").transform, false);
                newSlot.transform.SetSiblingIndex(i);
               

            }
            else if(values[1].Length > 8)
            {
                GameObject newSlot = Instantiate(letterSlot, new Vector3(-330.0f + (65.6f * i), 1.8f, 0), Quaternion.identity) as GameObject;
                newSlot.transform.SetParent(GameObject.FindGameObjectWithTag("SlotHolder").transform, false);
                newSlot.transform.SetSiblingIndex(i);
               
            }
        }
    }
}
