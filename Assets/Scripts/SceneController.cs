using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public AudioSource playBgm;
    //AudioClip InGameBgm;

    private void Awake()
    {
        playBgm = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        //playBgm.Play();
    }
    public void SceneRoad(string sceneName)
	{
       
        SceneManager.LoadScene(sceneName);
        playBgm.Stop();
    }
}
