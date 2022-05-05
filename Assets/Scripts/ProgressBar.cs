using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ProgressBar : FillBar
{
    // Event to invoke when progress bar fills up
    private UnityEvent onProgressComplete;
    private float maxScore = 0;


    // Create a property to handle the slider's value
    
    public new float CurrentValue
    {
        get
        {
            return base.CurrentValue;
        }
        set
        {
            // If the value exceeds the max fill, invoke the completion function
            if (value == slider.maxValue)
                onProgressComplete.Invoke();
            // Remove any overfill
            base.CurrentValue = value % slider.maxValue;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (onProgressComplete == null)
            onProgressComplete = new UnityEvent();
        onProgressComplete.AddListener(OnProgressComplete);
        maxScore = Data.levelPoints * 5;
       

    }

    // Update is called once per frame
    void Update()
    {
        //Edit this value to change the scoring function in relation to the progress bar
        //Find the GameObject "Score", get the component "Scoring" (a script) from it, access the "score" value in it, then assign it to CurrentValue

         CurrentValue = ((GameObject.Find("Score").GetComponent<Scoring>().score) / maxScore);
        // CurrentValue += .005f;
    }

    void OnProgressComplete()
    {
        Debug.Log("Progress Complete");
    }
}