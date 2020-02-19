using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageCount : MonoBehaviour
{

    public AirMap airMap;
    public Text remaningStageText;
    public GameObject MenuPopup;
    public GameManager gm;
    public Canvas canvasUI;
    public Canvas canvasEnding;
    public GameObject InGameUIManager;

    public int maxStageNum = 2;
    public int clearCount = 0;
    public int remainingStage = 0;

    private void Awake()
    {
        
        canvasEnding.GetComponent<Canvas>().enabled = false;
        remainingStage = maxStageNum - clearCount;
        remaningStageText.text = ("남은 스테이지 : " + remainingStage);
        
    }

    public void resetStage()
    {
        clearCount = 0;
        remainingStage = maxStageNum - clearCount;
        remaningStageText.text = ("남은 스테이지 : " + remainingStage);
    }

    public void countStage()
    {
        clearCount++;

        remainingStage = maxStageNum - clearCount; //stageNum => 실행시 정해진 값으로 목적지(넘어야할 stage) 지정

        if (remainingStage == 0) //stage 음수 표기 방지
        {
            remaningStageText.text = ("남은 스테이지 : " + remainingStage);
            airMap.speed = 0f;
            InGameUIManager.GetComponentInChildren<PlayingTimer>().timerFunction();//타이머 on/off
            canvasUI.GetComponent<Canvas>().enabled = false;
            canvasEnding.GetComponent<Canvas>().enabled = true;

           
        }
        else
        {
            remaningStageText.text = ("남은 스테이지 : " + remainingStage);
        }

        
    }
}
