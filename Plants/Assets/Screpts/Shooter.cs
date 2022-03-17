using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const string PROJECTILE_NAME = "Projectiles";

    [SerializeField] GameObject zucini, gun;
    [SerializeField] float speed = 1f;

    GameObject projectile;
    AttackerSpawner mySpawner;

    Animator animator;
    private void Start()
    {
        SetSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectile = GameObject.Find(PROJECTILE_NAME);
        if (!projectile)
        {
            projectile = new GameObject(PROJECTILE_NAME);
        }
    }

    private void Update()
    {
        if (isAttackerLane())
        {
            animator.SetBool("isAttacking", true);

           // Debug.Log("shoot pew pew");

        }
        else
        {
            animator.SetBool("isAttacking", false);
            //Debug.Log("wait");
        }
    }

    public void SetSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        
        foreach(var sp in spawners)
        {
            bool isOnLane = (Mathf.Abs(sp.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isOnLane)
            {
                mySpawner = sp;
            }
        }
    }

    public void Fire()
    {
       var proj = Instantiate(zucini, gun.transform.position, Quaternion.identity);
        proj.transform.parent = projectile.transform;

    }

    private bool isAttackerLane()
    {
        if (mySpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    

}
