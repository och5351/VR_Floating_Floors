using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBullet : MonoBehaviour
{

    public AirMap airMap;
    private float slow = 1f;
    public settingManager settingManager;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            
            airMap.speed = slow;

            Invoke("StartInterval", 1f);
            
        }
    }
    void StartInterval()
    {
        
        airMap.speed = int.Parse(settingManager.speed.text);
    }
}
