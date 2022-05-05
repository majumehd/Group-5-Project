using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    //Unity UI references
    public Slider slider;
    public Text displayText;

    //Create a property to handle the slider's value
    private float currentValue = 0f;
    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
  
        set
        {
            currentValue = value;
            slider.value = currentValue;
            //Show percentage on progress bar in relation to value of slider
            displayText.text = (slider.value * 100).ToString("0.00") + "%";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Used to test bar works
        CurrentValue += .005f;
    }
}
