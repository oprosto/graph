using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VertexStatementDisplay : MonoBehaviour
{
    void Awake()
    {
        AllEvents.OnPositionChanged.AddListener(SetPosition);
        AllEvents.OnVertexCreated.AddListener(VertexCreated);
    }
    private void SetPosition(GameObject vertex, Vector3 vector)
    {
        vertex.transform.position = vector;
    }
    private void VertexCreated(GameObject vertex) 
    {
        vertex.transform.position = vertex.GetComponent<Vertex>().GetPosition();
    }
    

    private void ChangeStatement() 
    {
        
    }
}
