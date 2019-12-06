using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Camera mainCamera;
    GameObject player ;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.position = new Vector3(player.transform.position, player.transform.position.y, player.transform.position.z);
        if (gameManager.playerDie == false)
        {
            mainCamera.transform.position = new Vector3(player.transform.position.x + 8, player.transform.position.y + 2, transform.position.z);
        }
    }
}
