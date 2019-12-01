using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    Camera mainCamera;
    GameObject platformLoad;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = Camera.main;
        platformLoad = GameObject.Find("PlatformLoad");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.transform.position.x - 2 * platformLoad.GetComponent<PlatformLoader>().SetWidth())
        {
            Destroy(gameObject);
        }
    }
}
