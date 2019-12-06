﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    GameObject player;
    GameObject platformLoad;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        platformLoad = GameObject.Find("PlatformLoad");
    }

    // Update is called once per frame
    void Update()
    {
        print("아");
    }

    public void SetPlatformType(int type)
    {
        // 현재 밟고 있는 플랫폼 앞에 다른 길이 있는 지 확인 
        if (player.GetComponent<CharMovement>().isExistPlatform() && gameManager.playerDie == false)
        { 
            print("어억");
            platformLoad.GetComponent<PlatformLoader>().CreatePlatform(type);
            int random = Random.Range(0, 100);

            if (random < 90)
            {
                // 0 - 49
                platformLoad.GetComponent<PlatformLoader>().CreateBug();

            }
            else if (90 < random && random < 100)
            {
                // 50 - 89
                platformLoad.GetComponent<PlatformLoader>().CreateObstacle();
            }
            else
            {
                
            }

        }

    } 
}
