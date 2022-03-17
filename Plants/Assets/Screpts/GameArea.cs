using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    Defender spawnDef;
    GameObject defenderParent;
    Scores scores;
    const string DEFENDER_PARENT_NAME = "Defenders";
   // matrix matr;

    private void Start()
    {
        CreateDefenderParent();
        scores = FindObjectOfType<Scores>();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public Vector2 GetCoords()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Debug.Log(mousePos);
        Vector2 worldCoords = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(worldCoords);
        return worldCoords;
    }

    public void DefenderToSelect(Defender def)
    {
        spawnDef = def;
    }

    public Vector2 GridPlace(Vector2 coords)
    {
        float xPos = Mathf.RoundToInt(coords.x);
        float yPos = Mathf.RoundToInt(coords.y);
        return new Vector2(xPos, yPos);
    }

    private void OnMouseDown()
    {        
            SpawnDef(GetCoords());
        
    }

    

    private void SpawnDef(Vector2 coords)
    {
        //Debug.Log("suka ebena " + matr.GetCoordsOfMatrix(Mathf.FloorToInt(GridPlace(coords).x) - 1, Mathf.FloorToInt(GridPlace(coords).y) - 1));
        //if (matr.GetCoordsOfMatrix(Mathf.FloorToInt(GridPlace(coords).x) - 1, Mathf.FloorToInt(GridPlace(coords).y) - 1) == 0)
        //{
        if (scores.GetScores() >= spawnDef.GetCost())
        {
            scores.WasteSuns(spawnDef.GetCost());
            if (spawnDef != null)
            {
                var newDef = Instantiate(spawnDef, GridPlace(coords), Quaternion.identity);
                newDef.transform.parent = defenderParent.transform;
            }
        }
        
        //matr.ChangeToOne(Mathf.FloorToInt(GridPlace(coords).x) - 1, Mathf.FloorToInt(GridPlace(coords).y) - 1);
        //Debug.Log("govno");
        // }

    }
}
