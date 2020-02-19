using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipList;
    public AudioClip audioClipMenu;
    int audioIndex = 0;

    public Text TextVolume;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SetAudio();
        }
    }

    public void SetAudio()
    {
        //audioIndex = (audioIndex + 1 == audioClipList.Length) ? 0 : audioIndex + 1;
        audioIndex = Random.Range(0, audioClipList.Length);
        if (audioClipList[audioIndex] != null)
        {
            audioSource.clip = audioClipList[audioIndex];
            audioSource.time = 0;
            audioSource.Play();
            audioSource.volume = int.Parse(TextVolume.text) / 100f;
        }
    }

    public void SetMenuAudio()
    {
        audioSource.clip = audioClipMenu;
        audioSource.time = 0;
        audioSource.Play();
        audioSource.volume = int.Parse(TextVolume.text) / 100f;
    }

    public void StopAudio()
    {
        audioSource.time = 0;
        audioSource.Stop();
    }
}