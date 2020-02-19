using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR.Extras;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SteamVR_LaserPointer lp;
    public GameObject Setting;
    public GameObject primaryMenu;
    public GameObject endingMenu;
    public AirMap airMap;

    public GameObject InGameUIManager;

    public GameObject CountDown;

    public GameObject RightHand;
    public GameObject LeftHand;

    public GameObject RightCollider;
    public GameObject LeftCollider;

    public SoundControl sc;

    private void Start()
    {
        sc.SetMenuAudio();
    }

    void SetHaptic()
    {
        for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
        {
            Hand hand = Player.instance.hands[handIndex];
            if (hand != null)
            {
                hand.TriggerHapticPulse(1500);
            }
        }
    }

    public void MenuPopupEnable()
    {
        if (RightCollider != null) RightCollider.SetActive(true);
        if (LeftCollider != null) LeftCollider.SetActive(true);
        if (RightHand != null) RightHand.SetActive(true);
        if (LeftHand != null) LeftHand.SetActive(true);

        ShowController();
        AnimateHandWithController();
        lp.pointer.SetActive(true);

        sc.SetMenuAudio();
    }

    public void reStart()
    {        
        InGameUIManager.GetComponentInChildren<StageCount>().resetStage();
        InGameUIManager.GetComponentInChildren<PlayingTimer>().resetTimer();
        InGameUIManager.GetComponentInChildren<Ending>().canvasEnding.GetComponent<Canvas>().enabled = false;
        InGameUIManager.GetComponentInChildren<Ending>().canvasUI.GetComponent<Canvas>().enabled = true;
        primaryMenu.SetActive(true);        


        for (int i = airMap.FloorList.Count - 1; i > 0; i--)
        {
            Destroy(airMap.FloorList[i]);
            airMap.FloorList.RemoveAt(i);
        }
        
    }


    public void game_start() // 손없애기, 메인메뉴 없애기
    {
        primaryMenu.SetActive(false);
        
        if (RightHand == null) RightHand = GameObject.Find("RightRenderModel Slim(Clone)");
        if (LeftHand == null) LeftHand = GameObject.Find("LeftRenderModel Slim(Clone)");
        if (RightHand != null) RightHand.SetActive(false);
        if (LeftHand != null) LeftHand.SetActive(false);

        // 손 콜라이더 비활성화(이 오브젝트 때문에 손 관련 충돌 이벤트 발생)
        if (RightCollider == null) RightCollider = GameObject.Find("HandColliderRight(Clone)");
        if (LeftCollider == null) LeftCollider = GameObject.Find("HandColliderLeft(Clone)");
        if (RightCollider != null) RightCollider.SetActive(false);
        if (LeftCollider != null) LeftCollider.SetActive(false);

        HideController();
        lp.pointer.SetActive(false);

        CountDown.SetActive(true);

    }

    void HideController()
    {
        for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
        {
            Hand hand = Player.instance.hands[handIndex];
            if (hand != null)
            {
                hand.HideController(true);
            }
        }
    }

    void AnimateHandWithController()
    {
        for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
        {
            Hand hand = Player.instance.hands[handIndex];
            if (hand != null)
            {
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            }
        }
    }

    void ShowController()
    {
        for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
        {
            Hand hand = Player.instance.hands[handIndex];
            if (hand != null)
            {
                hand.ShowController(true);
            }
        }
    }

    public void gameSetting()
    {
        Setting.SetActive(true);
        primaryMenu.SetActive(false);        
    }

    public void gameQuit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}

