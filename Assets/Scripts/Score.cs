using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    GameObject gameManager;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

	// Update is called once per frame
	void Update()
	{
		ScoreText.text = "Score: " + score.ToString();
	}

    public void GetScore()
    {
        DataManager.Instance.score = DataManager.Instance.score + 4 * Time.deltaTime;
        score =  Mathf.FloorToInt(DataManager.Instance.score);
        
    }
}
