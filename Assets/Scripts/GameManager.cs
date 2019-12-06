using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image Timebar;
    public bool playerDie;
	public GameObject resultPanel;
    DataManager data;
    Score score;
    public float playTimeCurrent = 10;
    public float playTimeMax = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerDie = false;
        playTimeCurrent = 10;
        resultPanel.SetActive(false);
        //DataManager data = GameObject.Find("DataManager").GetComponent<DataManager>();
        score = GameObject.Find("Score").GetComponent<Score>();
        Time.timeScale = 1.0f;
        print("start2");
    }

    void Update()
    {
        if (playerDie == false)
        {
            print("아앙");
            playTimeCurrent -= 0.2f * Time.deltaTime;
            Timebar.fillAmount = playTimeCurrent / playTimeMax;
            //score.AddScore(40* Time.deltaTime);
            print("아앙");

            if (playTimeCurrent <=0)
            {
               // DataManager.Instance.PlayerDie = true;

                PlayerDie();
            }
        }

		if (playerDie == true)
		{
			GameOver();
		}



	}

    private void FixedUpdate()
    {

        if (playerDie == false)
        {
            print("어째서");
            score.AddScore(4 * Time.deltaTime);
        }
    }

    void GameOver()
	{
		print("게임오버");
		resultPanel.SetActive(true);
		//resulttext.text = " your score is " + DataManager.Instance.score;
		Time.timeScale = 0.0f;

	}

	public void PlayerDie ()
    {   
        if (playerDie == false)
            playerDie = true;
        //print("게임 오버");
    }


}
