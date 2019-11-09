using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;
    Camera camera;
    List<string> platform = new List<string>();
    string prevPlatformName;
    string newPlatformName;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        SetFirstPlatform();
        platform.Insert(1, "Flat");
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlatform();
        
    }

    void CheckPlatform() {
        if (newPlatformName != null)
        {
            if (prevPlatformName != newPlatformName)
            {
                
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
            print("dkdkdkdkdk");

            // 현재 밟고 있는 플랫폼의 종류와 오브젝트 이름 
            platform.Insert(0, ray.collider.tag);
            newPlatformName = ray.collider.gameObject.name;
            print(newPlatformName);

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
            else if (ray.collider.tag == "Flat")
            {
                // 캐릭터 움직임
                gameObject.transform.Translate(new Vector3(1, 0, 0) * speed *Time.deltaTime);
                

                
            }
        } else
        {
            // 게임 종료
        }

    }
}
