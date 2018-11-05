using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour {

    public static Dialogue dia;


    // 3 things needed for the middleman: CREATE PORTRAIT / RUN DIALOUGE / SET DIALOGUE AS DIA
    public static void DialogueMiddleman(GameObject character)
    {
        if (character.GetComponent<TestNPCData>() != null)
        {
            //FindObjectOfType<UIManagerScript>().CreateCharacterPortrait();
            TestNPCData.DialogueTest();
            dia = TestNPCData.dia;
        }
        else if (character.GetComponent<TestNPC2Data>() != null)
        {
            TestNPC2Data.DialogueTest();
            dia = TestNPC2Data.dia;
        }
        else
            Debug.LogError("Middleman isnt working");
    } 
    
    public static void DialogueStateChangeManager(GameObject character, int newState)
    {
        if (character.GetComponent<TestNPCData>() != null)
        {
            TestNPCData.StateChange(newState);
        }
        else if (character.GetComponent<TestNPC2Data>() != null)
        {
            TestNPC2Data.StateChange(newState);
        }
        else
            Debug.LogError("State Manager isnt working");
    }

}
