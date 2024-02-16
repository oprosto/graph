using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EdgeCreator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData pointerEventData)
    {
           
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log(name + "No longer being clicked");
    }

}
