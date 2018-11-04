using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode {

    public int NodeID = -1;

    public string Text;

    public List<DialogueOption> Options;

    public int destinationNodeID;

    //public DialogueNode()
    //{
    //    Options = new List<DialogueOption>();
    //}

    public DialogueNode(string text, int dest)
    {
        Text = text;
        Options = new List<DialogueOption>();
        if (dest != -2)
        {
            this.destinationNodeID = dest;
        }
    }

}
