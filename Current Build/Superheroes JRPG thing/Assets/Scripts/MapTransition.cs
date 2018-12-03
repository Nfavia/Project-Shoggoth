using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapTransition : MonoBehaviour {

    [SerializeField]
    private string sceneNameToTransitionTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision == GameObject.Find("Player"))
            GameManagerScript.TransitionScene(sceneNameToTransitionTo);
        Debug.Log("Trigger Working");
    }
}
