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

    [TextArea(3,10)]
    public string[] sentences;

}
