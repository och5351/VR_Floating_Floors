using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class PopupControl : MonoBehaviour
{
    public Transform MenuPosition;
    public GameObject MenuPopup;

    public GameObject Gun;

    public Button ButtonGun;

    public Valve.VR.Extras.SteamVR_LaserPointer lp;

    public SteamVR_Action_Boolean MenuAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Menu");
    
    private void Start()
    {
        MenuPopup.SetActive(false);
    }

    private void Update()
    {
        if (MenuAction.stateUp == true)
        {
            SetMenuPopup();
        }
    }

    void SetMenuPopup()
    {
        if (MenuPopup.activeSelf == false)
        {
            MenuPopup.SetActive(true);
            MenuPopup.transform.position = MenuPosition.position;
            lp.pointer.SetActive(true);
        }
        else
        {
            MenuPopup.SetActive(false);
            lp.pointer.SetActive(false);
        }
    }

    public void ClosePopup()
    {
        MenuPopup.SetActive(false);
        lp.pointer.SetActive(false);
    }

    public void ExitApplication()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void ShowGun()
    {
        Gun.SetActive(true);
        GameObject RightHand = GameObject.Find("RightRenderModel Slim(Clone)");
        GameObject LeftHand = GameObject.Find("LeftRenderModel Slim(Clone)");
        if (RightHand != null)
        {
            RightHand.SetActive(false);
        }
        if (LeftHand != null)
        {
            LeftHand.SetActive(false);
        }
    }

    public void HideGun()
    {
        Gun.SetActive(false);
        GameObject RightHand = GameObject.Find("RightRenderModel Slim(Clone)");
        GameObject LeftHand = GameObject.Find("LeftRenderModel Slim(Clone)");
        if (RightHand != null)
        {
            RightHand.SetActive(true);
        }
        if (LeftHand != null)
        {
            LeftHand.SetActive(true);
        }
    }
}