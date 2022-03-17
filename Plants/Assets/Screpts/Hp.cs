using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    [SerializeField] float baseLives = 4;
    Text hpText;
    float hp;

    private void Start()
    {
        hp = baseLives - PlayerPrefsController.GetDifficulty();
        hpText = GetComponent<Text>();
        hpText.text = hp.ToString();
    }

    public void DecreaseHp()
    {
        if (hp <= 0)
        {
            return;
        }
            hp--;
            hpText.text = hp.ToString();
        
        
        if (hp == 0)
        {
            
            //FindObjectOfType<SceneLoader>().GameOver();
            FindObjectOfType<LevelController>().Loosed();
        }
    }
}
