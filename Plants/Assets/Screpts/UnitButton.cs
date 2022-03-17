using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    [SerializeField] Defender def;

    private void Start()
    {
        SetCost();
    }

    private void SetCost()
    {
        Text text = GetComponentInChildren<Text>();
        if (!text)
        {
            Debug.LogError("нема текста");
        }
        else
        {
            text.text = def.GetCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<UnitButton>();
        foreach(var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.grey;
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<GameArea>().DefenderToSelect(def);
    }
}
