using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {

    private static CanvasScript testCanvasInstance;


    private void Awake()
    {
        if (testCanvasInstance == null)
            testCanvasInstance = this;
        else
            Destroy(gameObject);
    }
}
