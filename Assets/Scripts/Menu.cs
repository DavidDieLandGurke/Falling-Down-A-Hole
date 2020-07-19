using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public PlayableDirector TimeLine;
    public GameObject LockedCanvas;
    public GameObject UnlockedCanvas;

    void Start()
    {
        if(PlayerPrefs.GetInt("PlayedThroughGame", 0) >= 1)
        {
            UnlockedCanvas.SetActive(true);
        }
        else
        {
            LockedCanvas.SetActive(true);
        }
    }
    
    public void StartGame()
    {
        TimeLine.Play();
        StartCoroutine("LoadLevelAfterCutscene");
    }

    IEnumerator LoadLevelAfterCutscene()
    {
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene("FallingScene");
    }

    public void LoadEndlessFalling()
    {
        SceneManager.LoadScene("EndlessFallingScene");
    }

    public void LoadEndlessStanding()
    {
        SceneManager.LoadScene("EndlessStandingScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
