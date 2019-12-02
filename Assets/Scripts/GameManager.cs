using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image Timebar;
    public bool isOver;
	public GameObject resultPanel;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
		resultPanel.SetActive(false);
        print(DataManager.Instance.PlayerDie);
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update()
    {
        if (DataManager.Instance.PlayerDie == false)
        {
            DataManager.Instance.playTimeCurrent -= 0.2f * Time.deltaTime;
            Timebar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;
            score.GetScore();

            if(DataManager.Instance.playTimeCurrent <=0)
            {
               // DataManager.Instance.PlayerDie = true;

                PlayerDie();
            }
        }

		if (DataManager.Instance.PlayerDie == true)
		{
			GameOver();
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
        if (DataManager.Instance.PlayerDie == false)
            DataManager.Instance.PlayerDie = true;
        print("게임 오버");
    }


}
