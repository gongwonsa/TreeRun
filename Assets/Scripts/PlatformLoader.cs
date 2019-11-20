using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLoader : MonoBehaviour
{
    public enum platformList { Flat, Up, Down, Count }
    public GameObject[] platformPrefabs = new GameObject[(int)platformList.Count];
    public GameObject[] bugPrefabs = new GameObject[(int)platformList.Count];
    public GameObject[] obstaclePrefabs = new GameObject[(int)platformList.Count];
    float platformWidth;
    float platformHeight;
    float platformDepth;
    int prevPlatType;
    int newPlatType;
    GameObject player;
    GameObject gameManager;
    GameObject newPlatform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        platformWidth = platformPrefabs[0].GetComponent<RectTransform>().rect.width * 1.85f;
        platformDepth = platformPrefabs[0].GetComponent<RectTransform>().rect.height * 1.85f;
        platformHeight = Mathf.Abs(platformPrefabs[1].transform.GetChild(0).transform.position.y - platformPrefabs[1].transform.GetChild(2).transform.position.y);

        print("너비: " + platformWidth);

    }

    // 플랫폼을 만들 수 있는 환경인 지 확인을 한 후에 호출 됨
    public void CreatePlatform(int type)
    {
        Vector3 platPosition = player.GetComponent<CharMovement>().SetPlatformPosition();
        prevPlatType = player.GetComponent<CharMovement>().SetPrevPlatType();
        newPlatType = type;

        if (type == 0 )
        {
            print("평평");
            if (prevPlatType == 0)
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Flat], new Vector3(platPosition.x + platformWidth, platPosition.y, platPosition.z), Quaternion.identity);
            else if (prevPlatType == 1)
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Flat], new Vector3(platPosition.x + platformWidth, platPosition.y + platformDepth, platPosition.z), Quaternion.identity);
            else
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Flat], new Vector3(platPosition.x + platformWidth, platPosition.y - platformDepth, platPosition.z), Quaternion.identity);
        }
        else if (type == 1)
        {
            print("업");
            if (prevPlatType == 0)
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Up], new Vector3(platPosition.x + platformWidth, platPosition.y + (platformHeight - platformDepth), platPosition.z), Quaternion.identity);
            else if (prevPlatType == 1)
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Up], new Vector3(platPosition.x + platformWidth, platPosition.y + (platformHeight), platPosition.z), Quaternion.identity);
            else
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Up], new Vector3(platPosition.x + platformWidth, platPosition.y + (platformHeight - platformDepth - platformDepth), platPosition.z), Quaternion.identity);
        }
        else if (type == 2)
        {
            print("다운");
            if (prevPlatType == 0)
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Down], new Vector3(platPosition.x + platformWidth, platPosition.y - (platformHeight - platformDepth), platPosition.z), Quaternion.identity);
            else if (prevPlatType == 1)
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Down], new Vector3(platPosition.x + platformWidth, platPosition.y - (platformHeight - platformDepth - platformDepth), platPosition.z), Quaternion.identity);
            else
                newPlatform = Instantiate(platformPrefabs[(int)platformList.Down], new Vector3(platPosition.x + platformWidth, platPosition.y - (platformHeight), platPosition.z), Quaternion.identity);
        }

        
    }

    bool CreatePossible ()
    {
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        if (Obstacles.Length > 0)
        {
            for (int i = 0; i < Obstacles.Length; i++)
            {
                if (player.transform.position.x < Obstacles[i].transform.position.x)
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            return true;
        }
    }

	public void CreateBug()
	{
		if (CreatePossible())
		{
			int random = Random.Range(0, 3);
			//Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3*platformWidth, newPlatform.transform.position.y + Random.Range(-1, 3) * (platformHeight+ platformDepth), 0), Quaternion.identity);

			//여기서 부터 새로 작성한 코드
			Vector3 platPosition = player.GetComponent<CharMovement>().SetPlatformPosition();

			if (random == 0)
			{
				print("평평");
				if (newPlatType == 0)
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y + Random.Range(-1, 3) * (platformHeight ), 0), Quaternion.identity);
				else if (newPlatType == 1)
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y + platformDepth + Random.Range(-1, 3) * (platformHeight ), 0), Quaternion.identity);
				else
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y - platformDepth + Random.Range(-1, 3) * (platformHeight ), 0), Quaternion.identity);
			}
			else if (random == 1)
			{
				print("업");
				if (newPlatType == 0)
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y + (platformHeight - platformDepth) + Random.Range(-1, 3) * (platformHeight ), 0), Quaternion.identity);
				else if (newPlatType == 1)
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y + platformHeight + Random.Range(-1, 3) * (platformHeight ), 0), Quaternion.identity);
				else
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y + (platformHeight - platformDepth - platformDepth) + Random.Range(-1, 3) * (platformHeight ), 0), Quaternion.identity);
			}
			else if (random == 2)
			{
				print("다운");
				if (newPlatType == 0)
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y - (platformHeight - platformDepth) + Random.Range(-1, 2) * (platformHeight ), 0), Quaternion.identity);
				else if (newPlatType == 1)
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y - (platformHeight - platformDepth - platformDepth) + Random.Range(-1, 2) * (platformHeight), 0), Quaternion.identity);
				else
					Instantiate(bugPrefabs[random], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y - platformHeight + Random.Range(-1, 2) * (platformHeight), 0), Quaternion.identity);
			}


		}
	}

	public void CreateObstacle()
    {
        if (CreatePossible())
        {
            //int random = Random.Range(0, 3);
            Instantiate(obstaclePrefabs[2], new Vector3(newPlatform.transform.position.x + 3 * platformWidth, newPlatform.transform.position.y + Random.Range(-1, 2) * (platformHeight ), 0), Quaternion.Euler(0,0,90));
        }
    }

    public float SetWidth() {
        return platformWidth;
    }
}
