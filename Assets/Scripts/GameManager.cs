using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image Timebar;
    
   

   
    
    //List<int> platform = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        //platform.Add(0);
       // hp = 100;
    }

    void Update()
    {
        if (!DataManager.Instance.PlayerDie)
        {
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;

            Timebar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;

            if(DataManager.Instance.playTimeCurrent <0)
            {
                DataManager.Instance.PlayerDie = true;
                PlayerDie();
            }
        }

        
    }

    // 플레이어가 죽었는 지 확인하는 함수
    /*bool CheckPlayerDie()
    {
        if (DataManager.Instance.playTimeCurrent <= 0)
        {
            PlayerDie();
            return true;
        }
        else
            return false;
    }*/

    void PlayerDie ()
    {
        print("게임 오버");
    }

   /* public float SetHp()
    {
        return hp; 
    }*/
}
