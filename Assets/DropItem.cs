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
       if(amountEntered == Letters.wordSize)
        {
            Debug.Log("Match");
            foreach(var letter in word)
            {
                answer += letter;
            }

            if(answer == "NEWYORK")
            {
                Debug.Log("CORRECT");
            }
        }
    }
 
    public void ClearView()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slots");

        foreach(var slot in slots)
        {
            GameObject.Destroy(slot.GetComponentInChildren<Text>());
        }
    } 

    public void OnTriggerEnter2D(Collider2D collider)
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

        Destroy(collider.gameObject);
        
    }
}
