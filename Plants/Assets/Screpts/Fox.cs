using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator animator;
    Attacker attacker;
    GameObject def;
    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        def = collision.gameObject;
        if (collision.gameObject.CompareTag("Grave"))
        {
            animator.SetTrigger("JumpTrigger");

        }
        else if(def.GetComponent<Defender>())
        {
            attacker.Attack(def);          
        }
    }
}
