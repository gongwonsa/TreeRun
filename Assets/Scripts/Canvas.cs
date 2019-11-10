using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    GameObject player;
    GameObject platformLoad;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        platformLoad = GameObject.Find("PlatformLoad");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlatformType(int type)
    {
        if(player.GetComponent<CharMovement>().isExistPlatform())
        {
            print("어억");
            platformLoad.GetComponent<PlatformLoader>().CreatePlatform(type);
        }

    } 
}
