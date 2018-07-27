using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMasterscript : MonoBehaviour {

    public static bool combatTrigger = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has collided with enemy");

            //Tells the GameManager script to change scenes for combat
            GameManagerScript.enterCombat = true;
        }
    }

    //Method to make RNG(***WIP***) a combat scenario based on the enemyID sent by The individual enemy scripts
    public static void ScenarioGenerator(int enemyId)
    {
        if (enemyId == 0)
            Debug.LogError("No EnemyID Detected"); //for debugging
        else if (enemyId == 1)
        {
            Debug.Log("Enemy 1 Detected");
            CombatInitiatorScript.scenarioNum = 1; //sends the scenario # to the CombatInitiator Script
        }

    }

}
