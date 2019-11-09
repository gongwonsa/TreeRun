using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DataManager.Instance.score = DataManager.Instance.score + 1 * Time.deltaTime;
        int t = Mathf.FloorToInt(DataManager.Instance.score);
        ScoreText.text = t.ToString();
    }
}
