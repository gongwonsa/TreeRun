using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image Timebar;
    public bool isOver;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        //platform.Add(0);
        // hp = 100;
        print(DataManager.Instance.PlayerDie);
        isOver = false;
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update()
    {
        if (DataManager.Instance.PlayerDie == false)
        {
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;
            Timebar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;
            score.GetScore();

            if(DataManager.Instance.playTimeCurrent <0)
            {
                //DataManager.Instance.PlayerDie = true;
                PlayerDie();
            }
        }
        
    }

    public void PlayerDie ()
    {
        DataManager.Instance.PlayerDie = true;
        print("게임 오버");
    }

  
}
