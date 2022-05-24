using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    [SerializeField] public float score = 0;
    [SerializeField] public float fakeScore = 0;
    //Change value of DEFAULT_POINTS by whatever we decide for in our scoring system per correct answer
    public float DEFAULT_POINTS;
    [SerializeField] Text scoreTxt;
    // Start is called before the first frame update
    public static Scoring Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Debug.Log("Score from instance");
        Debug.Log(Scoring.Instance.score);
        Scoring.Instance.DEFAULT_POINTS = Data.levelPoints;
        Scoring.Instance.DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (AnswerHandler.win)
        {
            AnswerHandler.win = false;
            Scoring.Instance.AddPoints();
            Data.generateQuestion();
            Letters.next = true;
        }
        if(!Data.complete)
          DisplayScore();

        if (AnswerHandler.failed)
        {
            AnswerHandler.failed = false;
            Scoring.Instance.FakePoints();
           
        }
    }

    //Function to add points to score by value in "points"
    public void AddPoints(float points)
    {
        score += points;
        Debug.Log("score " + score);
        Scoring.Instance.DisplayScore();
       
    }
    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void FakePoints()
    {
        fakeScore += DEFAULT_POINTS;
    }

    public void DisplayScore()
    {
        scoreTxt = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();

        scoreTxt.text = "Score: " + Scoring.Instance.score;
    }
}
