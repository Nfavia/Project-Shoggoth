using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {

    public Canvas theCanvas;

    public Image talkImg;

    public bool exists;
    public static bool talking;
    
    // Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (talking)
        {
            if (!exists)
            {
                Image talkImgTemp = (Image)Instantiate(talkImg, theCanvas.transform);
                talkImgTemp.transform.SetParent(theCanvas.transform);
                talkImgTemp.name = "temp";
                exists = true;
            }
        }
        else
        {
            Destroy(GameObject.Find("temp"));
            exists = false;
        }
            
	}

    public static bool InteractTalk()
    {
        if(!talking)
            talking = true;
        return talking;
    }

    public static bool StopInteract()
    {
        if (talking)
            talking = false;
        return talking;
    }
}
