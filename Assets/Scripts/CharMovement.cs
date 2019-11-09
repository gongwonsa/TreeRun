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
        platform.Insert(1, "Flat");
        //prevPlatformName = 
        camera = Camera.main;


    }

    // Update is called once per frame
    void Update()
    {
        CheckPlatform();
        
    }

    void CheckPlatform() {
        
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
                //print("아2");
                //Vector3 pos = camera.WorldToScreenPoint(transform.position);
                //pos = new Vector3(pos.x + 1.0f, pos.y-1.0f, pos.z);
                //transform.position = camera.ScreenToWorldPoint(pos);
                //rb.velocity = new Vector3(7, -5, 0);
            }
            else if (ray.collider.tag == "Flat")
            {
                // 캐릭터 움직임
                gameObject.transform.Translate(new Vector3(1, 0, 0) * speed *Time.deltaTime);
                
                //print("dididsidi");
                //Vector3 pos = camera.WorldToScreenPoint(transform.position);
                //pos = new Vector3(pos.x + 1.0f, pos.y, pos.z);
                //transform.position = camera.ScreenToWorldPoint(pos);

                
            }
        }

    }
}
