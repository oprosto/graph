using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tools : MonoBehaviour
{
    private static float _markLayer = 2f;
    private static float _vertexLayer = 1.0f;
    private static float _edgeLayer = 1.5f;
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
   
}
