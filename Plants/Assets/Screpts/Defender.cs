using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost = 100;
    [SerializeField] int health;
    Scores scores;

    private void Start()
    {
        scores = FindObjectOfType<Scores>();
    }
    public int GetCost()
    {
        return cost;
    }
    public int GetHealth()
    {
        return health;
    }
    public void IdleAdd()
    {
        scores.ScoresForSun(7);
    }
    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);

        }
    }
}
