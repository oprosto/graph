using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EdgeFactory))]
public class FileHandlerUI : MonoBehaviour
{
    [SerializeField] private GameObject vertexPrefab;
    private static EdgeFactory _edgeFactory = null;
    private static int _maxFiles = 0;
    
    private void Awake()
    {
        _edgeFactory = GetComponent<EdgeFactory>();
    }  
    
    public void LoadFile(string path) 
    {
        if (!File.Exists(path))
        {
            Debug.Log("Load file is not exist");
            return;
        }
        DataBase.ClearScene();
        List<RawVertex> rawVertices = FileHandler.LoadFromJSON<RawVertex>(path);
        Dictionary<int, Vertex> vertices = new Dictionary<int, Vertex>();
        int vertexCount = 0;
        foreach (RawVertex rawVertex in rawVertices)
        {
            
            GameObject vertexObj = Instantiate(vertexPrefab);
            Vertex vertex = vertexObj.GetComponent<Vertex>();
            vertex.Initialize(rawVertex._name, rawVertex._position, rawVertex._value);
            AllEvents.OnVertexCreated.Invoke(vertex);
            vertices.Add(rawVertex._id, vertex);
            vertexCount++;
        }
        foreach (RawVertex rawVertex in rawVertices)
        {
            foreach (RawEdge rawEdge in rawVertex._edges)
            {
                _edgeFactory.Create(vertices[rawVertex._id], vertices[rawEdge._id], rawEdge._value, rawEdge._direction);
            }
        }
       
    }
    public void SaveFile(string path) 
    {
        //Временно
        List<RawVertex> rawVertex = new List<RawVertex>();
        foreach (Vertex vertex in DataBase.vertices)
        {
            rawVertex.Add(new RawVertex(vertex));
        }
        List<Vertex> temp = DataBase.vertices.ToList();
        FileHandler.SaveToJSON<RawVertex>(rawVertex,path);
    }
    [Serializable]
    public class PlayerData 
    {
        public int i = 0;
        public char b = 'b';
        public bool c = false;
        public Vector3 pos = Vector3.up;
    }
}
