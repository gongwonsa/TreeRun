using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 2;
    Rigidbody rb;
    Camera camera;
    List<string> platform = new List<string>();
    string prevPlatformName;
    string currentPlatformName;
    GameObject currentPlatform;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = gameObject.GetComponent<Rigidbody>();
        SetFirstPlatform();
        platform.Insert(1, "Flat");
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckPlatform();
        
    }

    // 플레이어가 밟고 있는 플랫폼 다음에 다른 길이 있는 지 확인 
    public bool isExistPlatform() {

        RaycastHit ray;
        print(currentPlatform.tag);
        
        if (currentPlatform.tag == "FlatPlatform")
        {
            if(Physics.Raycast(currentPlatform.transform.position, new Vector3(1, 0, 0) * (((currentPlatform.GetComponent<RectTransform>().rect.width) / 2) + 0.5f), out ray))
            {
                // platform 생성 
                //print("으음");
                return false;
            } else
            {
                //print("으음");
                return true;
            }
        } else
        {
            Debug.DrawRay(currentPlatform.transform.parent.GetChild(2).transform.position, new Vector3(1, 0, 0) * (((currentPlatform.transform.parent.transform.GetChild(2).GetComponent<RectTransform>().rect.width) / 2) + 0.5f), Color.red, 100.0f);
            if (Physics.Raycast(currentPlatform.transform.parent.GetChild(2).transform.position, new Vector3(1, 0, 0) * (((currentPlatform.transform.parent.transform.GetChild(2).GetComponent<RectTransform>().rect.width) / 2) + 0.5f), out ray))
            {
                //print("으음");
                return false;
            } else
            {
                //print("으음");
                return true;
            }
        }

    }

    // 첫번째 플랫폼의 이름을 받아 저장
    void SetFirstPlatform()
    {
        RaycastHit ray;
        Physics.Raycast(transform.position, new Vector3(0, -1, 0) * 0.5f, out ray);
        prevPlatformName = ray.collider.gameObject.name;

    }

    private void FixedUpdate()
    {
        RaycastHit ray;
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0) * 1.0f, Color.green, 100.0f);

        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0) * 0.5f, out ray))
        {
            //print("dkdkdkdkdk");

            // 현재 밟고 있는 플랫폼의 종류와 오브젝트 이름 
            //platform.Insert(0, ray.collider.gameObject.transform.parent.tag);
            currentPlatform = ray.collider.gameObject;
            //print(currentPlatform);
            //print(ray.collider.gameObject.GetComponent<RectTransform>().rect.width);
            //print(newPlatformName);

            if (ray.collider.tag == "Up")
            { 
                // 캐릭터 움직임
                //print(ray.collider.tag);
                gameObject.transform.Translate(new Vector3(1, 0.5f, 0) * speed * Time.deltaTime);
                
            }
            else if (ray.collider.tag == "Down")
            {
                // 캐릭터 움직임
                gameObject.transform.Translate(new Vector3(1,-0.5f, 0) * speed * Time.deltaTime);
                
            }
            else
            {
                // 캐릭터 움직임
                //print("dkdkdkdkdk");
                gameObject.transform.Translate(new Vector3(1, 0, 0) * speed *Time.deltaTime);
            }
        } else
        {
            print("여긴가");
            gameObject.transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            gameManager.PlayerDie();
        }

    }

    public Vector3 SetPlatformPosition()
    {
        //print(currentPlatform.name + " "+ currentPlatform.transform.localPosition);
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
