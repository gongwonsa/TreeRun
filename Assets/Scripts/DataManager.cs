using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public float score = 0f;
    public float playTimeCurrent = 10f;
    public float playTimeMax = 10;
    public bool PlayerDie = false;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance ==null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
