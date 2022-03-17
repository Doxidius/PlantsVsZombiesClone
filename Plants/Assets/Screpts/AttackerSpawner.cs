using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool isSpawning = true;
    [SerializeField] Attacker[] attackerSpawner;
    [SerializeField] int minTime = 1;
    [SerializeField] int maxTime = 5;

    LevelController controlAttackers;

    void Start()
    {       
        StartCoroutine(spawner());
        controlAttackers = FindObjectOfType<LevelController>();

    }

    IEnumerator spawner()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Spawn();

        }
    }
    
    public void StopSpawn()
    {
        isSpawning = false;
        StopCoroutine(spawner());
        StopAllCoroutines();
    }

    public void Spawn()
    {
        int index = Random.Range(0, attackerSpawner.Length);
        SpawnerAtt(attackerSpawner[index]);
        controlAttackers.PlusAttacker();

    }

    public void SpawnerAtt(Attacker attacker)
    {
       
        var spawn = Instantiate(attacker, transform.position, Quaternion.identity);
        spawn.transform.parent = transform;
        
    }

}
