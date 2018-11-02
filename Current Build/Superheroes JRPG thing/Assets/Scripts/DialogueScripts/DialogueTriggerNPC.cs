using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTriggerNPC : MonoBehaviour {

    private bool canTalk;
    public static bool startTalking = false;
    public static bool talking;

    public Text dialogueText;

    private GameObject option_1;
    private GameObject option_2;
    private GameObject option_3;
    private GameObject exit;

    private int selected_option = -2;

    public GameObject Overlay;

    private Dialogue dia;

    //private int TEST = 0;

    private void Start()
    {
        //This is going to have to be changewd so that it is interchangeable or might have to be programmed individually, shouldnt be that bad either way


        

        Overlay = GameObject.Find("DialogueOverlay");

        option_1 = GameObject.Find("Option1_btn");
        option_2 = GameObject.Find("Option2_btn");
        option_3 = GameObject.Find("Option3_btn");
        exit = GameObject.Find("Exit_Btn");

        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(-1); } );

        Overlay.SetActive(false);

        Debug.Log(this.name);

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
                    talking = true;
                    return;
                }

            }

            if (talking)
            {

                if (Input.GetKeyDown("e"))
                {
                    //DialogueManagerScript.nextSentence = true;
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
        StartCoroutine(TypeSentence(node.Text));

        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);
        Debug.Log("options:" + node.Options.Count);

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

        dialogueText.text = "";

        //yield return new WaitForSeconds(0.5f); // TEMPORARY for purposes of the test dialogue box

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    void EndDialogue()
    {
        Debug.Log("End of Conversation");
        //animator.SetBool("IsOpen", false);
        Overlay.SetActive(false);
        DialogueTriggerNPC.startTalking = false;
        DialogueTriggerNPC.talking = false;
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
