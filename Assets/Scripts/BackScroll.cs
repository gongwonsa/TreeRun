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

        if (transform.position.x < player.transform.position.x - 3 * backWidth)
        {
            Destroy(gameObject);
        }

          
        if (this.transform.position.y > player.transform.position.y - backHeight && this.transform.position.y < player.transform.position.y + backHeight/*+ backHeight*//* * 2*/)
        {
            
            // x축으로 새로운 배경 만들기
            if (cnt_x == 0 && transform.position.x < player.transform.position.x + backWidth*3f && IsExistBackground(0))
            {
                cnt_x++;
                print("평");
                Instantiate(backGround, new Vector3(transform.position.x + backWidth *1.58f, transform.position.y, transform.position.z), Quaternion.identity);

            }

            // y축으로 새로운 배경 만들기
            if (cnt_y_plus == 0 && transform.position.y > player.transform.position.y && IsExistBackground(1) /*+ backHeight*/)
            {
                cnt_y_plus++;
                print("하");
                Instantiate(backGround, new Vector3(transform.position.x, transform.position.y - 3.023f * backHeight, transform.position.z), Quaternion.identity);
            }

            if (cnt_y_minus == 0 && transform.position.y < player.transform.position.y && IsExistBackground(2) /*- backHeight*/)
            {
                cnt_y_minus++;
                print("위");
                Instantiate(backGround, new Vector3(transform.position.x, transform.position.y + 3.023f * backHeight, transform.position.z), Quaternion.identity);
            }
        }
    }

    private bool IsExistBackground(int dir)
    {
        int layerMask = 1<< this.gameObject.layer;
        //print(layerMask);
        //Ray ray;

        
        // 옆으로 만들 때
        if (dir == 0) {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, 9f), new Vector3(1, 0, 0) * (backWidth + 2.0f), Color.blue, 100.0f);
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, 9f), new Vector3(1,0,0), backWidth + 5.0f, layerMask))
            {
                //print("이거1");
                return false;
            } else
            {
                
                return true;
            }
        }
        else if(dir == 1)
        {
            //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, 9f), new Vector3(0, -1, 0) * (backHeight * 2 + 1.5f), Color.blue, 100.0f);
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, 9f), new Vector3(0, -1, 0), backHeight * 2 + 5f, layerMask))
            {
                //print("이거2");
                return false;
            }
            else
            {
                
                return true;
            }
        } else
        {
            //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, 9f), new Vector3(0, 1, 0) * (backHeight * 2 + 1.5f), Color.blue, 100.0f);
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, 9f), new Vector3(0, 1, 0), backHeight * 2 + 5f, layerMask))
            {
                //print("이거3");
                return false;
            }
            else
            {
                
                return true;
            }
        }
    }
   
}
