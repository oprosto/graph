using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tools : MonoBehaviour
{
    private static readonly float _markLayer = 2f;
    private static readonly float _vertexLayer = 1.0f;
    private static readonly float _edgeLayer = 1.5f;
    private static readonly float _dijkstraLayer = 1.0f;
    public static void to2D(ref Vector3 vector) 
    {
        vector.z = 0;
    }
    public static void toSelectorLayer(ref Vector3 vector)
    {
        vector.z = _markLayer;
    }
    public static void toVertexLayer(ref Vector3 vector)
    {
        vector.z = _vertexLayer;
    }
    public static void toEdgeLayer(ref Vector3 vector)
    {
        vector.z = _edgeLayer;
    }
    public static void toDijkstraLayer(ref Vector3 vector)
    {
        vector.z = _dijkstraLayer;
    }
}
