using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    //public GameObject mapTop;
    //public GameObject mapBottom;
    //public GameObject mapLeft;
    //public GameObject mapRight;

    //public GameObject background;


    public float mapX = 5;
    public float mapY = 100;
    public float weird;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    public Camera cam;


    // Use this for initialization
	void Start () {

        float vertExtent = Camera.main.orthographicSize;

        float horzExtent = vertExtent * Screen.width / Screen.height;

        minX = horzExtent - mapX / 2;
        maxX = mapX / 2 - horzExtent;
        minY = vertExtent - mapY / 2 + weird;
        maxY = mapY / 2 - vertExtent;

        offset = transform.position - player.transform.position;

        //background = (GameObject)GameObject.FindWithTag("Background");

        //float camVertExtent = Camera.main.orthographicSize;
        //float camHorzExtent = Camera.main.aspect * camVertExtent;

        


    }

    void Update()
    {
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX,maxY), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float camX = Mathf.Clamp(player.transform.position.x, minX, maxX);
        float camY = Mathf.Clamp(player.transform.position.y, minY, maxY);

        transform.position = new Vector3(camX, camY, transform.position.z);

        //Vector3 v3 = transform.position;
        //v3.x = Mathf.Clamp(v3.x, minX, maxX);
        //v3.y = Mathf.Clamp(v3.y, minY, maxY);
        //transform.position = v3;
    }



}
