using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //Opens the scene of the main game
    public void playGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    //Opens the scene for the quiz focused game
    public void playQuiz()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    //Shows the scene for the instructions
    public void playInstructions()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }

    //Hosts the menu for the game
    public void playMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    //Loads the pre survey before playing the quiz game mode
    public void playQuizPreSurvey()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    //Loads the post survey after playing the quiz game mode
    public void playQuizPostSurvey()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    //Lets you choose your difficulty level before playing
    public void playLevelSelect()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }

    public void playSettings()
    {
            SceneManager.LoadScene("settings");
    }
}
