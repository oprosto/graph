using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexDestroyer : MonoBehaviour
{
    private GameObject lastSelectedVertexObj = null;
    private Vertex lastSelectedVertex = null;
    public void Awake()
    {
        AllEvents.OnVertexSelect.AddListener(RememberLastSelectedVertex);
    }
    public void DestroyVertex() 
    {
        if (lastSelectedVertex != null)
        {
            AllEvents.OnVertexDestroy.Invoke(lastSelectedVertexObj ,lastSelectedVertex); //Стоит ли передавать всегда и объект и вершину??
        }
    }
    private void RememberLastSelectedVertex(GameObject vertexObj, Vertex vertex) 
    {
        lastSelectedVertexObj = vertexObj;
        lastSelectedVertex = vertex;
    }

}
