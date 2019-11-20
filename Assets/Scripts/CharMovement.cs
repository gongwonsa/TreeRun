using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 0.02f;
    Rigidbody rb;
    Camera camera;
    string prevPlatformName;
    string currentPlatformName;
    GameObject currentPlatform;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = gameObject.GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // 플레이어가 밟고 있는 플랫폼 다음에 다른 길이 있는 지 확인 
    public bool isExistPlatform() {

        RaycastHit ray;
        print(currentPlatform.tag);
        
        if (currentPlatform.tag == "FlatPlatform")
        {
            Debug.DrawRay(currentPlatform.transform.position, new Vector3(1, 0, 0) * (((currentPlatform.GetComponent<RectTransform>().rect.width) / 2) + 3.0f), Color.black, 100.0f);
            if (Physics.Raycast(currentPlatform.transform.position, new Vector3(1, 0, 0), out ray, (((currentPlatform.GetComponent<RectTransform>().rect.width) / 2) + 3.0f)))
            {
                print("여기다: " + ray.collider.gameObject.name);
                return false;
            } else
            {
                //print(ray.collider.gameObject.name);
                return true;
            }
        } else
        {
            Debug.DrawRay(currentPlatform.transform.parent.GetChild(2).transform.position, new Vector3(1, 0, 0) * (((currentPlatform.transform.parent.transform.GetChild(2).GetComponent<RectTransform>().rect.width) / 2) + 0.5f), Color.red, 100.0f);
            if (Physics.Raycast(currentPlatform.transform.parent.GetChild(2).transform.position, new Vector3(1, 0, 0), out ray, (((currentPlatform.transform.parent.transform.GetChild(2).GetComponent<RectTransform>().rect.width) / 2) + 0.5f)))
            {
                print("여기다: " + ray.collider.gameObject.name);
                return false;
            } else
            {
                return true;
            }
        }

    }

    private void FixedUpdate()
    {
        RaycastHit ray;
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0) * 1.0f, Color.green, 100.0f);

        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0) * 0.5f, out ray))
        {

            // 현재 밟고 있는 플랫폼의 종류와 오브젝트 이름 
            //platform.Insert(0, ray.collider.gameObject.transform.parent.tag);
            currentPlatform = ray.collider.gameObject;

            if (ray.collider.tag == "Up")
            { 
                // 캐릭터 움직임
                //print(ray.collider.tag);
                gameObject.transform.Translate(new Vector3(0.4f, 0.2f, 0) * speed * Time.deltaTime);
                
            }
            else if (ray.collider.tag == "Down")
            {
                // 캐릭터 움직임
                gameObject.transform.Translate(new Vector3(0.4f,-0.2f, 0) * speed * Time.deltaTime);
                
            }
            else
            {
                // 캐릭터 움직임
                gameObject.transform.Translate(new Vector3(0.4f, 0, 0) * speed *Time.deltaTime);
            }
        } else
        {
            gameObject.transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            gameManager.PlayerDie();
        }

    }

    public Vector3 SetPlatformPosition()
    { 
        if (currentPlatform.tag == "FlatPlatform")
            return currentPlatform.transform.position;
        else
            return currentPlatform.transform.parent.GetChild(1).transform.position;
    }

    public int SetPrevPlatType()
    {
        if (currentPlatform.tag == "FlatPlatform")
        {
            return 0;
        } else {
            if(currentPlatform.transform.parent.tag == "UpPlatform")
            {
                return 1;

            } else
            {
                return 2;
            }
        }
    }

    
}
