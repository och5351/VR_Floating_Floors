using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class AirMap : MonoBehaviour
{
    public SteamVR_Action_Boolean MenuAction = SteamVR_Input.GetBooleanAction("Menu");

    public float speed = 0.0f;
    public GameObject MenuPopup;
    public GameManager gm;
    public GameObject InGameUIManager;
    
    
    public GameObject[] Floor;
    public List<GameObject> FloorList = new List<GameObject>();
    

    private void Awake()
    {
        GameObject NewFloor = Instantiate(Floor[0], Vector3.zero, Quaternion.identity, transform);    // 최초 바닥 생성(생성 오브젝트, 위치, 회전값, 부모 트랜스폼)
        NewFloor.transform.localPosition = Vector3.zero;
        FloorList.Add(NewFloor);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed == 0) return;

        // 일시정지
        if (MenuAction.stateDown == true)
        {
            speed = 0f;
            MenuPopup.SetActive(true);
            gm.MenuPopupEnable();
            InGameUIManager.GetComponentInChildren<PlayingTimer>().timerFunction();//타이머 on/off
        }

        // 땅이 5개 미만이 되면 계속 생성
        if (FloorList.Count < 5)
        {
            GameObject NewFloor = Instantiate(Floor[Random.Range(0, 3)], Vector3.zero, Quaternion.identity, transform);
            float AxisZ = FloorList[FloorList.Count - 1].transform.localPosition.z + ((NewFloor.transform.localScale.z + FloorList[FloorList.Count - 1].transform.localScale.z) / 2f) + (speed - 1f);
            NewFloor.transform.localPosition = new Vector3(0, 0, AxisZ);
            FloorList.Add(NewFloor);
        }        

        moveMap();
    }

    

    public void moveMap()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
