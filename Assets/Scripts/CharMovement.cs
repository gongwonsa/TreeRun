using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 0.5f;
    Rigidbody rb;
    Camera camera;
    string prevPlatformName;
    string currentPlatformName;
    GameObject currentPlatform;
    GameObject gameManager;
	SpriteRenderer renderer;
    Score scoreObj;
    //int score = 0f;
	float deadtime = 0f;
	bool deadtimebool = false;
	bool isUnBearTime = true;
    float dieTime = 2f;

    // Start is called before the first frame update
    void Start()
	{

		renderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
		gameManager = GameObject.Find("GameManager");
        rb = gameObject.GetComponent<Rigidbody>();
        scoreObj = GameObject.Find("Score").GetComponent<Score>();
        camera = Camera.main;
        print("start5");

    }

    private void Update()
    {

        if (deadtimebool == true)
        {
            deadtime += Time.deltaTime;
        }


        RaycastHit ray;
        Debug.DrawRay(transform.position, new Vector3(0, -1, 0) * 1.5f, Color.green, 100.0f);

        if (scoreObj.GetScore() % 10 < 1)
        {
			if (scoreObj.GetScore() %1000 <500)
			{
				speed += 0.05f;
			}
			else if (scoreObj.GetScore() %1000 >500)
			{
				speed += 0.01f;
			}
        }


        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out ray, 1.5f))
        {

            // 현재 밟고 있는 플랫폼의 종류와 오브젝트 이름
            //platform.Insert(0, ray.collider.gameObject.transform.parent.tag);
            currentPlatform = ray.collider.gameObject;

            if (ray.collider.tag == "Up")
            {
                // 캐릭터 움직임
                //print(ray.collider.tag);
                print("1");
                gameObject.transform.Translate(new Vector3(0.4f * speed * Time.smoothDeltaTime, 0.2f * speed * Time.smoothDeltaTime, 0));
                deadtime = 0.0f;

            }
            else if (ray.collider.tag == "Down")
            {
                // 캐릭터 움직임
                print("2");
                gameObject.transform.Translate(new Vector3(0.4f * speed * Time.smoothDeltaTime, -0.2f * speed * Time.smoothDeltaTime, 0));
                deadtime = 0.0f;

            }
            else
            {
                // 캐릭터 움직임
                print("3");
                gameObject.transform.Translate(new Vector3(0.4f * speed * Time.smoothDeltaTime, 0, 0));
                deadtime = 0.0f;
            }
        }
        else
        {
            gameObject.transform.Translate(new Vector3(3.5f * Time.smoothDeltaTime, -7.5f * Time.smoothDeltaTime, 0 * Time.smoothDeltaTime));
            deadtimebool = true;
            print("4");
            if (deadtime > 3.0f)
            {
                print("5");
                gameManager.GetComponent<GameManager>().PlayerDie();
                deadtime = 0.0f;
            }
        }
    }

    private void FixedUpdate()
    {

    }



    IEnumerator UnBeatTime(GameObject obj)
	{
		int countTime = 0;

        print(obj.tag);
        if (obj.tag != "Player")
        {
            Destroy(obj.transform.parent.GetChild(1).gameObject);
        }

        while (countTime < 6)
		{

			if (countTime % 2 == 0)
				obj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90);
			else
				obj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 180);

			yield return new WaitForSeconds(0.3f);

			countTime++;

		}


		renderer.color = new Color32(255, 255, 255, 255);

        //if (obj.transform.parent.tag == "Obstacle")
        //{
        //    Destroy(obj);
        //}

		isUnBearTime = false;

		yield return null;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Obstacle")
		{
			StartCoroutine("UnBeatTime", gameObject);

			print(" 깜박여라 제발");
		} else if (other.gameObject.name == "BugCollider") {
            print(other.gameObject.transform.parent.GetChild(0).tag);


            if (other.gameObject.transform.parent.GetChild(0).tag == "FlatPlatform")
            {
                StartCoroutine("UnBeatTime", other.gameObject.transform.parent.GetChild(0).gameObject);
                other.gameObject.transform.parent.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;
            }
            else
            {
                StartCoroutine("UnBeatTime", other.gameObject.transform.parent.GetChild(0).gameObject);
                other.gameObject.transform.parent.GetChild(0).GetChild(0).GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.transform.parent.GetChild(0).GetChild(1).GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.transform.parent.GetChild(0).GetChild(2).GetComponent<BoxCollider>().isTrigger = true;
            }
        }

	}



    // 플레이어가 밟고 있는 플랫폼 다음에 다른 길이 있는 지 확인
    // 플레이어가 밟고 있는 플랫폼 다음에 다른 길이 있는 지 확인
    public bool isExistPlatform() {

        RaycastHit ray;
        print(currentPlatform.tag);

        if (currentPlatform.tag == "FlatPlatform")
        {
            Debug.DrawRay(currentPlatform.transform.position, new Vector3(1, 0, 0) * (((currentPlatform.GetComponent<RectTransform>().rect.width) / 2) + 3.0f), Color.black, 100.0f);
            if (Physics.Raycast(currentPlatform.transform.position, new Vector3(1, 0, 0), out ray, (((currentPlatform.GetComponent<RectTransform>().rect.width) / 2) + 3.0f)))
            {
                //print("여기다: " + ray.collider.gameObject.name);
                return false;
            } else
            {
                //print(ray.collider.gameObject.name);
                return true;
            }
        } else if (currentPlatform.tag == "Obstacle")
        {
            return false;
        }
        else if (currentPlatform.transform.parent.tag == "UpPlatform" || currentPlatform.transform.parent.tag == "DownPlatform")
        {
            Debug.DrawRay(currentPlatform.transform.parent.GetChild(2).transform.position, new Vector3(1, 0, 0) * (((currentPlatform.transform.parent.transform.GetChild(2).GetComponent<RectTransform>().rect.width) / 2) + 0.5f), Color.red, 100.0f);
            if (Physics.Raycast(currentPlatform.transform.parent.GetChild(2).transform.position, new Vector3(1, 0, 0), out ray, (((currentPlatform.transform.parent.GetChild(2).GetComponent<RectTransform>().rect.width) / 2) + 0.5f)))
            {
                print("여기다: " + ray.collider.gameObject.name);
                return false;
            } else
            {
                return true;
            }
        } else
        {
            return false;
        }

    }

   
    void isFallDown()
    {
        Debug.DrawRay(new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z), new Vector3(0, -7, 0), Color.red, 100.0f);
        RaycastHit ray;

        if ((Physics.Raycast(transform.position, new Vector3(0, -1f, 0), out ray, 7.0f) == false)) {

            print("엉엉");
            gameManager.GetComponent<GameManager>().PlayerDie();
        } else
        {


            if(ray.collider.tag == "Obstacle")
            {
                print("떨어질때ㅐㅐㅐㅐㅐ");
                gameManager.GetComponent<GameManager>().PlayerDie();
            }
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
