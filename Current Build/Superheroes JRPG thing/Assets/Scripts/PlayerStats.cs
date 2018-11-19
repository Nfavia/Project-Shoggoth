using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour {

    //Level Stuff
    public int level = 1;

    //Health and protection stuff
    int health = 100;
    int defense = 10; //Will change later
    public static bool isGuarding;
    int guard = 10;

    //Attack stuffz
    public int attackMod = 10; //The modifier for the strength. Attribute stats may look better as smaller numbers so this changes it to an attack worthy number. CHANGE TO BASE ATTACK MOD?
    int maxDmg;
    int minDmg;
    public int attackDmg;

    //Stat stuff
    int strength = 5;
    //Stats
    //  |
    //  |   
    //  |
    //  |
    //  V

    //I don't even know yet, we will probably have a power data sheet for this sort of stuff.
    public string[] powers;
    

    // Use this for initialization
	void Start ()
    {

        //AttackCalc();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void DamagePlayer(int damage)
    {
        if (isGuarding)
            damage = damage - defense - guard;
        else
            damage = damage - defense;

        if (damage < 0)
            damage = 0;

        health = health - damage; //***PLACEHOLDER***
        Debug.Log("Player Health: " + health);
        Debug.Log("Damage taken: " + damage);

        isGuarding = false;
    }

    // Calculates the attack damage between a range of numbers
    public void AttackCalc()
    {
        maxDmg = strength * attackMod;

        int x = (int)Mathf.Round(maxDmg * .1f); // Gets 10% of the max damage to use in the minimum damage

        minDmg = strength * attackMod - x;

        attackDmg = Random.Range(minDmg, maxDmg);
        Debug.Log(attackDmg);

    }

    

}
