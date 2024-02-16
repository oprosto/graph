using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EdgeCreator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _start, _end;
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Event e = Event.current;
        if (e.control)
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(pointerEventData.position);
            Tools.to2D(ref temp);
            _start.transform.position = temp;
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Event e = Event.current;
        if (e.control)
        {
            //Debug.Log(name + "No longer being clicked");
            Vector3 temp = Camera.main.ScreenToWorldPoint(pointerEventData.position);
            Tools.to2D(ref temp);
            _end.transform.position = temp;
        }
    }

}
