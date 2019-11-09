using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float hp;
    //List<int> platform = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        //platform.Add(0);
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerDie();
    }

    // 플레이어가 죽었는 지 확인하는 함수
    void CheckPlayerDie()
    {
        if(hp <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie ()
    {
        print("게임 오버");
    }

    public float SetHp()
    {
        return hp; 
    }
}
