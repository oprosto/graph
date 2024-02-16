using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectVertex : MonoBehaviour, IPointerClickHandler
{
    Vertex vertex;
    GameObject vertexObj;
    
    public void OnPointerClick(PointerEventData eventData)
    {        
        vertex = GetComponent<Vertex>();
        vertexObj = GetComponent<GameObject>();
        if (vertex == null)
        {
            Debug.Log("Vertex is not registered");
            return;
        }
        AllEvents.OnVertexSelect.Invoke(vertexObj, vertex);
    }
}
