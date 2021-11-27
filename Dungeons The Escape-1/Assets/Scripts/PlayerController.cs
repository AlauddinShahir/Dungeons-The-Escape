using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Configs
    [SerializeField] float runSpeed = 5.0f;
    private float horizontalInput;

    //States
    //private bool isAlive = false;
    private bool isRunning = false;
    //component references
    private Animator anim;
    private Rigidbody2D rb;

    // Using Start() for intialization
    void Start()
    {
        //Setting rigidbody
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Calling Movement Fucntion
        Run();

        //Flip player when moving left or right
        FlipPlayer();
    }

    //Player Horizontal Movement Function
    private void Run()
    {
        //Get horizonal input with arrow keys or WASD keys
        horizontalInput = Input.GetAxis("Horizontal");
        
        //Moving left and right
        transform.Translate(Vector2.right * horizontalInput * runSpeed * Time.deltaTime);
        
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
