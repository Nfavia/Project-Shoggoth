using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTriggerNPC : MonoBehaviour {

    private bool canTalk;
    public static bool startTalking = false;
    private bool noOptions;

    [SerializeField]
    private GameObject dialogueBubble;
    [SerializeField]
    private GameObject option_1;
    [SerializeField]
    private GameObject option_2;
    [SerializeField]
    private GameObject option_3;

    [SerializeField]
    private GameObject exit; //FOR DEBUG PURPOSES

    private int selected_option = -2;

    [SerializeField]
    private GameObject Overlay;
    [SerializeField]
    private Canvas theCanvas;

    private Dialogue dia;

    private DialogueNode tempNextNode;

    private void Awake()
    {
        
    }

    private void Start()
    {
        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(-1); } );
        


    }

    private void Reset()
    {
        if (Overlay == null)
        {
            Overlay = GameObject.FindGameObjectWithTag("DialogueOverlay");
            Debug.Log("It found it");
            //Overlay.SetActive(false);
        }
        Overlay.SetActive(false);
    }

    private void OnLevelWasLoaded(int level)
    {
        
    }

    // This Update is checking if the player tries to interact with an NPC should that be possible. Yes it's a lot of if statements, get over it
    public void Update()
    {

        if (canTalk)
        {
            if (!startTalking)
            {
                if (Input.GetKeyDown("e"))
                {
                    TriggerDialogue();
                    startTalking = true;
                    GameManagerScript.inConversation = true;
                    return;
                }
            }

            if (noOptions)
            {
                if (Input.GetKeyDown("e"))
                {
                    SetSelectedOption(tempNextNode.destinationNodeID);
                    tempNextNode = null;
                    noOptions = false;
                    return;
                }
            }

        }

    }

    // This Method is to communicate to the Dialogue Manager, telling it to start dialogue using the dialogue script attached to the NPC
    public void TriggerDialogue()
    {
        
        DialogueManagerScript.DialogueMiddleman(this.gameObject);
        dia = DialogueManagerScript.dia;
     
        StartCoroutine(DisplayDialogue());
    }

    public IEnumerator DisplayDialogue()
    {

        Overlay.SetActive(true);

        int node_id = 0;

        while (node_id != -1)
        {
            display_node(dia.Nodes[node_id]);

            selected_option = -2;
            while (selected_option == -2)
            {
                yield return new WaitForSeconds(0.25f);
            }

            if (selected_option == -1)
                EndDialogue();

            node_id = selected_option;
        }
    }

    private void display_node(DialogueNode node)
    {
        if (GameObject.Find("CharacterPortrait"))           //Early Testing, will probalby be changed later so that more than one portrait can be in a scene at once
            Destroy(GameObject.Find("CharacterPortrait"));

        StartCoroutine(TypeSentence(node.Text));

        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);
        Debug.Log("options:" + node.Options.Count);

        if (node.stateChangeValue != -1)
            DialogueManagerScript.DialogueStateChangeManager(this.gameObject, node.stateChangeValue);


        if (node.portraitID > 0)
            DialogueManagerScript.SetDialoguePortrait(this.gameObject, node.portraitID);

        if (node.Options.Count != 0)
        {
            for (int i = 0; i < node.Options.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        set_option_button(option_1, node.Options[i]);
                        break;
                    case 1:
                        set_option_button(option_2, node.Options[i]);
                        break;
                    case 2:
                        set_option_button(option_3, node.Options[i]);
                        break;
                }
            }
        }
        else
        {
            tempNextNode = node;
            noOptions = true;
        }
    }

    private void set_option_button(GameObject button, DialogueOption opt)
    {
        button.SetActive(true);
        button.GetComponentInChildren<Text>().text = opt.Text;
        button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(opt.DestinationNodeID); });
    }

    public void SetSelectedOption(int x)
    {
        selected_option = x;
    }

    // Types out the entire sentence given one letter at a time
    IEnumerator TypeSentence(string sentence)
    {
        dialogueBubble.GetComponentInChildren<Text>().text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueBubble.GetComponentInChildren<Text>().text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of Conversation");

        if (GameObject.Find("CharacterPortrait"))
            Destroy(GameObject.Find("CharacterPortrait"));

        Overlay.SetActive(false);
        startTalking = false;
        GameManagerScript.inConversation = false;
    }

    // Using the Collider2D attached to the NPC Object, it tells if it is being triggered so that you can interact/talk to the NPC
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<UIManagerScript>().CreateTalkIcon();
        canTalk = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<UIManagerScript>().DestroyTalkIcon();
        canTalk = false;
    }

}
