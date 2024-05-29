using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private static int _amountOfVertex = 0;

    //[NonSerialized] public static Dictionary<Vertex, List<Edge>> vertices = new Dictionary<Vertex, List<Edge>>();
    [NonSerialized] public static List<Vertex> vertices = new List<Vertex>();
    [NonSerialized] public static int _globalVertexID = 0;
    //[NonSerialized] public static int _globalEdgeID = 0;

    //Правильно уменьшать глобальные переменные при удалении быстро??
    public static int GetAmountOfVertex() => _amountOfVertex;

    private void Awake()
    {
        AllEvents.OnVertexCreated.AddListener(AddVertex);
        AllEvents.OnVertexRemoved.AddListener(RemoveVertex);
        AllEvents.OnEdgeCreated.AddListener(AddEdge);
        AllEvents.OnEdgeRemoved.AddListener(RemoveEdge);
    }
    private void AddEdge(Edge edge) 
    {
        
        Vertex start = edge.GetStartVertex();
        Vertex end = edge.GetEndVertex();
        if (edge.IsDirected() != 0)
        {
            start.GetEdges().Add(edge);
            end.GetInputEdges().Add(edge);
        }
        else
        {
            start.GetEdges().Add(edge);
            start.GetInputEdges().Add(edge);
            end.GetEdges().Add(edge);
            end.GetInputEdges().Add(edge);
        }
        PrintBase();
        
    }
    private void RemoveEdge(Edge edgeObj)
    {
        Edge edge = edgeObj.GetComponent<Edge>();
        Vertex start = edge.GetStartVertex();
        Vertex end = edge.GetEndVertex();

        if (edge.IsDirected() != 0)
        {
            start.GetEdges().Remove(edge);
            end.GetInputEdges().Remove(edge);
        }
        else
        {
            start.GetEdges().Remove(edge);
            start.GetInputEdges().Remove(edge);
            end.GetEdges().Remove(edge);
            end.GetInputEdges().Remove(edge);
        }

    }
    private void PrintBase() 
    {
        foreach (Vertex vertex in vertices) 
        {
            Debug.Log($"У вершины {vertex.GetId()} ребра: ");
            foreach(Edge edge in vertex.GetEdges())
            {
                Debug.Log(edge.GetId());
            }
            Debug.Log($"У вершины входят {vertex.GetId()} ребра: ");
            foreach (Edge edge in vertex.GetInputEdges())
            {
                Debug.Log(edge.GetId());
            }
            Debug.Log("-------------------------------------------------");
        }
    }   

    private void AddVertex(Vertex vertex)
    {
        //vertices.Add(vertex, new List<Edge>());
        vertices.Add(vertex);
        _amountOfVertex++;
        _globalVertexID++;
    }
    private static void RemoveVertex(Vertex vertexObj)
    {
        Vertex vertex = vertexObj.GetComponent<Vertex>();
        /*while (vertices[vertex].Count != 0)
        {
            EdgeRemover.Remove(vertices[vertex][0]);
        }*/
        while(vertex.GetEdges().Count != 0)
        {
            EdgeRemover.Remove(vertex.GetEdges()[0]);
        }
        while (vertex.GetInputEdges().Count != 0)
        {
            EdgeRemover.Remove(vertex.GetInputEdges()[0]);
        }
        vertices.Remove(vertex);
    }

}
