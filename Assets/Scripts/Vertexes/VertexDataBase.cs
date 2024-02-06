using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

public class VertexDataBase : MonoBehaviour
{
    protected static int amountOfVertex = 0;

    //protected static List<Vertex> vertices = new List<Vertex>();

    public static Dictionary<Vertex, GameObject> vertices = new Dictionary<Vertex, GameObject>();
    public static int GetAmountOfVertex() => amountOfVertex;

    void Awake()
    {
        Debug.Log("I AWAKE! 2");
        AllEvents.OnVertexCreated.AddListener(CreateVertex);
    }

    private static void CreateVertex(GameObject vertexObj_ ,Vertex vertex_)
    {
        vertices.Add(vertex_ ,vertexObj_);
        amountOfVertex++;
    }

}
