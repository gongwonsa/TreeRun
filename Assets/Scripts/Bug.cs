using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!DataManager.Instance.PlayerDie)
        {
            if (other.name == "Player")
            {
                DataManager.Instance.playTimeCurrent += 2f;
                DataManager.Instance.score += 10;

                if (DataManager.Instance.playTimeCurrent > DataManager.Instance.playTimeMax)
                {
                    DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
                }
                gameObject.SetActive(false);
            }
        }
        //gameObject.SetActive(false);
    }
}
