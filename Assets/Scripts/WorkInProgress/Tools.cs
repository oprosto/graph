using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    private static float offset = 0.5f;
    public static void to2D(ref Vector3 vector) 
    {
        vector.z = 0;
    }
    public static void markToVertexLayout(ref Vector3 vector)
    {
        vector.z += offset;
    }
}
