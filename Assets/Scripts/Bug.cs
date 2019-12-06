using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    GameManager gameManager;
    Score scoreObj;

    void Start ()
    {
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
