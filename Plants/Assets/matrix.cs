using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matrix : MonoBehaviour
{
    int[,] coords;
    // Start is called before the first frame update
    void Start()
    {
        coords = new int[9,5];
        for(int i=0; i < 9; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                coords[i, j] = 0;
            }
            
        }
    }

    public int GetCoordsOfMatrix(int x, int y)
    {
        Debug.Log("govno: "+coords[x, y]);
        
        return coords[x, y];
    }
    public void ChangeToOne(int x, int y)
    {
        coords[x, y] = 1;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
