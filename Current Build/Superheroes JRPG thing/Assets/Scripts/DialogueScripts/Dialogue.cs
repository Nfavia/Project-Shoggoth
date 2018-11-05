using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string name; 

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
