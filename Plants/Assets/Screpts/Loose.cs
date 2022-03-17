using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loose : MonoBehaviour
{
    [SerializeField] Hp hp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp.DecreaseHp();
        Destroy(collision.gameObject);
        FindObjectOfType<LevelController>().MinusAttacker();
    }
}
