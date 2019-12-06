using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScroll : MonoBehaviour
{

    float backWidth;
    float backHeight;
    int cnt_x = 0;
    int cnt_y_plus = 0;
    int cnt_y_minus = 0;
    Camera mainCamera;
    Vector3 initPosition;
    GameObject player;
    public GameObject backGround;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
        //initPosition = mainCamera.WorldToScreenPoint(transform.position);
        //print(initPosition);
        //GameObject back = GameObject.Find("Background");
        player = GameObject.Find("Player");
        backWidth = this.transform.GetChild(0).GetComponent<RectTransform>().rect.width * 2.19f;
        backHeight = this.transform.GetChild(0).GetComponent<RectTransform>().rect.height * 1.9f;
        print("start4");
    }

    // Update is called once per frame
    void Update()
    {
        ////print(mainCamera.WorldToScreenPoint(transform.position));
        //if (mainCamera.WorldToScreenPoint(transform.position).x > 1920f)
        //{
        //    transform.position = mainCamera.WorldToScreenPoint(new Vector3(transform.position.x - 1920f, transform.position.y, 0f));

        //}

        //if (mainCamera.WorldToScreenPoint(transform.position).y > initPosition.y + 1080f)
        //{
        //    transform.position = mainCamera.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y - 1080f, 0f));
        //}
        //else if (mainCamera.WorldToScreenPoint(transform.position).y < initPosition.y + 1080f)
        //{
        //    transform.position = mainCamera.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1080f, 0f));
        //}

        if (transform.position.x < player.transform.position.x - 2 * backWidth)
        {
            Destroy(gameObject);
        }

          
        if (this.transform.position.y > player.transform.position.y - backHeight/* *2*/ && this.transform.position.y < player.transform.position.y + backHeight/* * 2*/)
        {
            // x축으로 새로운 배경 만들기
            if (cnt_x == 0 && transform.position.x < player.transform.position.x + backWidth*2f)
            {
                cnt_x++;
                print("평");
                Instantiate(backGround, new Vector3(transform.position.x + backWidth * 2, transform.position.y, transform.position.z), Quaternion.identity);

            }

            // y축으로 새로운 배경 만들기
            if (cnt_y_plus == 0 && transform.position.y > player.transform.position.y /*+ backHeight*/)
            {
                cnt_y_plus++;
                print("하");
                Instantiate(backGround, new Vector3(transform.position.x, transform.position.y - 3 * backHeight, transform.position.z), Quaternion.identity);
            }

            if (cnt_y_minus == 0 && transform.position.y < player.transform.position.y/* - backHeight*/)
            {
                cnt_y_minus++;
                print("위");
                Instantiate(backGround, new Vector3(transform.position.x, transform.position.y + 3 * backHeight, transform.position.z), Quaternion.identity);
            }
        }
    }

   
}
