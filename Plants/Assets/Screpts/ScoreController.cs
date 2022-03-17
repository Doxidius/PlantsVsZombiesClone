using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Scores scores;

    private void OnEnable()
    {
        Attacker.OnGiveScoresFromDeath += scores.ScoresForSun;
    }

    private void OnDisable()
    {
        Attacker.OnGiveScoresFromDeath -= scores.ScoresForSun;
    }
}
