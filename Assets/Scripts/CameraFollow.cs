using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Camera mainCamera;
    GameObject player ;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3 (;
    }
}
