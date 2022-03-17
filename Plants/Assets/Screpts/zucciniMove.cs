using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zucciniMove : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 100;
    private void Update()
    {
      transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Attacker>();
        if (health)
        {
            health.Death(damage);
            Destroy(gameObject);
        }
        
    }

    public int DealDamage()
    {
        return damage;
    }
}
