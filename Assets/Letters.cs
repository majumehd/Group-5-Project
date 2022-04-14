using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    public static int wordSize;
    public static int counter = 0;

    public static string[] values;

    Dictionary<int, string> data = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if (data == null)
        {
            data = GameObject.Find("Question").GetComponent<Data>().data();
            values = data[Data.currentQuestion].Split(',');
            Debug.Log(data[1]);
        }
        displayPlaceHolder();
        triviaInitializer();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void displayPlaceHolder()
    {
        
        wordSize = values[1].Length;
        for (int i = 0; i < values[1].Length; i++)
        { 
            var letterSlot = Resources.Load("Prefab/Placeholder");
            if (values[1].Length >= 5 && values[1].Length < 8)
            {
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

    public void triviaInitializer()
    {
        //3 4 5
        Text question = GameObject.FindGameObjectWithTag("T_Question").GetComponent<Button>().GetComponentInChildren<Text>();
        Button flag = GameObject.FindGameObjectWithTag("T_Flag").GetComponent<Button>();
        Text fact = GameObject.FindGameObjectWithTag("T_Fact").GetComponent<Button>().GetComponentInChildren<Text>();

        Sprite currentFlag = Resources.Load<Sprite>("Flags/NEWYORK");
        Debug.Log(values[3]);
        Debug.Log(values[4]);
        Debug.Log(values[5]);
        question.text = values[3];
        fact.text = values[4];
        flag.GetComponent<Image>().sprite = currentFlag;

        Debug.Log(currentFlag);
    }
}
