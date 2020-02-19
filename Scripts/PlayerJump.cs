using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerJump : MonoBehaviour
{
    public SteamVR_Action_Boolean teleportAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");
    public AirMap airMap;
    public StageCount stageCount;
    public GameObject player;

    GameObject JumpFloor;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Floor")
        {
            if (JumpFloor != null && JumpFloor != other.gameObject)
            {
                Destroy(airMap.FloorList[0]);   // 점프 시도한 땅과 비교하여 다른 땅인 경우 오브젝트 파괴
                airMap.FloorList.RemoveAt(0);
                stageCount.countStage();
            }

            if (teleportAction.stateDown && airMap.speed != 0)
            {
                StartCoroutine(Jump());
            }

            JumpFloor = other.gameObject;   // 현재 땅 저장
        }
    }

    IEnumerator Jump()
    {
        float JumpHeight = 0f;
        float TargetHeight = 3f;

        while (true)
        {
            JumpHeight = (JumpHeight < TargetHeight) ? JumpHeight + 0.05f : TargetHeight;
            gameObject.transform.localPosition = new Vector3(player.transform.localPosition.x, JumpHeight, player.transform.localPosition.z);

            if (JumpHeight == TargetHeight)
            {
                break;
            }
            yield return null;
        }

        while (true)
        {
            JumpHeight = (JumpHeight > 0) ? JumpHeight - 0.05f : 0;
            gameObject.transform.localPosition = new Vector3(player.transform.localPosition.x , JumpHeight, player.transform.localPosition.z);

            if (JumpHeight == 0)
            {
                break;
            }
            yield return null;
        }
    }
}
