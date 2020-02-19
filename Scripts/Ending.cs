using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR.Extras;

public class Ending : MonoBehaviour
{
    public GameObject InGameUIManager;
    public Text clearText;
    public Canvas canvasUI;
    public Canvas canvasEnding;
    public GameObject bullet;
    public GameObject bossChicken;

    public SteamVR_LaserPointer lp;
    public GameObject Menu;
    public GameManager gm;
    

    void Update()
    {
        if(InGameUIManager.GetComponent<StageCount>().remainingStage == 0)
        {
           
            canvasUI.GetComponent<Canvas>().enabled = false;
            clearText.text = "축하합니다!!\n완주에 성공하셨습니다.\n\n걸린시간 : " + InGameUIManager.GetComponent<PlayingTimer>().timer.ToString("F1");
            canvasEnding.GetComponent<Canvas>().enabled = true;
            Debug.Log("남은 총알 수 : " + bullet.GetComponentInChildren<Bullet>().bulletList.Count);
            if (bullet.GetComponentInChildren<Bullet>().bulletList.Count > 0)
            {
                for (int i = 0; i < bullet.GetComponentInChildren<Bullet>().bulletList.Count; i++)
                {
                    Destroy(bullet.GetComponentInChildren<Bullet>().bulletList[i]);
                    bullet.GetComponentInChildren<Bullet>().bulletList.RemoveAt(i);
                }
                
            }
            Debug.Log("현재 총알 수 : " + bullet.GetComponentInChildren<Bullet>().bulletList.Count);
            bossChicken.GetComponent<BossChickenMoving>().boss.transform.localPosition = new Vector3(0, 2, 60);
            gm.RightHand.SetActive(true);
            gm.LeftHand.SetActive(true);

            gm.RightCollider.SetActive(true);
            gm.LeftCollider.SetActive(true);


            ShowController();
            AnimateHandWithController();
            lp.pointer.SetActive(true);

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


}
