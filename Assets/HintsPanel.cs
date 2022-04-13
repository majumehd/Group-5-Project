using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsPanel : MonoBehaviour
{
    public GameObject HintPanel;

    public int chosenHint = 0;

    public GameObject[] hintsObjects;

    void Start()
    {
    }
    void Update()
    {
    
    }

    public void Hints()
    {
        HintPanel.SetActive(true);


        foreach (GameObject hint in hintsObjects)
        {
            hint.SetActive(false);
        }
        hintsObjects[chosenHint].SetActive(true);

        chosenHint++;
        chosenHint = chosenHint % hintsObjects.Length;
    }

}


