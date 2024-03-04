using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexDestroyer: MonoBehaviour
{
    private GameObject lastSelectedVertexObj = null;
    //private Vertex lastSelectedVertex = null;
    public void Awake()
    {
        AllEvents.OnVertexSelect.AddListener(RememberLastSelectedVertex);
    }
    public void DestroyVertex() 
    {
        if (lastSelectedVertexObj == null)
            return;
        AllEvents.OnVertexDestroy.Invoke(lastSelectedVertexObj);// ,lastSelectedVertex); //Стоит ли передавать всегда и объект и вершину??
        Destroy(lastSelectedVertexObj);
        AllEvents.OnVertexSelect.Invoke(null);

    }
    private void RememberLastSelectedVertex(GameObject vertex) 
    {
        lastSelectedVertexObj = vertex;
        //lastSelectedVertex = vertex;
    }

}
