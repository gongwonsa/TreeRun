using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    GameObject gameManager;
    int updateScore = 4;
    float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameManager = GameObject.Find("GameManager");
    }

	// Update is called once per frame
	void Update()
	{
		ScoreText.text = "Score: " + Mathf.FloorToInt(score);
	}

    public void AddScore(float update)
    {
        print(Time.deltaTime);
        score += update;
        
    }

    public float GetScore()
    {
        return score;
    }
}
