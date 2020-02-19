using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerPosition : MonoBehaviour
{

    public SteamVR_Action_Vector2 position = SteamVR_Input.GetVector2Action("moving(left)"); //가져온 이름은 moving(left)이지만 position vector2 그 자체
    public GameObject player; // 스팀 카메라가 들어있는 오브젝트
    private float moving; // axis를 그대로 사용하면 너무 빠르기 때문에 나눠줘서 사용

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        moving = player.transform.localPosition.x + position.axis.x / 50;  // axis를 그대로 사용하면 너무 빠르기 때문에 나눠줘서 사용
        if (moving >-4f && moving < 4f) //이 부분은 한계선이 존재하기 때문에 현재 프로젝트에서만 사용 되는 if 문
            player.transform.localPosition = new Vector3(player.transform.localPosition.x + position.axis.x / 50, player.transform.localPosition.y, player.transform.localPosition.z);
            //플레이어 움직임 조정
    }
}
