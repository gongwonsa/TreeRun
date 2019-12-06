using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	static Score instance = null;
    public Text ScoreText;
    GameObject gameManager;
    int updateScore = 4;
    float score;
	float best_score;

	public static Score Instance()
	{
		return instance;
	}
	public void AddScore(float update)
	{
		print(Time.deltaTime);
		score += update;

	}
	public float GetScore()
	{
		if (score > best_score)
		{
			best_score = score;
			SaveBestScore();
		}

		return score;
	}
	public float GetbestScore()
	{
		return best_score;
	}

	// Start is called before the first frame update
	void Start()
    {
        score = 0;
        gameManager = GameObject.Find("GameManager");
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
		LoadBestScore();
    }

	void SaveBestScore()
	{
		PlayerPrefs.SetFloat("Best Score", best_score);
	}
	void LoadBestScore()
	{
		best_score = PlayerPrefs.GetFloat("Best Score", 0);
	}

	// Update is called once per frame
	void Update()
	{
		ScoreText.text = "Score: " + Mathf.FloorToInt(score);
	}

}
