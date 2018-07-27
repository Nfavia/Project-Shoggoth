using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Stats : MonoBehaviour {

    
    public static float health = 100;
    public int attackDmg = 20;
    public static float defense = 10;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
            CombatManagerScript.enemyCount--;
        }
	}

    public void DamageEnemy(int damage)
    {
        //Debug.Log("calcualtions being made: " + health + " - " + damage + " + " + defense );
        health = health - damage + defense;
        Debug.Log("Enemy Health: "+ health);
        Debug.Log("Damage taken: "+ damage);
    }
}
