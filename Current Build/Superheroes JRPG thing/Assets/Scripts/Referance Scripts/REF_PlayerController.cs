using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REF_PlayerController : MonoBehaviour
{

    public float speed;
    public float AtkSpeed;
    private bool Attacking = false;

    private Rigidbody2D rb2d;
    private Transform attack;
    private Transform player;
    private Vector2 KnockbackDir;
    
    //Projectile Variables
    public int attackNumber;
    public Transform projectilePrefab;
    public Transform attackPoint;
    public float projectileSize;
    public float projectileDespawn;
    

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GetComponent<Transform>();
        if (attackPoint == null)
        {
            Debug.LogError("There happens to be no 'FirePoint'");
        }
    }

    void FixedUpdate()
    {
        
        //Sets WASD/Arrow Keys as variables
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        //Makes a Vector for the Player Object to travel on
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //Moves the player on the Vector created by adding force to it.
        rb2d.AddForce(movement * speed);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //RangedAttack();
            MoveAttack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RangedAttack();
            //MoveAttack();
        }
    }

    void MoveAttack()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos = mousePos - transform.position;

        rb2d.velocity = mousePos;

        rb2d.velocity = AtkSpeed * (rb2d.velocity.normalized);
        KnockbackDir = rb2d.velocity;
        Attacking = true;
    }

    //Ranged attack to go with attack prefab, SECONDARY USE
    void RangedAttack()
    {

        attack = (Transform)Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        attack.name = "attack" + attackNumber;
        Debug.Log(attack.name);

        Physics2D.IgnoreCollision(attack.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());


        float size = projectileSize;
        attack.localScale = new Vector3(size, size, size);
        attackNumber++;
        if (attackNumber >= 50)
        {
            attackNumber = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null)
        {
            if (Attacking == true)
            {
                if (col.gameObject.CompareTag("Enemy"))
                {
                    REF_EnemyController enemy = col.collider.GetComponent<REF_EnemyController>();

                    if (enemy != null)
                    {
                        enemy.rb2d_Enemy.velocity = KnockbackDir - enemy.rb2d_Enemy.position;
                        enemy.DamageEnemy(0);
                    }
                }

                Debug.Log("Attack Collision has happned");
                Attacking = false;
            }
        }
    }



}
