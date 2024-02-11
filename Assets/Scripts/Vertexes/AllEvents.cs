using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllEvents
{
    public static UnityEvent<GameObject, string> OnNameChanged = new UnityEvent<GameObject, string>();
    public static UnityEvent<GameObject, Vector3> OnPositionChanged = new UnityEvent<GameObject, Vector3>();
    public static UnityEvent<GameObject, double> OnValueChanged = new UnityEvent<GameObject, double>();
    public static UnityEvent<GameObject, Vertex> OnVertexCreated = new UnityEvent<GameObject, Vertex>();
    public static UnityEvent<Vertex> OnVertexChoosed = new UnityEvent<Vertex>();
}
