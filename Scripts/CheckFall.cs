using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFall : MonoBehaviour
{
    public AirMap airMap;
    bool PlayCoroutine = false;
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fall")
        {
            airMap.speed = 0f;
            /*
            if (PlayCoroutine == false) // Collider 충돌이 2번 발생하는 상황, 코루틴 중복되지 않도록 조건문 추가
            {
                StartCoroutine(PlayerRotate());
            }            
            */
        }
    }

    IEnumerator PlayerRotate()
    {
        PlayCoroutine = true;

        float PlayerAngle = 0f;
        float TargetAngle = 90f;

        while (true)
        {
            PlayerAngle = (PlayerAngle < TargetAngle) ? PlayerAngle + 0.3f : TargetAngle;
            gameObject.transform.localEulerAngles = new Vector3(PlayerAngle, 0, 0);

            if (PlayerAngle == TargetAngle)
            {
                PlayCoroutine = false;
                break;
            }
            yield return null;
        }
    }
}
