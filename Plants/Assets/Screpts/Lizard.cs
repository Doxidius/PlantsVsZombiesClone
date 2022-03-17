using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    GameObject trg;
    Attacker attacker;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D colider)
    {
        trg = colider.gameObject;
        if (trg.GetComponent<Defender>())
        {
            attacker.Attack(trg);
        }
    }

}
