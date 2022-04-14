using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DropItem : MonoBehaviour
{
    static public Button clearButton;
    static public Text itemLetter;
    static string[] word;
    static public int amountEntered;
    static public bool finish = false;


    static public string answer;

    void Start()
    {
        word = new string[Letters.wordSize];
        amountEntered = 0;

        if(clearButton == null)
        {
            clearButton = GameObject.FindGameObjectWithTag("Clear_Button").GetComponent<Button>();
        }

        clearButton.onClick.AddListener(ClearView);
        
    }

    void Update()
    {
        if (finish)
        {
            Debug.Log(answer);
            if(answer == "NEWYORK")
            {
                Debug.Log("CONGRATS");
                
            }
        }
    }
 
    public void ClearView()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slots");

        int counter = 0;
        foreach(var slot in slots)
        {
            GameObject.Destroy(slot.GetComponentInChildren<Text>());
            slot.GetComponent<LetterSlot>().occupied = false;
            word[counter]="";
        }
        answer = "";
        amountEntered = 0;
    } 

    public void OnTriggerEnter2D(Collider2D collider)
    {
        bool slotOccupied = gameObject.GetComponent<LetterSlot>().occupied;
        if (!slotOccupied)
        {
            Button itemBeingDragged = collider.gameObject.GetComponent<Button>();
            itemLetter = itemBeingDragged.GetComponentInChildren<Text>();
            itemLetter.transform.SetParent(gameObject.transform, false);

            int letterIndex = gameObject.GetComponent<LetterSlot>().slotIndex;


            Debug.Log(letterIndex);

            word[letterIndex] = itemLetter.text;
            amountEntered++;
            Debug.Log(word);
            Debug.Log(word.Length);

            gameObject.GetComponent<LetterSlot>().occupied = true;

            if(amountEntered == Letters.wordSize)
            {
                wordAssembler();
            }

            Destroy(collider.gameObject);
        }
    }

    public void wordAssembler()
    {
        foreach (var letter in word)
        {
            answer += letter;
        }

        finish = true;
    }
}
