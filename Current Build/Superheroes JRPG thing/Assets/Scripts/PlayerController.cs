using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float defaultScale;
    
    [SerializeField]
    private GameObject shrinkAnchor;
    [SerializeField]
    private Transform playerFeet;

    private GameObject mainCamera;

    [SerializeField]
    private Animator animator;

    private static PlayerController playerInstance;
  
    void Awake()
    {
        // Assigns components to variables
        rb2d = GetComponent<Rigidbody2D>();

        DontDestroyOnLoad(this);
        if (playerInstance == null)
            playerInstance = this;
        else
            Destroy(gameObject);
        if (shrinkAnchor == null)
            shrinkAnchor = GameObject.Find("ShrinkAnchor");
    }

    void Update()
    {
        //if (shrinkAnchor == null)
        //    shrinkAnchor = GameObject.Find("ShrinkAnchor");

        animator.SetFloat("Speed", rb2d.velocity.magnitude);

        if (Input.GetAxisRaw("Horizontal") < 0 && rb2d.velocity.magnitude > 0)
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            if (animator.GetBool("Forward") == true || animator.GetBool("Back") == true)
            {
                animator.SetBool("Forward", false);
                animator.SetBool("Back", false);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && rb2d.velocity.magnitude > 0)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            if (animator.GetBool("Forward") == true || animator.GetBool("Back") == true)
            {
                animator.SetBool("Forward", false);
                animator.SetBool("Back", false);
            }     
        }
        else if (Input.GetAxisRaw("Vertical") == -1 && Input.GetAxisRaw("Horizontal") == 0 && rb2d.velocity.magnitude > 0)
        {
            animator.SetBool("Forward", true);
            animator.SetBool("Back", false);
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
            }
        }
        else if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == 0 && rb2d.velocity.magnitude > 0)
        {
            animator.SetBool("Back", true);
            animator.SetBool("Forward", false);
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
            }
        }
        //else
        //{
        //    animator.SetBool("Back", false);
        //    animator.SetBool("Right", false);
        //    animator.SetBool("Forward", false);
        //    animator.SetBool("Left", false);
        //}          

        // The y positions of the players feet and Shrink Anchor (The game object whose distance from 0 changes the scaling rate)
        float playerPos = playerFeet.position.y;
        float topPos = shrinkAnchor.transform.position.y;

        float modifier = defaultScale * -1; //The modifier needs to be the negative of whatever the default scale is, otherwise things get fucky

        // Sets the players scale depending on how close to the top the player is.
        transform.localScale = new Vector2(playerPos/topPos * modifier + defaultScale, playerPos / topPos * modifier + defaultScale);
        ///note for matt: just expose some shit and figure out what this is doing...
    }

    void FixedUpdate()
    {


        if (GameManagerScript.canMove)
        { 
        // Sets WASD/Arrow Keys as variables
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Makes a Vector for the Player Object to travel on
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        
        // Moves the player on the Vector created by setting its Velocity
        rb2d.velocity = movement * speed;
        }
    }

}
