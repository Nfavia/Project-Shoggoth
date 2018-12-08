using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestNPC2Data : MonoBehaviour {

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

            DialogueNode node0 = new DialogueNode("Psst, ya got a dollar?", -2, -1, 1);

            DialogueNode node1 = new DialogueNode("Can I have a dollar?", -2, -1, 1);
            DialogueNode node2 = new DialogueNode("Well, nevermind then.", -1, -1, 5);

            DialogueNode node3 = new DialogueNode("Awesome! Thanks!", -1, -1, 3);
            DialogueNode node4 = new DialogueNode("Aww...", -1, -1, 4);

            dialogue.AddNode(node0);
           // dialogue.AddNode(node1);
           // dialogue.AddNode(node3);
           // dialogue.AddNode(node3);
          //  dialogue.AddNode(node4);

            dialogue.AddOption("No, I don't.", node0, node2);
            dialogue.AddOption("Yes, I do.", node0, node1);

            dialogue.AddOption("Hell no!", node1, node4);
            dialogue.AddOption("Yeah, no problem!", node1, node3);

            dia = dialogue;
        }
    }
}
