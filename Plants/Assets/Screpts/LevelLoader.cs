using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int sceneIndex;
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
        {
            StartCoroutine(loading());
        }
        
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void TimeScaleToNormal()
    {
        Time.timeScale = 1;
    }
    IEnumerator loading()
    {
        yield return new WaitForSeconds(3f);
        
        if (sceneIndex == 0)
        {
            SceneManager.LoadScene(1);
        }       
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex)+1);
    }
}
