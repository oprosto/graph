using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDisplay : MonoBehaviour
{    void Awake()
    {
        AllEvents.OnEdgeCreated.AddListener(DisplayEdge);
    }    
    private void DisplayEdge(GameObject edgeObj)
    {
        Edge edge = edgeObj.GetComponent<Edge>();
        LineRenderer line = edgeObj.GetComponent<LineRenderer>();
        Vector3 start = edge.GetStartVertex().GetPosition();
        Vector3 end = edge.GetEndVertex().GetPosition();


        Tools.toEdgeLayer(ref start);
        Tools.toEdgeLayer(ref end);
        line.SetPosition(0, start);
        line.SetPosition(1, end);

    }
}
