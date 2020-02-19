using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingManager : MonoBehaviour
{
    public Text volumn;
    public Text speed;
    public Text difficulty;

    public GameObject Setting;
    public GameObject Menu;

    public AudioSource CountAudio;

    string EnableValue;

    public AirMap airMap;

    public void Start()
    {
        EnableValue = speed.text;
    }

    public void speedUp()
    {
        int temp = int.Parse(speed.text);

        if (temp != 50)
            temp += 10;

        speed.text = temp.ToString();        
    }

    public void speedDown()
    {
        int temp = int.Parse(speed.text);
        if (temp != 10)
            temp -= 10;
        
        speed.text = temp.ToString();
    }

    public void volumnUp()
    {
        int temp = int.Parse(volumn.text);

        if (temp != 100)
            temp += 10;

        volumn.text = temp.ToString();
    }

    public void volumnDown()
    {
        int temp = int.Parse(volumn.text);

        if (temp != 0)
            temp -= 10;

        volumn.text = temp.ToString();
    }

    public void difficultyUp()
    {
        int temp = int.Parse(difficulty.text);

        if (temp != 10)
            temp += 1;

        difficulty.text = temp.ToString();
    }

    public void difficultyDown()
    {
        int temp = int.Parse(difficulty.text);

        if (temp != 1)
            temp -= 1;

        difficulty.text = temp.ToString();
    }

    public void gameSetting()
    {
        if (EnableValue != speed.text)
        {
            EnableValue = speed.text;
            for (int i = airMap.FloorList.Count - 1; i > 0; i--)
            {
                Destroy(airMap.FloorList[i]);
                airMap.FloorList.RemoveAt(i);
            }
        }

        Setting.SetActive(false);
        Menu.SetActive(true);

      
        CountAudio.volume = int.Parse(volumn.text) / 100f;
    }
}