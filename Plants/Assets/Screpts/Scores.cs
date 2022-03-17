using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] int currentScores;    

    Text scoresUI;
    

    private void Start()
    {
        scoresUI = GetComponent<Text>();
        scoresUI.text = currentScores.ToString();
    }

    public int GetScores()
    {
        return currentScores;
    }

    public void WasteSuns(int amount)
    {
        if(currentScores>=0)
        currentScores -= amount;
        scoresUI.text = currentScores.ToString();
    }

    public void ScoresForSun(int scores)
    {        
        currentScores += scores;
        scoresUI.text = currentScores.ToString();
    }
}
