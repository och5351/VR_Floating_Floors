using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChickenMoving : MonoBehaviour
{

    public GameObject boss;
    public GameObject settingMenu;
    public GameObject InGameUIManager;
    public GameObject menuPopup;
    public GameObject settingPopup;
    public GameObject countDown;
    private float bossX;
    private float moving;
    private int movingFlag = 0;
    private int speed;
    private int primarySpeed = 100;
    
    // Update is called once per frame
    void Update()
    {
        if (menuPopup.activeSelf == false && settingPopup.activeSelf == false && countDown.activeSelf == false)
        {
            bossX = boss.transform.localPosition.x;
            movingFlag = Random.Range(0, primarySpeed / int.Parse(settingMenu.GetComponentInChildren<settingManager>().difficulty.text));
            speed = int.Parse(settingMenu.GetComponentInChildren<settingManager>().speed.text);

            if (InGameUIManager.GetComponentInChildren<PlayingTimer>().timer != 0.0f && speed != 0 && movingFlag > 0 && movingFlag < 2)
            {
                moving = Random.Range(-1, 2);
                if (bossX + moving > -4 && bossX + moving < 4)
                    boss.transform.localPosition = new Vector3(bossX + moving, boss.transform.localPosition.y, boss.transform.localPosition.z);
            }
        }
    }
}
