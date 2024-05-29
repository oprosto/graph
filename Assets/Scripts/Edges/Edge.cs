using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour, ISelectable, IRemovable
{
    private Vertex _start;
    private Vertex _end;
    private double _value;
    private byte _direction;
    private int _id;

    //private static int _globalId = 0;

    public double GetValue() => _value;
    public Vertex GetStartVertex() => _start;
    public Vertex GetEndVertex() => _end;
    public byte IsDirected() => _direction;
    public int GetId() => _id;

    public void SetValue(double value) => _value = value;
    public void SetStartVertex(Vertex vertex) => _start = vertex;
    public void SetEndVertex(Vertex vertex) => _end = vertex;
    public void SetDirection(byte direction) => _direction = direction;

    public void Initialize(Vertex start, Vertex end, double value, byte direction = 0)
    {
        _start = start;
        _end = end;
        _value = value;
        _direction = 0;
        _id = end.GetId();
    }
    public void OnSelect()
    {
        AllEvents.OnEdgeSelect.Invoke(this);
    }
    public void Remove()
    {
        EdgeRemover.Remove(this);
    }

}
[Serializable]
public struct RawEdge 
{
    public double _value;
    public byte _direction;
    public int _id;
    /*
    public RawEdge() 
    {
        _value = 0;
        _direction = 0;
        _id = 0;
    }*/
    public RawEdge(Edge edge) 
    {
        _value = edge.GetValue();
        _direction= edge.IsDirected();
        _id = edge.GetId();
    }
}
