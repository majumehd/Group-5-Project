using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    [SerializeField] public float score = 0;
    //Change value of DEFAULT_POINTS by whatever we decide for in our scoring system per correct answer
    const float DEFAULT_POINTS = 100;
    [SerializeField] Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (DropItem.win)
        {
            DropItem.win = false;
            AddPoints();
        }
    }

    //Function to add points to score by value in "points"
    public void AddPoints(float points)
    {
        score += points;
        Debug.Log("score " + score);
        DisplayScore();
       
    }
    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }
    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }
}
