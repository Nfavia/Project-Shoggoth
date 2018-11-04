using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    /*
        
        This is a script used to create sentences for individual Objects within the gameworld such as NPCs or Event Controllers.
        It is still very basic so it doesnt have any sort of branching dialogue yet, though this will be implemented at some point.... just not now.
    
    */

    public string name; 

    //[TextArea(3,10)]
    //public string[] sentences; //may be obsolete

    public List<DialogueNode> Nodes;

    public void AddNode(DialogueNode node)
    {

        if (node == null) return;

        Nodes.Add(node);
        node.NodeID = Nodes.IndexOf(node);


    }

    public void AddOption(string text, DialogueNode node, DialogueNode dest)
    {

        if (!Nodes.Contains(dest))
            AddNode(dest);

        if (!Nodes.Contains(node))
            AddNode(node);

        DialogueOption opt;

        if (dest == null)
            opt = new DialogueOption(text, -1);
        else
            opt = new DialogueOption(text, dest.NodeID);

        node.Options.Add(opt);

    }

    public Dialogue()
    {
        Nodes = new List<DialogueNode>();
    }



}
