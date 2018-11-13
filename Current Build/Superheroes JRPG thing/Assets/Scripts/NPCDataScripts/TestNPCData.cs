using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestNPCData : MonoBehaviour {

    /*
     * Sooo The purpose of this script is going to be to hold various types of data for a specific character.
     * This could include Dialogue, Character portait Prefabs, etc.
     * We'll see if this works for anything
     * 
     * Example node:
     *      DialogueNode("TEXT", Destination Int[use below guide], State Change int[use below guide], PortraitID Int)
     * 
     * NODE DEST GUIDE:
     * -2 = Options exist for this node
     * -1 = Exit node
     * any other number = the destination Node when there are no options
     * 
     * STATE CHANGE GUIDE:
     * -1 = No state change
     * any other number = What state to change the dialouge to
     * ***This only works for local state atm, at some point I need to figure out how to do this for a global state, which shouldnt be hard...***
     * 
     */
    
    [SerializeField]
    private Image portraitIdle; // Portrait ID: 1
    [SerializeField]
    private Image portraitBlank; // Portrait ID: 2
    [SerializeField]
    private Image portraitHappy; // Portrait ID: 3
    [SerializeField]
    private Image portraitSad; // Portrait ID: 4
    [SerializeField]
    private Image portraitAngry; // Portrait ID: 5

    public static Dialogue dia;

    [SerializeField]
    private static int npcDialogueState;

    public static void StateChange(int value)
    {
        npcDialogueState = value;
    }

    public void SetDialoguePortrait(int portraitID)
    {
        if (portraitID == 1)
            FindObjectOfType<UIManagerScript>().CreateCharacterPortrait(portraitIdle);
        else if (portraitID == 2)
            FindObjectOfType<UIManagerScript>().CreateCharacterPortrait(portraitBlank);
        else if (portraitID == 3)
            FindObjectOfType<UIManagerScript>().CreateCharacterPortrait(portraitHappy);
        else if (portraitID == 4)
            FindObjectOfType<UIManagerScript>().CreateCharacterPortrait(portraitSad);
        else if (portraitID == 5)
            FindObjectOfType<UIManagerScript>().CreateCharacterPortrait(portraitAngry);
    }

    public static void DialogueTest()
    {
        if (npcDialogueState == 0)
        {
            Dialogue dialogue = new Dialogue();

            DialogueNode node0 = new DialogueNode("Hello. How are you?", -2, -1, 1);

            DialogueNode node1 = new DialogueNode("Well that's nice!", 3, -1, 3);
            DialogueNode node2 = new DialogueNode("Sorry to hear it.", 3, -1, 4);

            DialogueNode node3 = new DialogueNode("Hope you have a nice day!", -1, 1, 3);

            dialogue.AddNode(node0);
            dialogue.AddNode(node1);
            dialogue.AddNode(node3);
            dialogue.AddNode(node3);

            dialogue.AddOption("I'm doing good!", node0, node1);
            dialogue.AddOption("I'm horrible...", node0, node2);

            dia = dialogue;
        }
        else if (npcDialogueState == 1)
        {
            Dialogue dialogue = new Dialogue();

            DialogueNode node0 = new DialogueNode("Testing new state fuctionality", -1, 0, 2);

            dialogue.AddNode(node0);

            dia = dialogue;
        }

    }

    

}
