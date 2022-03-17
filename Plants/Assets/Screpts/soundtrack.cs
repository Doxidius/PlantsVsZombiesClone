using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtrack : MonoBehaviour
{
    AudioSource track;

    private void Start()
    {
        if (FindObjectsOfType<soundtrack>().Length>1)
        {
            Destroy(gameObject);
        }                 
        else
        {
            DontDestroyOnLoad(this);
            track = GetComponent<AudioSource>();
            track.volume = PlayerPrefsController.GetMasterVolume();
        }
                 
        
    }

    public void SetVolume(float vol)
    {
        track.volume = vol;
    }
}
