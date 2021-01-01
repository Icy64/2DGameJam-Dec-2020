















//https://www.youtube.com/watch?v=sPiVz1k-fEs











using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //public Animator animator; For when we have animations.
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int Health = 100;
    int HealthOld = 100;

    // Start is called before the first frame update
    void Start()
    {
    
    }   

    // Update is called once per frame
    void Update()
    {
        if (HealthOld > Health)
        {
            TakeDamage();
            
        }
        HealthOld = Health;

        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    void TakeDamage()
    {
        Debug.Log("Jaeger Took Damage");
    }
      
    void Attack()
    {
        //animator.SetTrigger ("Attack") 
        //^ This is once we have an animation for attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We Hit " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
