using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class underFloor : MonoBehaviour
{
    public AirMap airMap;
    public Text Speed;

    float RespawnPosZ;
    public Transform PlayerPosition;
    public GameObject InGameUIManager;
    public GameObject FadeObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(FadeEffect(other.transform));
        }
    }

    IEnumerator FadeEffect(Transform PlayerTransform)
    {
        FadeObject.SetActive(true);
        Material material = FadeObject.GetComponent<MeshRenderer>().material;
        float TransparentValue = 0f;
        /*
        // 화면 빨간색 페이드아웃
        while (true)
        {
            TransparentValue = (TransparentValue < 255f) ? TransparentValue + 1f : 255f;
            material.color = new Color(1f, 0f, 0f, TransparentValue / 255f);

            if (TransparentValue == 255f) break;
            yield return null;
        }
        yield return new WaitForSeconds(0.01f);
        */
        // 화면 검은색으로 변경
        float RedValue = 255f;
        while (true)
        {
            RedValue = (RedValue > 0f) ? RedValue - 1f : 0f;
            material.color = new Color(RedValue / 255f, 0f, 0f, 1f);

            if (RedValue == 0f) break;
            yield return null;
        }
        
        yield return new WaitForSeconds(0.01f);
        
        // 플레이어 위치 초기화
        PlayerTransform.position = Vector3.zero;            // 추락 전 초기 위치로 이동
        PlayerTransform.localEulerAngles = Vector3.zero;    // 추락 전 초기 회전값으로 복원

        // 리스폰 위치 확인
        PlayerPosition.position = Vector3.zero;  // 플레이어 위치와 동기화(월드좌표와 동기화로 로컬좌표가 변경됨)
        RespawnPosZ = airMap.FloorList[1].transform.localPosition.z - (airMap.FloorList[1].transform.localScale.z / 2f) + 3f; // 추락 시 리스폰 지역

        // 맵 이동
        airMap.transform.localPosition -= new Vector3(0, 0, RespawnPosZ - PlayerPosition.localPosition.z);

        // 화면 페이드인
        while (true)
        {
            TransparentValue = (TransparentValue > 0f) ? TransparentValue - 1f : 0f;
            material.color = new Color(material.color.r, material.color.g, material.color.b, TransparentValue / 255f);

            if (TransparentValue == 0f) break;
            yield return null;
        }
        FadeObject.SetActive(false);
        material.color = new Color(1f, 0f, 0f, 0f);

        yield return new WaitForSeconds(0.01f);
        if(InGameUIManager.GetComponent<StageCount>().remainingStage != 0) {
            airMap.speed = int.Parse(Speed.text);
        }
        else
        {
            airMap.speed = 0;
        }
        
    }
}