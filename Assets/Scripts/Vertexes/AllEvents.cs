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
    public static UnityEvent<GameObject, Vertex> OnVertexDestroy = new UnityEvent<GameObject, Vertex>();

    public static UnityEvent<GameObject, Vertex> OnVertexSelect = new UnityEvent<GameObject, Vertex>();    
    public static UnityEvent<Vertex> OnEdgeSelect = new UnityEvent<Vertex>();
    public static UnityEvent<Vector3> OnCoordinatesSelect = new UnityEvent<Vector3>();

    public static UnityEvent OnBackgroundClick = new UnityEvent();
}
