using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDisplay : MonoBehaviour
{    void Awake()
    {
        AllEvents.OnEdgeCreated.AddListener(DisplayEdge);
    }

    private void DisplayEdge(Edge edge)
    {
        LineRenderer line = edge.gameObject.GetComponent<LineRenderer>();
        //Vector3 start = edge.GetStartVertex().GetPosition();
        //Vector3 end = edge.GetEndVertex().GetPosition();

        Vector3 start = EdgeTools.FindCoolPosition(edge, true);
        Vector3 end = EdgeTools.FindCoolPosition(edge, false);

        Tools.toEdgeLayer(ref start);
        Tools.toEdgeLayer(ref end);
        line.SetPosition(0, start);
        line.SetPosition(1, end);

    }
}
