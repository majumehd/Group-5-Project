using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsPanel : MonoBehaviour
{
    public GameObject fact1;
    public GameObject image;
    public GameObject fact2;

    void Start()
    {
        if(fact1 == null || image == null || fact2 == null)
        {
            fact1 = GameObject.FindGameObjectWithTag("T_Fact1");
            image = GameObject.FindGameObjectWithTag("T_Image");
            fact2 = GameObject.FindGameObjectWithTag("T_Fact2");
        }

        fact1.GetComponent<Button>().onClick.AddListener(fact1Click);
        image.GetComponent<Button>().onClick.AddListener(imageClick);
        fact2.GetComponent<Button>().onClick.AddListener(fact2Click);
    }

    //Based on which component you are looking at, it deactivates the others
    public void fact1Click()
    {
        //change this back once images are fixed
        fact1.SetActive(true);
        image.SetActive(false);
        fact2.SetActive(false);
    }

    public void imageClick()
    {
        fact1.SetActive(false);
        image.SetActive(false);
        fact2.SetActive(true);
    }

    public void fact2Click()
    {
        fact1.SetActive(true);
        image.SetActive(false);
        fact2.SetActive(false);
    }

}


