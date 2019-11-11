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
        //mainCamera.transform.position = new Vector3(player.transform.position, player.transform.position.y, player.transform.position.z);
        if (DataManager.Instance.PlayerDie == false)
        {
            mainCamera.transform.position = new Vector3(player.transform.position.x + 8, player.transform.position.y + 2, transform.position.z);
        }
    }
}
