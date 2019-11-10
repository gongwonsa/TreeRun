using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLoader : MonoBehaviour
{
    public enum platformList {Flat, Up, Down, Count}
    public GameObject[] platformPrefabs = new GameObject[(int)platformList.Count];
    float platformWidth;
    float platformHeight;
    float platformDepth;
    GameObject player;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        player = GameObject.Find("Player");
        platformWidth = platformPrefabs[0].GetComponent<RectTransform>().rect.width * 1.85f;
        platformDepth = platformPrefabs[0].GetComponent<RectTransform>().rect.height * 1.85f;
        platformHeight = Mathf.Abs(platformPrefabs[1].transform.GetChild(0).transform.position.y - platformPrefabs[1].transform.GetChild(2).transform.position.y);
        print("너비: " + platformWidth);
        
    }

    // 플랫폼을 만들 수 있는 환경인 지 확인을 한 후에 호출 됨
    public void CreatePlatform (int type)
    {
        Vector3 platPosition = player.GetComponent<CharMovement>().SetPlatformPosition();

        if (type == 0) {
            print("평평");
            Instantiate(platformPrefabs[(int)platformList.Flat], new Vector3(platPosition.x + platformWidth, platPosition.y, platPosition.z), Quaternion.identity);
        }
        else if (type == 1) {
            print("업");
            Instantiate(platformPrefabs[(int)platformList.Up], new Vector3(platPosition.x + platformWidth, platPosition.y + ((platformHeight+platformDepth/2)/2), platPosition.z), Quaternion.identity);
        }
        else if (type == 2)
        {
            print("다운");
            Instantiate(platformPrefabs[(int)platformList.Down], new Vector3(platPosition.x + platformWidth, platPosition.y - ((platformHeight + platformDepth / 2) / 2), platPosition.z), Quaternion.identity);
        }
    }

}
