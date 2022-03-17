using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider sliderVol;
    [SerializeField] Slider sliderDiff;

    [SerializeField] float defaultVol = 0.5f;
    [SerializeField] float defaultDiff = 1;

    soundtrack strack;
    private void Start()
    {
        sliderVol.value = PlayerPrefsController.GetMasterVolume();
        sliderDiff.value = PlayerPrefsController.GetDifficulty();

        strack = FindObjectOfType<soundtrack>();
    }
    private void Update()
    {
        if (strack)
        {
            strack.SetVolume(sliderVol.value);
        }
        else
        {
            Debug.LogWarning("No music");
        }
    }
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(sliderVol.value);
        PlayerPrefsController.SetDifficulty(sliderDiff.value);
        FindObjectOfType<LevelLoader>().GameOver();        
    }
    public void SetVolToDef()
    {
        sliderVol.value = defaultVol;
        sliderDiff.value = defaultDiff;
    }
}
