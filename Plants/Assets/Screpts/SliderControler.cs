using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class SliderControler : MonoBehaviour
{
    [Tooltip("Level time in SEC")]
    [SerializeField] float gameTime;

    Slider slider;

    public delegate void SliderEnd();
    public static event SliderEnd onSliderEnded;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad/gameTime;

        if (Time.timeSinceLevelLoad >= gameTime)
        {
            
            Debug.Log("Vse nahui");
            onSliderEnded?.Invoke();
        }
    }
}
