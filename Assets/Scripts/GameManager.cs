using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image Timebar;
    public bool playerDie;
	public GameObject resultPanel;
	Score bestscore;
	public Text BestScoretxt;
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
		//bestscore = GameObject.Find("Score").GetComponent<Score>();
		Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (playerDie == false)
        {
            //playTimeCurrent -= 0.2f * Time.deltaTime;
            //Timebar.fillAmount = playTimeCurrent / playTimeMax;
            //score.AddScore(40* Time.deltaTime);

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
            //print("어째서");
            score.AddScore(4 * Time.deltaTime);
        }
    }

    void GameOver()
	{
		print("게임오버");
		resultPanel.SetActive(true);
		score.GetbestScore();
		BestScoretxt.text = "Score: " + Mathf.FloorToInt(score.GetbestScore());
	
		Time.timeScale = 0.0f;

	}

	public void PlayerDie ()
    {   
        if (playerDie == false)
            playerDie = true;
        //print("게임 오버");
    }


}
