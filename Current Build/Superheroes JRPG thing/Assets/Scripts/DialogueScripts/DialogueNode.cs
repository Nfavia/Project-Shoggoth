using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode {

    public int NodeID = -1;

    public string Text;

    public List<DialogueOption> Options;

    public int destinationNodeID;

    public int stateChangeValue;

    public DialogueNode(string text, int dest, int stateChng)
    {
        Text = text;
        Options = new List<DialogueOption>();
        stateChangeValue = stateChng;
        if (dest != -2)
        {
            this.destinationNodeID = dest;
        }
    }

}
