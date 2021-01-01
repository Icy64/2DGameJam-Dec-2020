using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntNav : MonoBehaviour
{

    // from https://www.youtube.com/watch?v=nEYA3hzZHJ0 aka link2
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    public float MoveSpeed;

    public float atkrange;

    Rigidbody2D rb2d;
    bool isright = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("Distance to player:" + distToPlayer);

        if (distToPlayer < agroRange)
        {
            //chase player code
            ChasePlayer();
        }

        else
        {
            //stop chase code
            StopChase();
        }

        if (distToPlayer < atkrange)
        {
            attackPlayer();
        }
    }

    private void StopChase()
    {

    }

    private void attackPlayer()
    {

    }

    private void ChasePlayer()
    {
        
        if (transform.position.x < player.position.x)
        {
            //enemy to left side so move right
            rb2d.velocity = new Vector2(MoveSpeed, -1);
            isright = true;
        }
        else if (transform.position.x > player.position.x)
        {
            //enemy to right of player so move left
            rb2d.velocity = new Vector2(-MoveSpeed, -1);
            isright = true;
        }
        if (transform.position.y > player.position.y)
        {
            if (isright == true) {
                rb2d.velocity = new Vector2(MoveSpeed, -5);

                    }
            else if (isright == false)
            {
                rb2d.velocity = new Vector2(-MoveSpeed, -5);

            }
        }
    }
}
