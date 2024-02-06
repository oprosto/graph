using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VertexStatementDisplay : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("I AWAKE! 3");
        AllEvents.OnPositionChanged.AddListener(SetPosition);
        AllEvents.OnVertexCreated.AddListener(VertexCreated);
    }
    private void SetPosition(GameObject vertex, Vector3 vector)
    {
        vertex.transform.position = vector;
    }
    private void VertexCreated(GameObject vertexObj, Vertex vertex) 
    {
        vertexObj.transform.position = vertex.GetPosition();
    }
    

    private void ChangeStatement() 
    {
        
    }
}
