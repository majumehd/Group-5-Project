using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hints()
    {
        SceneManager.LoadScene("LightBulb");
    }

    public void AccessHints()
    {
        SceneManager.LoadScene("Hints");
    }

    public void GetHintNewYork()
    {
        scenemanager.LoadScene("One");
        scenemanager.LoadScene("Two");
        scenemanager.LoadScene("Three");

    }
}
