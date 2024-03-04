using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllEvents
{
    public static UnityEvent<GameObject, string> OnNameChanged = new UnityEvent<GameObject, string>();
    public static UnityEvent<GameObject, Vector3> OnPositionChanged = new UnityEvent<GameObject, Vector3>();
    public static UnityEvent<GameObject, double> OnValueChanged = new UnityEvent<GameObject, double>();

    public static UnityEvent<GameObject, Vector3> OnEdgePositionChanged = new UnityEvent<GameObject, Vector3>();
    public static UnityEvent<GameObject, double> OnEdgeValueChanged = new UnityEvent<GameObject, double>();

    public static UnityEvent<GameObject> OnVertexCreated = new UnityEvent<GameObject>();
    public static UnityEvent<GameObject> OnVertexDestroy = new UnityEvent<GameObject>();

    public static UnityEvent<GameObject> OnVertexSelect = new UnityEvent<GameObject>();    
    public static UnityEvent<GameObject> OnEdgeSelect = new UnityEvent<GameObject>();
    public static UnityEvent<Vector3> OnCoordinatesSelect = new UnityEvent<Vector3>();

    public static UnityEvent<GameObject> OnEdgeCreated = new UnityEvent<GameObject>();

    public static UnityEvent OnBackgroundClick = new UnityEvent();
}
