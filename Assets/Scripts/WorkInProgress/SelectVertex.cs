using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectVertex : MonoBehaviour, IPointerClickHandler
{
    //Vertex vertex;
    private GameObject vertex;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //vertex = GetComponent<Vertex>();
        vertex = gameObject;
        if (vertex == null)
        {
            Debug.Log("Vertex is not registered");
            return;
        }
        AllEvents.OnVertexSelect.Invoke(vertex);
    }
}
