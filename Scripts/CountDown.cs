using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject Connt3;
    public GameObject Connt2;
    public GameObject Connt1;
    public GameObject Go;
    public GameObject InGameUIManager;


    public AudioSource audioSource;

    public AirMap airMap; //맵 스피드
    public Text speed;

    bool GameStart = false;

    public SoundControl sc;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable() // 오브젝트 활성화 시 수행
    {
        audioSource.Play();
        Connt3.SetActive(true);
    }

    private void OnDisable()    // 오브젝트 비활성화 시 수행
    {
        Connt3.SetActive(false);
        Connt2.SetActive(false);
        Connt1.SetActive(false);
        Go.SetActive(false);
        GameStart = false;
    }

    private void Update()
    {
        if (audioSource.isPlaying == true)
        {
            if (audioSource.time >= 2f)
            {
                Connt1.SetActive(true);
                Connt2.SetActive(false);
            }
            else if (audioSource.time >= 1f)
            {
                Connt2.SetActive(true);
                Connt3.SetActive(false);
                GameStart = true;
            }
        }
        else if (GameStart == true) // 오디오 종료 and 게임시작 후
        {
            Go.SetActive(true);
            Connt1.SetActive(false);
            Invoke("StartInterval", 0.5f);  // GO 메세지 0.5초 후 시작 
            GameStart = false;
        }
    }

    void StartInterval()
    {
        gameObject.SetActive(false);
        airMap.speed = int.Parse(speed.text);
        InGameUIManager.GetComponent<PlayingTimer>().timerFunction();
        sc.SetAudio();
    }
}
