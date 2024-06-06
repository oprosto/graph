using System;
using UnityEngine;
public enum Direction 
{
    Backward = -1,
    None = 0,
    Forward = 1
};
public class Edge : MonoBehaviour, ISelectable, IRemovable
{
    private Vertex _start;
    private Vertex _end;
    private double _value;
    private Direction _direction;
    private int _id;

    public double GetValue() => _value;
    public Vertex GetStartVertex() => _start;
    public Vertex GetEndVertex() => _end;
    public Direction IsDirected() => _direction;
    public int GetId() => _id;

    public void SetValue(double value) => _value = value;
    public void SetStartVertex(Vertex vertex) => _start = vertex;
    public void SetEndVertex(Vertex vertex) => _end = vertex;
    public void SetDirection(Direction direction) => _direction = direction;

    public void Initialize(Vertex start, Vertex end, double value, Direction direction = Direction.Forward)
    {
        _start = start;
        _end = end;
        _value = value;
        _direction = direction;
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
    public Direction _direction;
    public int _id;
    public RawEdge(Edge edge) 
    {
        _value = edge.GetValue();
        _direction= edge.IsDirected();
        _id = edge.GetId();
    }
}
