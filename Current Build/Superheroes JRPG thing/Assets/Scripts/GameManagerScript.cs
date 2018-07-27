using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //This is needed to use the Scene manager to change scenes
using UnityEngine;


public class GameManagerScript : MonoBehaviour {

    /*This Script will probably be used for changing scenes for the most part. The Game Manager Object should be in evey scene*/

    [SerializeField]
    public static bool enterCombat = false;
    public static bool exitCombat = false;

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {


        //If entercombat is true the combat scene will load.
        if (enterCombat)
        {
            SceneManager.LoadScene("CombatTesting");
            enterCombat = false;
        }
        if (exitCombat)
        {
            SceneManager.LoadScene("Testing");
            exitCombat = false;
        }

    }

    public void ExitCombat()
    {
        exitCombat = true;
    }
}
