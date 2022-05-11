using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    GameObject[] muteMode;
    GameObject[] unmuteMode;
    private float muteVolume = 0f;
    // Start is called before the first frame update
    void Start()
    {
        muteMode = GameObject.FindGameObjectsWithTag("ShowInMuteMode");
        unmuteMode = GameObject.FindGameObjectsWithTag("ShowInUnmuteMode");
        foreach (GameObject g in muteMode)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mute()
    {
        muteVolume = AudioListener.volume;
        AudioListener.volume = 0f;

        foreach (GameObject g in unmuteMode)
            g.SetActive(false);

        foreach (GameObject g in muteMode)
            g.SetActive(true);


    }

    public void Unmute()
    {
        AudioListener.volume = muteVolume;
        //buttons that should only be showed in mute mode should start off as inactive
        foreach (GameObject g in muteMode)
            g.SetActive(false);

        foreach (GameObject g in unmuteMode)
            g.SetActive(true);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
