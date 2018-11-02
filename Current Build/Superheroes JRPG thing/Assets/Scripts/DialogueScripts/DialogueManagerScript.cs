using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour {

    public static Dialogue dia;

    public static void DialogueMiddleman(GameObject character)
    {
        if (character.GetComponent<TestNPCData>() != null)
        {
            TestNPCData.DialogueTest();
            dia = TestNPCData.dia;
        }
        else
            Debug.LogError("Manager isnt working");
    }    

}
