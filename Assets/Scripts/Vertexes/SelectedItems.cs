using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItems
{
    public static GameObject lastVertex = null;
    public static GameObject lastEdge = null;
    public static Vector3 lastCoord = Vector3.zero;

    private static void Awake()
    {
        AllEvents.OnVertexSelect.AddListener(SetVertex);
        AllEvents.OnEdgeSelect.AddListener(SetEdge);
        AllEvents.OnCoordinatesSelect.AddListener(SetCoordinate);
    }
    private static void SetVertex(GameObject vertex) => lastVertex = vertex;
    private static void SetEdge(GameObject edge) => lastEdge = edge;
    private static void SetCoordinate(Vector3 vector) => lastCoord = vector;


}
