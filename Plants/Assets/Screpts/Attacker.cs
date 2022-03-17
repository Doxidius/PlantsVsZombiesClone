using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacker : MonoBehaviour
{
    [SerializeField] int health = 200;
    [SerializeField] GameObject deathVFX;
    [SerializeField] int reward;

    GameObject currentTarget;
    Animator animator;
    LevelController controlDeath;

    public delegate void GiveScoreFromDeath(int scores);
    public static event GiveScoreFromDeath OnGiveScoresFromDeath;



    float speed = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controlDeath = FindObjectOfType<LevelController>();
 
    }
    
    public void SetMovSpeed(float speed)
    {
        this.speed = speed * 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        UpdateAnim();
    }
    
    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    private void UpdateAnim()
    {
        if (!currentTarget)
        {
            CancelAtack();
        }
    }

    public void CancelAtack()
    {
        animator.SetBool("isAttacking", false);
       
    }

    public void StrikeCurrrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }
        Defender def = currentTarget.GetComponent<Defender>();
        if (def.GetHealth() != 0)
        {
            def.DealDamage((int)damage);
        }
    }

    public void Death(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnGiveScoresFromDeath?.Invoke(reward);
            controlDeath.MinusAttacker();
            Destroy(this.gameObject);
            DeathVFX();

        }
    }



    void DeathVFX()
    {
       var vfxObj = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(vfxObj, 1f);
    }
}
