﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 10;
    Rigidbody rb;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        camera = Camera.main;


    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        //RaycastHit ray;
        //RaycastHit ray2;
        //Debug.DrawRay(transform.position, new Vector3(0, -1, 0) * 1.0f, Color.green, 100.0f);

        //if (Physics.Raycast(transform.position, new Vector3(0, -1, 0) * 0.5f, out ray))
        //{
        //    print("dkdkdkdkdk");
        //    if (ray.collider.tag == "Up")
        //    {
        //        print(ray.collider.tag);
        //        //Vector3 pos = camera.WorldToScreenPoint(transform.position);
        //        //pos = new Vector3(pos.x + 1.0f, pos.y + 1.0f, pos.z);
        //        //transform.position = camera.ScreenToWorldPoint(pos);

        //        rb.velocity = new Vector3(7, 10, 0);

        //        //Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);               
        //        //transform.position = ray.transform.position;
        //    } else if (ray.collider.tag == "Down")
        //    {
        //        print("아2");
        //        //Vector3 pos = camera.WorldToScreenPoint(transform.position);
        //        //pos = new Vector3(pos.x + 1.0f, pos.y-1.0f, pos.z);
        //        //transform.position = camera.ScreenToWorldPoint(pos);
        //        rb.velocity = new Vector3(7, -5, 0);
        //    }
        //    else
        //    {
        //        print("dididsidi");
        //        //Vector3 pos = camera.WorldToScreenPoint(transform.position);
        //        //pos = new Vector3(pos.x + 1.0f, pos.y, pos.z);
        //        //transform.position = camera.ScreenToWorldPoint(pos);

        //        rb.velocity = new Vector3(5, 0, 0);
        //    }
        //}

        //else
        //{
        //    Vector3 pos = transform.position;
        //    pos = new Vector3(pos.x + 1.0f, pos.y, pos.z);
        //    transform.position = pos;
        //}
    }

    private void FixedUpdate()
    {
        RaycastHit ray;
        RaycastHit ray2;
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0) * 1.0f, Color.green, 100.0f);

        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0) * 0.5f, out ray))
        {
            print("dkdkdkdkdk");
            if (ray.collider.tag == "Up")
            {
                print(ray.collider.tag);
                //Vector3 pos = camera.WorldToScreenPoint(transform.position);
                //pos = new Vector3(pos.x + 1.0f, pos.y + 1.0f, pos.z);
                //transform.position = camera.ScreenToWorldPoint(pos);

                rb.AddForce(new Vector3(rb.mass*Mathf.Sin(26.3f), 0, 0));

                //Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);               
                //transform.position = ray.transform.position;
            }
            else if (ray.collider.tag == "Down")
            {
                rb.AddForce(new Vector3(rb.mass * Mathf.Sin(-26.3f), 0, 0));
                print("아2");
                //Vector3 pos = camera.WorldToScreenPoint(transform.position);
                //pos = new Vector3(pos.x + 1.0f, pos.y-1.0f, pos.z);
                //transform.position = camera.ScreenToWorldPoint(pos);
                rb.velocity = new Vector3(7, -5, 0);
            }
            else if (ray.collider.tag == "Flat")
            {
                rb.AddForce(10, 0, 0);
                print("dididsidi");
                //Vector3 pos = camera.WorldToScreenPoint(transform.position);
                //pos = new Vector3(pos.x + 1.0f, pos.y, pos.z);
                //transform.position = camera.ScreenToWorldPoint(pos);

                rb.velocity = new Vector3(5, 0, 0);
            }
        }

    }
}
