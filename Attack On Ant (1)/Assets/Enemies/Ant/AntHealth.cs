
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AntHealth : MonoBehaviour
{
    //from MELEE to Ant from braackeys
    public int maxHealth = 20;
    int currentHealth;
    public float atkrange;
   
    int castplayerhealth;
    public int DamagePower;
    
    //in order to call to Jaegervvvvv
    public GameObject Jaeger;
    public PlayerCombat script;
    private bool Punchable = true;
    float NextAttackTime = 0f;
   public float AttackRate = 2f;

    //from AntNav
    [SerializeField]
    Transform player;
    Rigidbody2D rb2d;

    //call to AntNav

     AntNav script2;
    



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //coroutines let you add delays without flubbing the code
   


    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < atkrange)
        {
            Fight();


        }
    }



    void Die()
    {
        //disable enemy
        Debug.Log("Enemy died");
        DamagePower = 0;
        //we need to stop motion
        script2 = GetComponent<AntNav>();
        script2.MoveSpeed = 0;
        
    }

    public void Fight()
    {


        //charge time

        if (Time.time >= NextAttackTime)
        {
            {
                //to call to other variables
                script = Jaeger.GetComponent<PlayerCombat>();
                script.Health = script.Health - DamagePower;
                Punchable = false;
                Debug.Log("Ant Punched");
                NextAttackTime = Time.time + 1f / AttackRate;
            }
        }

    }

  
}

