using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using Unity.VisualScripting;
using System;

public class Hover : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public  RectTransform tipWindow;

    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseLoseFocus += HideTip;
    }

    private void Start()
    {
        HideTip();
    }
    private void ShowTip(string tip, Vector2 mousePos)
    {
        tipText.text = tip;
        tipWindow.sizeDelta = new Vector2(1000,500);

        tipWindow.gameObject.SetActive( true );
        tipWindow.transform.position = new Vector2(mousePos.x,mousePos.y*2 ) ;
    }
    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }

}
