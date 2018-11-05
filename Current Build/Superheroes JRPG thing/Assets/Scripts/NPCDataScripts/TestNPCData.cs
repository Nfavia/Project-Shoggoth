using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestNPCData : MonoBehaviour {

    /*
     * Sooo The purpose of this script is going to be to hold various tytpes of data for a specific character.
     * This could include Dialogue, Character portait Prefabs, etc.
     * We'll see if this works for anything
     * 
     * NODE DEST GUIDE:
     * -2 = Options exist for this node
     * -1 = Exit node
     * any other number = the destination Node when there are no options
     */
    
    public Image characterPortrait; //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

    public static Dialogue dia;

    [SerializeField]
    private static int npcDialogueState;

    public static void StateChange(int value)
    {
        npcDialogueState = value;
    }

    public static void DialogueTest()
    {
        if (npcDialogueState == 0)
        {
            Dialogue dialogue = new Dialogue();

            DialogueNode node0 = new DialogueNode("Hello. How are you?", -2, -1);
            DialogueNode node1 = new DialogueNode("Well that's nice!", 3, -1);
            DialogueNode node2 = new DialogueNode("Sorry to hear it.", 3, -1);
            DialogueNode node3 = new DialogueNode("Hope you have a nice day!", -1, 1);

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

            DialogueNode node0 = new DialogueNode("Testing new state fuctionality", -1, 0);

            dialogue.AddNode(node0);

            dia = dialogue;
        }

    }

    

}
