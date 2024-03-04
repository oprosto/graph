using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class VertexDataBase : MonoBehaviour
{
    private static int amountOfVertex = 0;

    //[NonSerialized] public static List<GameObject> vertices = new List<GameObject>();
    [NonSerialized] public static Dictionary<Vertex, List<Edge>> vertices = new Dictionary<Vertex, List<Edge>>();

    //public static Dictionary<Vertex, GameObject> vertices = new Dictionary<Vertex, GameObject>();
    public static int GetAmountOfVertex() => amountOfVertex;

    private void Awake()
    {
        AllEvents.OnVertexCreated.AddListener(AddVertex);
        AllEvents.OnVertexDestroy.AddListener(RemoveVertex);
        AllEvents.OnEdgeCreated.AddListener(AddEdge);
        AllEvents.OnEdgeDestroy.AddListener(RemoveEdge);
    }
    private void AddEdge(GameObject edgeObj) 
    {
        Edge edge = edgeObj.GetComponent<Edge>();
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
    private void RemoveEdge(GameObject edgeObj)
    {
    
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

    private void AddVertex(GameObject vertexObj)
    {
        vertices.Add(vertexObj.GetComponent<Vertex>(), new List<Edge>());
        amountOfVertex++;
    }
    private static void RemoveVertex(GameObject vertex)
    {
        vertices.Remove(vertex.GetComponent<Vertex>());
    }

}
