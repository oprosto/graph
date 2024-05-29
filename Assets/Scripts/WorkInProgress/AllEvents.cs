using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AllEvents
{
    public static UnityEvent<Vertex, string> OnVertexNameChanged = new UnityEvent<Vertex, string>();
    public static UnityEvent<Vertex, Vector3> OnVertexPositionChanged = new UnityEvent<Vertex, Vector3>();
    public static UnityEvent<Vertex, double> OnVertexValueChanged = new UnityEvent<Vertex, double>();

    public static UnityEvent<Edge, Vector3> OnEdgePositionChanged = new UnityEvent<Edge, Vector3>();
    public static UnityEvent<Edge, double> OnEdgeValueChanged = new UnityEvent<Edge, double>();

    public static UnityEvent<Vertex> OnVertexCreated = new UnityEvent<Vertex>();
    public static UnityEvent<Vertex> OnVertexRemoved = new UnityEvent<Vertex>();

    public static UnityEvent<Vertex> OnVertexSelect = new UnityEvent<Vertex>();    
    public static UnityEvent<Edge> OnEdgeSelect = new UnityEvent<Edge>();
    public static UnityEvent<Vector3> OnCoordinatesSelect = new UnityEvent<Vector3>();
    public static UnityEvent OnDeselect = new UnityEvent();

    public static UnityEvent<Edge> OnEdgeCreated = new UnityEvent<Edge>();
    public static UnityEvent<Edge> OnEdgeRemoved = new UnityEvent<Edge>();

    public static UnityEvent OnBackgroundClick = new UnityEvent();

}
