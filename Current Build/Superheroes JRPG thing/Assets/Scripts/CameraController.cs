using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject backgroundGO;

    private float offset = 10;

    private Renderer backgroundRend;

    // Use this for initialization
	void Start () {

        backgroundRend = (Renderer)backgroundGO.GetComponent("Renderer");
       
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float camX = Mathf.Clamp(player.transform.position.x, backgroundRend.bounds.min.x + offset, backgroundRend.bounds.max.x - offset);
        //float camY = Mathf.Clamp(transform.position.y, transform.position.y, transform.position.y);

        transform.position = new Vector3(camX, transform.position.y, transform.position.z);

    }



}
