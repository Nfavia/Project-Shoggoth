using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestNPCData : MonoBehaviour {

    /*
     * Sooo The purpose of this script is going to be to hold various tytpes of data for a specific character.
     * This could include Dialogue, Character portait Prefabs, etc.
     * We'll see if this works for anything
     */


    public Image characterPortrait;

    public static Dialogue dia;

    public static void DialogueTest()
    {
        Dialogue dialogue = new Dialogue();

        DialogueNode node1 = new DialogueNode("Hello. How are you?");
        DialogueNode node2 = new DialogueNode("Well that's nice!");
        DialogueNode node3 = new DialogueNode("Sorry to hear it.");

        dialogue.AddNode(node1);
        dialogue.AddNode(node2);
        dialogue.AddNode(node3);

        //dialogue.AddOption("Exit", node2, null);
        //dialogue.AddOption("Exit", node3, null);

        dialogue.AddOption("I'm doing good!", node1, node2);
        dialogue.AddOption("I'm horrible...", node1, node3);

        dia = dialogue;
    }

    public static void DialogueTest2()
    {
        Dialogue dialogue = new Dialogue();

        DialogueNode node1 = new DialogueNode("AAAAAAAAAAAAAA");
        DialogueNode node2 = new DialogueNode("Well that's nice!");
        DialogueNode node3 = new DialogueNode("Sorry to hear it.");
   
        dialogue.AddNode(node1);
        dialogue.AddNode(node2);
        dialogue.AddNode(node3);

        dialogue.AddOption("Exit", node2, null);
        dialogue.AddOption("Exit", node3, null);

        dialogue.AddOption("I'm doing good!", node1, node2);
        dialogue.AddOption("I'm horrible...", node1, node3);

        dia = dialogue;
    }

}
