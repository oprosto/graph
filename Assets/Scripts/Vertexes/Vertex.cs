using System;
using System.Collections.Generic;
using UnityEngine;

/*[RequireComponent(typeof(VertexUI))]
[RequireComponent (typeof(VertexStatementDisplay))]*/
public class Vertex : MonoBehaviour, ISelectable, IRemovable
{
    //private VertexUI _vertexUI;
    //private VertexStatementDisplay _vertexStatementDisplay;

    private string _name;
    private Vector3 _position;
    private double _value;
    private List<Edge> _edges;
    private List<Edge> _inputEdges;
    private int _id;


    //private static int _globalId = 0;
    /*
    private void Awake()
    {
        _vertexUI = GetComponent<VertexUI>();
        _vertexStatementDisplay = GetComponent<VertexStatementDisplay>();
    }*/
    public void Initialize(string name, Vector3 position, double value, List<Edge> edges = null, List<Edge> inputEdges = null)
    {
        if (name == null)
        {
            int amountOfVertex = DataBase.GetAmountOfVertex();
            _name = $"q{amountOfVertex}";
        }
        else
        _name = name;
        _position = position;
        _value = value;
        if (edges == null)
            _edges = new List<Edge>();
        else
            _edges = edges;
        
        if (inputEdges == null)        
            _inputEdges = new List<Edge>();        
        else
            _inputEdges = inputEdges;
        
        _id = DataBase._globalVertexID;
    }

    public void SetName(string name) => _name = name;
    public void SetPosition(Vector3 position) => _position = position;
    public void SetValue(double value) => _value = value;
    public void AddEdge(Edge edge) => _edges.Add(edge);
    public void AddInputEdge(Edge edge) => _inputEdges.Add(edge);
    

    public string GetName() => _name;
    public Vector3 GetPosition() => _position;
    public double GetValue() => _value;
    public List<Edge> GetEdges() => _edges;
    public int GetId() => _id;
    public List<Edge> GetInputEdges() => _inputEdges;
    public void OnSelect()
    {
        AllEvents.OnVertexSelect.Invoke(this);
    }
    public void Remove()
    {
        VertexRemover.Remove(this);
    }
}

[Serializable]
public class RawVertex 
{
    public string _name;
    public Vector3 _position;
    public double _value;
    public int _id;
    public RawEdge[] _edges;
    public RawEdge _edge;

    public RawVertex() 
    {
        _name = "None";
        _position = Vector3.zero;
        _value = 0;
        _id = 0;
        _edges = new RawEdge[0];
        //_edge = null;
    }
    public RawVertex(Vertex vertex) 
    {
        _name = vertex.GetName();
        _position = vertex.GetPosition();
        _value = vertex.GetValue();
        _id = vertex.GetId();
        _edges = new RawEdge[vertex.GetEdges().Count];
        
        int i = 0;
        foreach (Edge edge in vertex.GetEdges())
        {
            _edges[i] = new RawEdge(edge);
            i++;
        }
        
        //_edge = new RawEdge(vertex.GetEdges()[0]);
    }
}
