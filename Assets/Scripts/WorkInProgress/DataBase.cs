using System;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private static int _amountOfVertex = 0;

    [NonSerialized] public static Dictionary<Vertex, List<Edge>> vertices = new Dictionary<Vertex, List<Edge>>();

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

        if (edge.IsDirected())        
            vertices[start].Add(edge);
        else
        {
            vertices[start].Add(edge);
            vertices[end].Add(edge);
        }
        PrintBase();
    }
    private void RemoveEdge(Edge edgeObj)
    {
        Edge edge = edgeObj.GetComponent<Edge>();
        Vertex start = edge.GetStartVertex();
        Vertex end = edge.GetEndVertex();

        if (edge.IsDirected())
            vertices[start].Remove(edge);
        else
        {
            vertices[start].Remove(edge);
            vertices[end].Remove(edge);
        }
    }
    private void PrintBase() 
    {
        foreach (Vertex vertex in vertices.Keys) 
        {
            Debug.Log($"У вершины {vertex.GetId()} ребра: ");
            foreach(Edge edge in vertices[vertex])
            {
                Debug.Log(edge.GetId());
            }
            
        }
    }   

    private void AddVertex(Vertex vertex)
    {
        vertices.Add(vertex, new List<Edge>());
        _amountOfVertex++;
    }
    private static void RemoveVertex(Vertex vertexObj)
    {
        Vertex vertex = vertexObj.GetComponent<Vertex>();
        while (vertices[vertex].Count != 0)
        {
            EdgeRemover.Remove(vertices[vertex][0]);
        }
        vertices.Remove(vertex);
    }

}
