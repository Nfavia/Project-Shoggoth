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
    [SerializeField]
    private GameObject dialogueOverlay;

    private static bool loadScene;

    private static GameObject GameManagerInstance;

    private void Awake()
    {
        theCanvas.SetActive(true);
        if (GameManagerInstance == null)
        {
            GameManagerInstance = this.gameObject;
            ThingsToNotDestroyOnLoad();
        }
        else
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        canMove = true; //This will be removed once cutscenes and such are added so that it can check if there is a cutscene or immediate dialogue
        dialogueOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        if (loadScene)
            dialogueOverlay.SetActive(true);

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

    private void ThingsToNotDestroyOnLoad()
    {
        GameObject UIManager = GameObject.Find("UIManager");
        GameObject dialogueManager = GameObject.Find("DialogueManager");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(UIManager);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(dialogueManager);
        DontDestroyOnLoad(theCanvas);
        DontDestroyOnLoad(camera);
    }

    public void ExitCombat()
    {
        exitCombat = true;
    }

    public static void TransitionScene(string sceneName)
    {
        //DontDestroyOnLoad(player);
        SceneManager.LoadScene(sceneName);
        //SceneManager.MoveGameObjectToScene(player, SceneManager.GetActiveScene());
        loadScene = true;
    }


}
