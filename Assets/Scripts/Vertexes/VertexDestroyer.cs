/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexDestroyer: MonoBehaviour
{
    private GameObject lastSelectedVertexObj = null;
    //private Vertex lastSelectedVertex = null;
    
    public void DestroyVertex() 
    {
        if (lastSelectedVertexObj == null)
            return;
        AllEvents.OnVertexRemoved.Invoke(lastSelectedVertexObj);// ,lastSelectedVertex); //Стоит ли передавать всегда и объект и вершину??
        Destroy(lastSelectedVertexObj);
        AllEvents.OnVertexSelect.Invoke(null);

    }
    private void RememberLastSelectedVertex(GameObject vertex) 
    {
        lastSelectedVertexObj = vertex;
        //lastSelectedVertex = vertex;
    }

}*/
