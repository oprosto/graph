using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public static void to2D(ref Vector3 vector) 
    {
        vector.z = 0;
    }
}
