using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VertexStatementDisplay : MonoBehaviour
{
    private void Start()
    {
        AllEvents.OnVertexPositionChanged.AddListener(SetPosition);
        AllEvents.OnVertexCreated.AddListener(VertexCreated);
    }
    private void SetPosition(Vertex vertex, Vector3 vector)
    {
        vertex.gameObject.transform.position = vector;
    }
    private void VertexCreated(Vertex vertex) 
    {
        vertex.gameObject.transform.position = vertex.GetPosition();
    }
    

    private void ChangeStatement() 
    {
        
    }
}
