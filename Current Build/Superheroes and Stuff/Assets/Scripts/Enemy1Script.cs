using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour {

    [SerializeField]
    private int enemyID = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyMasterscript.ScenarioGenerator(enemyID); //Sends the Enemy ID # to the Enemy Masterscript to start setting up combat scene
    }

    
}
