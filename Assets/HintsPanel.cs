using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsPanel : MonoBehaviour
{
    public GameObject Hints;
    public void OpenPanel()
    {
        if (Hints !=null)
        {
            Hints.SetActive(true);
        }
    }
}

