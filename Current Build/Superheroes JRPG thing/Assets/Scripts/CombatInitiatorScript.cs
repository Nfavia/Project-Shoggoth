using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInitiatorScript : MonoBehaviour {


    /*All starting positions will probably have to be figured out without the combat position objects. There's no need to use the empty game objects if we don't need to.*/


    [SerializeField]
    private GameObject PlayerCombatPos;
    [SerializeField]
    private GameObject battlePlayer;

    [SerializeField]
    private GameObject[] enemyCombatPos;

    public static int partySize = 1;
    public static int scenarioNum;

    public Transform battlePlayerPrefab;
    public Transform enemy1Prefab;

    private void Awake()
    {
        PlayerCombatPos = GameObject.Find("PlayerBattlePos");

        enemyCombatPos = GameObject.FindGameObjectsWithTag("EnemyCombatPosition");

        //Debug.Log(enemyCombatPos.Length);
    }

    void Start () {
        if (battlePlayer == null)
        {
            //Changes player battle spawn position depending on how many characters are in the party ***WIP***
            if (partySize == 1)
                PlayerCombatPos.transform.position = new Vector2(-3, 5.5f);
            else if (partySize == 2)
                PlayerCombatPos.transform.position = new Vector2(-3, 4);

            //Instantiates the player in the scene and set them to the player combat postion
            battlePlayer = Instantiate(battlePlayerPrefab.gameObject);
            battlePlayer.name = "BtlPlayer";
            battlePlayer.transform.position = PlayerCombatPos.transform.position;

        }
 
        CombatScenarios(scenarioNum); //Calls the CombatScenarios method to set up the generated scenario after the number is set by EnemyMasterscript
    }
	
	void Update () {
        
    }

    //This is one way we could do combat encounters, more discussion on what we are doing here needs to happen
    // ***This will probably be moved to a different script for sake of ease***
    void CombatScenarios(int scenario)
    {
        if (scenario == 0)
            Debug.LogError("No Scenario Selected");
        else if (scenario == 1)
        {
            Debug.Log("Scenario 1 Active");
            
            //Enemy is instantiated in the scene and set to the first enemy combat position
            GameObject Enemy1 = Instantiate(enemy1Prefab.gameObject);
            Enemy1.transform.position = enemyCombatPos[0].transform.position;
        }
    }
}
