using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManagerScript : MonoBehaviour
{

    GameObject player;
    GameObject[] allies;
    GameObject enemy;

    GameObject attacker; //used to determine who is attacking and who is being attacked during the "animation"
    GameObject attackee; //Yes it's a real word

    PlayerStats plyrStats;
    Enemy1Stats enemyStats; //enemy stats will need a separate data script that will be made later

    Vector2 playerPos;
    Vector2 enemyPos;

    // Canvas stuff
    public GameObject actionBar;
    public GameObject baseBar;
    public GameObject powersBar;
    public GameObject itemBar;
    public GameObject assessBar;
    public Button attackBtn;
    public Button powersBtn;
    public Button guardBtn;
    public Button itemBtn;
    public Button assessBtn;

    int turnCount;
    int turn;

    public float animSpeed = 5;

    public static int enemyCount;

    bool allyTurn = false;
    bool attackStarted = false;


    public enum CombatStates
    {
        START,
        PLAYERTURN,
        ALLYTURN,
        ENEMYTURN,
        ANIMATION,
        WIN,
        LOSE,
        WAITING
    }

    [SerializeField]
    private CombatStates currentState;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //allies = GameObject.FindGameObjectsWithTag("Ally");

        playerPos = player.transform.position;
        enemyPos = enemy.transform.position;

        enemyStats = enemy.GetComponent<Enemy1Stats>();
        plyrStats = player.GetComponent<PlayerStats>();

        // Sets the amount of turns that the combat session will have
        turnCount = 2;

        //puts the beginning amount of enemies into a static variable that can be changed when an enemy dies.
        enemyCount = 1;

        currentState = CombatStates.START;
        
    }


    void Update()
    {
        

        Debug.Log(currentState);

        //Uses Enum to figure out what part of the turn you're on
        if (currentState == CombatStates.START)
        {
            //Sets up the combat order
            if (enemyCount <= 0)
                currentState = CombatStates.WIN;
            else
                TurnOrder();
        }
        else if (currentState == CombatStates.PLAYERTURN)
        {
            allyTurn = true;

            attackBtn.onClick.AddListener(PlayerAttack); // Attack button
            powersBtn.onClick.AddListener(UsePowers); // Powers button
            guardBtn.onClick.AddListener(Guarding); // Guard Button
            itemBtn.onClick.AddListener(UseItem); // Item Button
            assessBtn.onClick.AddListener(UseAssess);// Assess Button

            currentState = CombatStates.WAITING;
        }
        else if (currentState == CombatStates.ENEMYTURN)
        {

            //turn = 1;
            EnemyAttack();
            //StartCoroutine(WaitTurn(1));
            currentState = CombatStates.WAITING;
        }
        else if (currentState == CombatStates.ALLYTURN)
        {

        }
        //else if (currentState == CombatStates.ANIMATION)
        //{

        //}
        else if (currentState == CombatStates.WIN)
        {
            Debug.Log("All Enemies destroyed, leaving combat");
            StartCoroutine(LeaveCombat(1));
        }
        else if (currentState == CombatStates.LOSE)
        {

        }
        else if (currentState == CombatStates.WAITING)
        {
            
        }

        // Checks if it is your turn to make the action bar appear.
        if (allyTurn)
            //actionBar.SetActive(true);
            baseBar.SetActive(true);
        else
            //actionBar.SetActive(false);
            baseBar.SetActive(false);

    }


    // Used to create(***WIP**) and organize the combat turn order.
    void TurnOrder()
    {
        /*For the time being turns will be set in stone
         the Player will go first then allies then enemies
         We will work on this later*/




        if (turn == 0)
            turn = 1;

        // If statements to determine the current turn ***WIP***
        if (turn == 1)
        {

            currentState = CombatStates.PLAYERTURN;

        }
        else if (turn == 2)
        {
            // Debug.Log("Turn 2 has happened");
            currentState = CombatStates.ENEMYTURN;
        }

    }

    // Advances the turn or resets it.
    void AdvanceTurn()
    {
        if (turn < turnCount)
        {
            turn++;
        }
        else
        {
            turn = 1;
        }
        StartCoroutine(WaitTurn(1));
    }
    
    
    // Method to activate a player attack
    void PlayerAttack()
    {
        allyTurn = false;

        //Removes the listener used to activate this method so it doesnt repeat
        //attackbtn.onClick.RemoveAllListeners();
        RemoveListeners();

        attacker = player;
        StartCoroutine(AttackAnimation());
    }

    void UsePowers()
    {
        /*This will show buttons and such for the powers the current active character has currently*/

        allyTurn = false;

        RemoveListeners();

        powersBar.SetActive(true);
        AdvanceTurn();

    }

    void Guarding()
    {

        allyTurn = false;

        RemoveListeners();

        PlayerStats.isGuarding = true;
        AdvanceTurn();

    }

    void UseItem()
    {

        allyTurn = false;

        RemoveListeners();

        itemBar.SetActive(true);
        AdvanceTurn();

    }

    void UseAssess()
    {

        allyTurn = false;

        RemoveListeners();

        assessBar.SetActive(true);
        AdvanceTurn();

    }


    // Method to activate an enemy attack
    void EnemyAttack()
    {
        attacker = enemy;
        StartCoroutine(AttackAnimation());
    }


    IEnumerator AttackAnimation()
    {
        //Gets the Vector2's needed for the method
        Vector2 startPos = new Vector2(attacker.transform.position.x, attacker.transform.position.y);
        //Vector2 attackeePos = new Vector2(attackee.transform.position.x, attackee.transform.position.y);
        Vector2 midScreen = new Vector2(0, 5.5f);

        
        //this is just to make sure it doesnt run twice while the attack is happening
        if (attackStarted)
            yield break;

        attackStarted = true;

        // Calls a bool to move the attackee and doesn't move on until the bool returns as true, aka finished
        while (MoveTowardsAttackee(midScreen)) { yield return null; }

        //Waits a few seconds in the new position before dealing damage and moving on
        yield return new WaitForSeconds(0.5f);

        //Detemines who the attacker is and deals the correct damage ***This will definently need to be changed later but for now it works as a placeholder***
        if (attacker.CompareTag("Player"))
        {
            plyrStats.AttackCalc();
            enemyStats.DamageEnemy(plyrStats.attackDmg);
        }
        else if (attacker.CompareTag("Enemy"))
        {
            plyrStats.DamagePlayer(enemyStats.attackDmg);
        }
        
        // Moves the attacker to it's starting position
        while (MoveToStart(startPos)) { yield return null; }


        attackStarted = false;

        
        AdvanceTurn();
    }

    //Moves the attacker towards attackee (currently just midscreen) when attacking
    private bool MoveTowardsAttackee(Vector3 target)
    {
        return target != (attacker.transform.position = Vector2.MoveTowards(attacker.transform.position, target, animSpeed * Time.deltaTime ));
    }
    //Moves the attacker back to it's starting position
    private bool MoveToStart(Vector3 target)
    {
        return target != (attacker.transform.position = Vector2.MoveTowards(attacker.transform.position, target, animSpeed * Time.deltaTime));
    }





    // This is used to have a short pause between turns, need to use StartCoroutine(WaitTurn("some number")) to call this
    IEnumerator WaitTurn(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        powersBar.SetActive(false); // ***TEMP***
        itemBar.SetActive(false); // ***TEMP***
        assessBar.SetActive(false); // ***TEMP***

        currentState = CombatStates.START; 
    }

    // This is called when you are leaving combat
    IEnumerator LeaveCombat(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        GameManagerScript.exitCombat = true;
    }

    //Removes the listeners on the buttons so they don't repeat
    private void RemoveListeners()
    {
        attackBtn.onClick.RemoveAllListeners();
        powersBtn.onClick.RemoveAllListeners();
        guardBtn.onClick.RemoveAllListeners();
        itemBtn.onClick.RemoveAllListeners();
        assessBtn.onClick.RemoveAllListeners();
    }


}
