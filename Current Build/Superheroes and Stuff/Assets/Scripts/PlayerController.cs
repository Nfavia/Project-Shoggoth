using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float defaultScale = 10;
    
    public Transform shrinkAnchor;
    public Transform playerFeet;
  
    void Awake()
    {
        // Assigns components to variables
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    void Update()
    {
        
        // The y positions of the players feet and Shrink Anchor (The game object whose distance from 0 changes the scaling rate)
        float playerPos = playerFeet.position.y;
        float topPos = shrinkAnchor.position.y;

        // Sets the players scale depending on how close to the top the player is.
        transform.localScale = new Vector2(playerPos/topPos * -10 + defaultScale, playerPos / topPos * -10 + defaultScale);

        
        
    }

    void FixedUpdate()
    {


        if (!GameManagerScript.enterCombat)
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
