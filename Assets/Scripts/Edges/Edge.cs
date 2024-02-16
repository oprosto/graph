using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    private Vertex _start;
    private Vertex _end;
    private double _value;    
    private bool _isDirected;

    public double GetValue() => _value;
    public Vertex GetStartVertex() => _start;
    public Vertex GetEndVertex() => _end;
    public bool IsDirected() => _isDirected;

    public void SetValue(double value) => _value = value;
    public void SetStartVertex(Vertex vertex) => _start = vertex;
    public void SetEndVertex(Vertex vertex) => _end = vertex;
    public void SetDirection(bool enable) => _isDirected = enable;
    
    public void Initialize(Vertex start, Vertex end, double value, bool isDirected = false) 
    {
        _start = start;
        _end = end;
        _value = value;
        _isDirected = isDirected;    
    }
}
