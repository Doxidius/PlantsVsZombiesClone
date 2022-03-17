using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Scene scene;
    private void Start()
    {
        var index = scene.buildIndex;
        
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
