﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPCScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        UIManagerScript.InteractTalk();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        UIManagerScript.StopInteract();
    }

}
