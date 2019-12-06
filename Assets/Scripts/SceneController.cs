using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    string currenScene;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currenScene = SceneManager.GetActiveScene().name;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        print("start7");
        //print(currenScene);
    }

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (gameManager.playerDie == true)
			{

				print(currenScene);
				SceneManager.LoadScene("SampleScene");
			}
			
		}
	}

	void gameoverpanel()
	{ 

	}
}
