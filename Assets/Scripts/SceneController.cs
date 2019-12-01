using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    string currenScene;

    // Start is called before the first frame update
    void Start()
    {
        currenScene = SceneManager.GetActiveScene().name;
        //print(currenScene);
    }

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (DataManager.Instance.PlayerDie == true)
			{

				print(currenScene);
				SceneManager.LoadScene(currenScene);
			}
			DataManager.Instance.PlayerDie = false;
			DataManager.Instance.score = 0.0f;
		}
	}

	void gameoverpanel()
	{ 

	}
}
