using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    AudioSource getitem;
    GameManager gameManager;
    Score scoreObj;

    void Start ()
    {
        getitem = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreObj = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameManager.playerDie)
        {
            if (other.name == "Player")
            {
                gameManager.playTimeCurrent += 2f;
                scoreObj.AddScore(200);
                getitem.Play();

                if (gameManager.playTimeCurrent > gameManager.playTimeMax)
                {
                    gameManager.playTimeCurrent = gameManager.playTimeMax;
                }
                gameObject.SetActive(false);
            }
        }
        //gameObject.SetActive(false);
    }

}
