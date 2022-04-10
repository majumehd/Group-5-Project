using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    [SerializeField] public float score = 0;
    const float DEFAULT_POINTS = 1;
    [SerializeField] Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
