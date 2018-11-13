using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode {

    public int NodeID = -1;
    public string Text;
    public List<DialogueOption> Options;
    public int destinationNodeID;
    public int stateChangeValue;
    public int portraitID;

    public DialogueNode(string text, int dest, int stateChng, int portID)
    {
        Text = text;
        Options = new List<DialogueOption>();
        stateChangeValue = stateChng;
        portraitID = portID;
        if (dest != -2)
        {
            this.destinationNodeID = dest;
        }
    }

}
