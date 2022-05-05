using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizScoring : MonoBehaviour
{
    [SerializeField] public float score = 0;
    //Change value of DEFAULT_POINTS by whatever we decide for in our scoring system per correct answer
    public float DEFAULT_POINTS;
    [SerializeField] Text scoreTxt;
    // Start is called before the first frame update
    public static QuizScoring Instance;

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
        Debug.Log(QuizScoring.Instance.score);
        QuizScoring.Instance.DEFAULT_POINTS = 100;
        QuizScoring.Instance.DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (QuizAnswer.win)
        {
            Debug.Log("Scoring");
            QuizAnswer.win = false;
            QuizScoring.Instance.AddPoints();
            Data.generateQuestion();
            QuizScript.next = true;
            if (QuizScoring.Instance.score == 700.0)
            {
                SceneManager.LoadScene(4, LoadSceneMode.Single);
            }
        }
    }

    //Function to add points to score by value in "points"
    public void AddPoints(float points)
    {
        score += points;
        Debug.Log("score " + score);
        QuizScoring.Instance.DisplayScore();

    }
    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }
    public void DisplayScore()
    {
        scoreTxt = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();

        scoreTxt.text = "Score: " + QuizScoring.Instance.score;
    }
}
