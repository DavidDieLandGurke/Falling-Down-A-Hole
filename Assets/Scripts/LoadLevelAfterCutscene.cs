using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterCutscene : MonoBehaviour
{
    public int CutsceneLength;
    public string LevelName;
    public bool IsLastCutscene;

    void Start()
    {
        StartCoroutine("LoadNextLevelAfterCutscene");
    }

    IEnumerator LoadNextLevelAfterCutscene()
    {
        yield return new WaitForSeconds(CutsceneLength);

        if (IsLastCutscene)
        {
            PlayerPrefs.SetInt("PlayedThroughGame", 1);
        }

        SceneManager.LoadScene(LevelName);
    }
}
