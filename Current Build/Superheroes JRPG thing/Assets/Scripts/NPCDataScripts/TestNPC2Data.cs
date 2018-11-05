using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestNPC2Data : MonoBehaviour {

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


    public Image characterPortrait;

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

            DialogueNode node0 = new DialogueNode("Psst, ya got a dollar?", -2, -1);

            DialogueNode node1 = new DialogueNode("Can I have a dollar?", -2, -1);
            DialogueNode node2 = new DialogueNode("Well, nevermind then.", -1, -1);

            DialogueNode node3 = new DialogueNode("Awesome! Thanks!", -1, -1);
            DialogueNode node4 = new DialogueNode("Aww...", -1, -1);

            dialogue.AddNode(node0);
            dialogue.AddNode(node1);
            dialogue.AddNode(node3);
            dialogue.AddNode(node3);
            dialogue.AddNode(node4);

            dialogue.AddOption("No, I don't.", node0, node2);
            dialogue.AddOption("Yes, I do.", node0, node1);

            dialogue.AddOption("Hell no!", node1, node4);
            dialogue.AddOption("Yeah, no problem!", node1, node3);

            dia = dialogue;
        }
    }
}
