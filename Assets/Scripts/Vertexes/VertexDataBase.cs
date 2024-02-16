using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

public class VertexDataBase : MonoBehaviour
{
    private static int amountOfVertex = 0;

    [NonSerialized] public static List<GameObject> vertices = new List<GameObject>();

    //public static Dictionary<Vertex, GameObject> vertices = new Dictionary<Vertex, GameObject>();
    public static int GetAmountOfVertex() => amountOfVertex;

    void Awake()
    {
        AllEvents.OnVertexCreated.AddListener(CreateVertex);
        AllEvents.OnVertexDestroy.AddListener(DeleteVertex);
    }

    private static void CreateVertex(GameObject vertex)
    {
        vertices.Add(vertex);
        amountOfVertex++;
    }
    private static void DeleteVertex(GameObject vertex)
    {
        vertices.Remove(vertex);
    }

}
