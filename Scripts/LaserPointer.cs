using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class LaserPointer : MonoBehaviour
{
    private void Start()
    {
        SteamVR_LaserPointer laser = gameObject.GetComponent<SteamVR_LaserPointer>();

        laser.PointerClick += new PointerEventHandler(ClickHandler);
        laser.PointerIn += new PointerEventHandler(InHandler);
        laser.PointerOut += new PointerEventHandler(OutHandler);
    }

    void ClickHandler(object sender, PointerEventArgs pointer)
    {
        if (LayerMask.LayerToName(pointer.target.gameObject.layer) == "UI" && pointer.target.tag == "Button")
        {
            pointer.target.GetComponent<Button>().OnSubmit(null);
        }
    }

    void InHandler(object sender, PointerEventArgs pointer)
    {
        if (LayerMask.LayerToName(pointer.target.gameObject.layer) == "UI" && pointer.target.tag == "Button")
        {
            pointer.target.GetComponent<Button>().OnPointerEnter(null);
        }
    }

    void OutHandler(object sender, PointerEventArgs pointer)
    {
        if (LayerMask.LayerToName(pointer.target.gameObject.layer) == "UI" && pointer.target.tag == "Button")
        {
            pointer.target.GetComponent<Button>().OnPointerExit(null);
        }
    }
}