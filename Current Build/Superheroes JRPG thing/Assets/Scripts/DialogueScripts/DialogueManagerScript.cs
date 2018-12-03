using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour {

    public static Dialogue dia;

    private static DialogueManagerScript DialogueManagerInstance;

    private void Awake()
    {
        if (DialogueManagerInstance == null)
            DialogueManagerInstance = this;
        else
            Destroy(gameObject);
    }

    // 3 things needed for the middleman: RUN DIALOUGE / SET DIALOGUE AS DIA
    public static void DialogueMiddleman(GameObject character)
    {
        if (character.GetComponent<TestNPCData>() != null)
        {
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

    public static void SetDialoguePortrait(GameObject charactrer, int portraitID)
    {
        if (charactrer.GetComponent<TestNPCData>() != null)
            FindObjectOfType<TestNPCData>().SetDialoguePortrait(portraitID);
        else if (charactrer.GetComponent<TestNPC2Data>() != null)
            FindObjectOfType<TestNPC2Data>().SetDialoguePortrait(portraitID);
        else
            Debug.LogError("Portrait isnt being set");
    }

}
