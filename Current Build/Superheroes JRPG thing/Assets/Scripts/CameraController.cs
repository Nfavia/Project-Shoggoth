using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject backgroundGO;

    private float offset = 10;

    private Renderer backgroundRend;

    private static CameraController cameraInstance;

    private void Awake()
    {
        if (cameraInstance == null)
            cameraInstance = this;
        else
            Destroy(gameObject);
    }

    void Start () {
        backgroundRend = (Renderer)backgroundGO.GetComponent("Renderer");
    }

    void LateUpdate()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (backgroundGO == null)
        {
            backgroundGO = GameObject.FindGameObjectWithTag("Background");
            backgroundRend = (Renderer)backgroundGO.GetComponent("Renderer");
        }

        float camX = Mathf.Clamp(player.transform.position.x, backgroundRend.bounds.min.x + offset, backgroundRend.bounds.max.x - offset);
        //float camY = Mathf.Clamp(transform.position.y, transform.position.y, transform.position.y);

        transform.position = new Vector3(camX, transform.position.y, transform.position.z);

    }



}
