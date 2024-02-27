using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipToShow;
    private float timeToWait = 0.75f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer() );
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        Hover.OnMouseLoseFocus();
        Debug.Log("Exit");

    }

    private void ShowMessage()
    {
        Hover.OnMouseHover(tipToShow,Input.mousePosition);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds( timeToWait );
        ShowMessage();
    }


}
