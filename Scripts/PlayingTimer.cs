using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingTimer : MonoBehaviour
{

    public Text timeText;
    public float timer = 0.0f;
    public bool timerFlag = false;

    private void Awake()
    {
        timeText.text = "시간 : " + timer.ToString("F1");
    }
    // Update is called once per frame
    void Update()
    {
        if (timerFlag)
        {
            timer += Time.deltaTime;
            timeText.text = "시간 : " + timer.ToString("F1");
        }
    }

    public void resetTimer()
    {
        timer = 0.0f;
        timeText.text = "시간 : " + timer.ToString("F1");
    }

    public void timerFunction()
    {
        if(timerFlag == true)
        {
            timerFlag = false;
        }
        else
        {
            timerFlag = true;
        }
    }


}
