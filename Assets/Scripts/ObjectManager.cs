using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    Camera mainCamera;
    GameObject platformLoad;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        platformLoad = GameObject.Find("PlatformLoad");
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.WorldToScreenPoint(transform.position).x < -(platformLoad.GetComponent<PlatformLoader>().SetWidth()))
        {
            Destroy(gameObject);
        }
    }
}
