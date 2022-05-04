using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    public static int wordSize;
    public static int counter = 0;
    public static bool next = false;
    public static string[] values;

    Dictionary<int, string> data = null;
    
    // Start is called before the first frame update
    void Start()
    {
        dataUpdate();
       // displayPlaceHolder();
        triviaInitializer();
    }

    // Update is called once per frame
    void Update()
    {
        if (next)
        {
            dataUpdate();
            // displayPlaceHolder();
            triviaInitializer();
            next = false;
        }
    }

    public void dataUpdate()
    {
            data = GameObject.Find("Question").GetComponent<Data>().data();
            values = data[Data.currentQuestion].Split(',');
            Debug.Log(data[1]);
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
        string state = values[0];
        Debug.Log(state);

        Text fact1 = GameObject.FindGameObjectWithTag("T_Fact1").GetComponent<Button>().GetComponentInChildren<Text>();
        Button image = GameObject.FindGameObjectWithTag("T_Image").GetComponent<Button>();
        Text fact2 = GameObject.FindGameObjectWithTag("T_Fact2").GetComponent<Button>().GetComponentInChildren<Text>();

        Sprite currentImage = Resources.Load<Sprite>("Flags/"+state);
        Debug.Log(values[3]);
        Debug.Log(values[4]);
        Debug.Log(values[5]);
        fact1.text = values[3];
        fact2.text = values[4];
        image.GetComponent<Image>().sprite = currentImage;

        Debug.Log(currentImage);
    }
}
