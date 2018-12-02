using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //This is needed to use the Scene manager to change scenes
using UnityEngine;


public class GameManagerScript : MonoBehaviour {

    /*This Script will probably be used for changing scenes for the most part. The Game Manager Object should be in evey scene*/

    public static bool enterCombat = false;
    public static bool exitCombat = false;
    public static bool canMove;
    public static bool inConversation;

    [SerializeField]
    private GameObject theCanvas;

    private void Awake()
    {
        theCanvas.SetActive(true);
    }

    // Use this for initialization
    void Start ()
    {
        canMove = true; //This will be removed once cutscenes and such are added so that it can check if there is a cutscene or immediate dialogue
    }
	
	// Update is called once per frame
	void Update () {
        //If entercombat is true the combat scene will load.
        if (enterCombat)
        {
            SceneManager.LoadScene("CombatTesting");
            canMove = false;
            enterCombat = false;
        }
        if (exitCombat)
        {
            SceneManager.LoadScene("Testing");
            exitCombat = false;
            canMove = true;
        }

        if (inConversation)
            canMove = false;
        if (!inConversation)
            canMove = true;
    }

    public void ExitCombat()
    {
        exitCombat = true;
    }
}
