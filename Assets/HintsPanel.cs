using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsPanel : MonoBehaviour
{
    public GameObject question;
    public GameObject flag;
    public GameObject fact;

    void Start()
    {
        if(question == null || flag == null || fact == null)
        {
            question = GameObject.FindGameObjectWithTag("T_Question");
            flag = GameObject.FindGameObjectWithTag("T_Flag");
            fact = GameObject.FindGameObjectWithTag("T_Fact");
        }

        question.GetComponent<Button>().onClick.AddListener(questionClick);
        flag.GetComponent<Button>().onClick.AddListener(flagClick);
        fact.GetComponent<Button>().onClick.AddListener(factClick);
    }

    public void questionClick()
    {
        question.SetActive(false);
        flag.SetActive(true);
        fact.SetActive(false);
    }

    public void flagClick()
    {
        question.SetActive(false);
        flag.SetActive(false);
        fact.SetActive(true);
    }

    public void factClick()
    {
        question.SetActive(true);
        flag.SetActive(false);
        fact.SetActive(false);
    }

}


