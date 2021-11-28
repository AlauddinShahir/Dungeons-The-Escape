using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //if enemy is facing right, flip it
        FlipEnemy();
    }

    private bool IsFacingRight()
    {
        //check if the enemy is facing right
        return transform.localScale.x > 0;
    }

    private void FlipEnemy()
    {
        if(IsFacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        //change the enemy locale scale accroding to its moving velocity
        transform.localScale = new Vector2 (-(Mathf.Sign(rb.velocity.x)), 1f);    
    }
}
