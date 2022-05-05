using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public string Url;

    public void Open()
    {
        //Opens the URL for the survey
        Application.OpenURL(Url);
    }
}
