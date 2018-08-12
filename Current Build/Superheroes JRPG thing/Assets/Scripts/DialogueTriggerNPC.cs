using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC : MonoBehaviour {

    private bool canTalk;
    public static bool startTalking = false;
    public static bool talking;

    public Dialogue dialogue;


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
                    DialogueManagerScript.nextSentence = true;
                    return;
                }

            }

        }

    }

    // This Method is to communicate to the Dialogue Manager, telling it to start dialogue using the dialogue script attached to the NPC
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(dialogue);
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
