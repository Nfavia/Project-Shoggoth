using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

    public float speed;

    float maxspeed = 10f;
    //float accel = 10f;

    float timer;

    string attackNum;

    Vector3 mousePos;
    GameObject attackPrefab;
    Rigidbody2D rb2d_Attack;
    BoxCollider2D box_Attack;

    private void Awake()
    {

        //Calculating mouse position
        mousePos = Input.mousePosition; 
        mousePos.z = 0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos = mousePos - transform.position;
        

        //Finding and calling the player's script so I can get the name of the current attack
        GameObject thePlayer = GameObject.Find("Player");
        REF_PlayerController playerScript = thePlayer.GetComponent<REF_PlayerController>();
        attackNum = "attack" + playerScript.attackNumber;

        //Sets the timer in relation to real time as well as calling PlayerScript to get despawn time
        float despawntime = playerScript.projectileDespawn;
        timer = Time.time + despawntime;
    }

    void Start()
    {
        
        //Assign attackPrefab and check if it worked
        attackPrefab = GameObject.Find(attackNum);
        if (attackPrefab == null)
        {
            Debug.LogError("Nothing here");
        }

        //Assigning rigidbody and applying velocity in mouse direction
        rb2d_Attack = GetComponent<Rigidbody2D>();
        rb2d_Attack.velocity = mousePos;

        //Assigning Box collider to variable
        box_Attack = GetComponent<BoxCollider2D>();
        if (box_Attack == null)
        {
            Debug.LogError("No Box Collider detected...");
        }
    }


    // Update is called once per frame
    void Update () {
       
        //Timer to destroy the attack object
        if (timer <= Time.time)
        {
            Debug.Log( attackNum +" destroyed.");
            Destroy(attackPrefab);
        }

        //Sets the velocity of the attack
        rb2d_Attack.velocity = maxspeed * (rb2d_Attack.velocity.normalized);

        //Shows in a debug message what the current velocity is.(a bit spammy but works)
        //Debug.Log("velocity is: " + rb2d_Attack.velocity.magnitude);
        
    }

    //Fuction for checking Collision with another object.
    void OnCollisionEnter2D(Collision2D col)
    {
        //Checking if something has actually collided with attack
        if (col.collider != null) {
            //Checks if the tag of the object collided with is an Enemy Tag
            if (col.gameObject.CompareTag("Enemy"))
            {
                //Debug log for testing purposes
                Debug.Log("Collision has happened");
                
                //Destroys the attack after colision happens
                Destroy(attackPrefab.gameObject);

                //
                REF_EnemyController enemy = col.collider.GetComponent<REF_EnemyController>();
                if (enemy != null)
                {
                    Vector2 KnockbackDir = rb2d_Attack.transform.forward;
                    enemy.rb2d_Enemy.velocity = KnockbackDir * 5;
                    enemy.DamageEnemy(0);
                }
            }
        }
    }

}
