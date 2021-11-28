using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Configs
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 5.0f;
    [SerializeField] float climbSpeed = 5.0f;
    [SerializeField] Vector2 deathFlick = new Vector2(250f, 250f);
    private float horizontalInput;
    private float verticalInput;
    private float playerStartGravity;

    //States
    private bool isAlive = true;
    private bool isRunning = false;

    //component references
    private Animator anim;
    private Rigidbody2D rb;
    private CapsuleCollider2D playerCollider;
    private BoxCollider2D playerFeetCollider; //to prevent wall jumping

    // Using Start() for intialization
    void Start()
    {
        //Setting rigidbody
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        playerStartGravity = rb.gravityScale;
        playerFeetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   

        if(!isAlive){return;} //if player is dead stop the ability to move (the functions bellow will not be executed)

        Run();          //Movement Fucntion
        Jump();         //Jump Function
        ClimbLadder();  //Climb Ladder Function
        FlipPlayer();   //Flip player when moving left or right
        Death();
    }

    //Player Horizontal Movement Function
    private void Run()
    {
        //Player horizonal movement with with arrow keys or WASD keys
        horizontalInput = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        //if player is moving, play the running animation
        if(horizontalInput == 0)
        {
            isRunning = false;
        }else
        {
            isRunning = true;
        }
        anim.SetBool("isRunning", isRunning);
    }
    //Jump Function
    private void Jump()
    {   
        
        bool isTouchingGround = playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        //Jump if space/jump key is pressed and player is on ground (to prevent double jumpping)
        if(Input.GetButtonDown("Jump") && isTouchingGround)
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rb.velocity += jumpVelocity;
        }
    }

    //Climbing Ladder Funtion
    private void ClimbLadder()
    {
        
        bool isTouchingLadder = playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"));

        if(!isTouchingLadder)
        {
            anim.SetBool("IsClimbing", false); //Stop climbing animation if player is not touching ladder
            rb.gravityScale = playerStartGravity; //set player gravity to previous gravity
            return;
        }

        //start climbing
        verticalInput = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
        rb.velocity = climbVelocity;
        rb.gravityScale = 0f; //to stop sliding down

        //If player has vertical velocity, play climbing animation
        bool playerHasVertSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        anim.SetBool("IsClimbing", playerHasVertSpeed);
    }

    private void Death()
    {
        bool collidedWithEnemy = playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy"));

        if(collidedWithEnemy)
        {
            isAlive = false;
            anim.SetTrigger("Die");
            rb.velocity = deathFlick;

        }
    }

    //Flip the player based on horizontal movement
    private void FlipPlayer()
    {

        Vector2 playerScale = transform.localScale;

        if(horizontalInput < 0) //if player is moving left, flip it left
        {
            playerScale.x = -1;
        }
        if(horizontalInput > 0) //if player is moving right, flip it right
        {
            playerScale.x = 1;
        }

        transform.localScale = playerScale;
    }
}
