using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bossChicken;
    public GameObject[] bullet;
    public GameObject player;
    public GameObject settingMenu;
    public GameObject InGameUIManager;
    public GameObject DestroyingBulletObj;
    public List<GameObject> bulletList = new List<GameObject>();
    public GameObject menuPopup;
    public GameObject settingPopup;
    public GameObject countDown;
    private int primaryDifficulty = 200;
    

    private int shotFlag = 0;

    // Update is called once per frame
    void Update()
    {
        
        if (menuPopup.activeSelf == false && settingPopup.activeSelf == false && countDown.activeSelf == false)
        {
            primaryDifficulty = 200 / int.Parse(settingMenu.GetComponentInChildren<settingManager>().difficulty.text);
            shotFlag = Random.Range(0, primaryDifficulty);
            int speed = int.Parse(settingMenu.GetComponentInChildren<settingManager>().speed.text);

            if (InGameUIManager.GetComponentInChildren<PlayingTimer>().timer != 0.0f && speed != 0 && 0 < shotFlag && shotFlag < 2) //시간, 속도 값이 0이 아닐 때와 1%확률로 shot
            {
                Vector3 chickPosition = new Vector3(bossChicken.transform.localPosition.x, bossChicken.transform.localPosition.y - 1.0f, bossChicken.transform.localPosition.z);

                GameObject chickenBullet = Instantiate(bullet[Random.Range(0, 6)], chickPosition, Quaternion.Euler(0, 180, 0), transform);
                chickenBullet.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                chickenBullet.AddComponent<BoxCollider>();
                chickenBullet.tag = "Bullet";
                chickenBullet.GetComponent<BoxCollider>().isTrigger = true;
                bulletList.Add(chickenBullet);
            }
        }

        if (bulletList.Count > 0) //절대 좌표를 활용한 불릿 삭제 
        {
            if (Vector3.Distance(bulletList[0].transform.position, DestroyingBulletObj.transform.position) < 4.0f) { 
                Destroy(bulletList[0]);   // 점프 시도한 땅과 비교하여 다른 땅인 경우 오브젝트 파괴
                bulletList.RemoveAt(0);
            }           
        }        
    }
    
}
