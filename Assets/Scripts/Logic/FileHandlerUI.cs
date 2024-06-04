using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
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
    
    private void Start()
    {
        //string path = EditorUtility.SaveFilePanel("Saving file", Application.dataPath, "Graph", "json");
        
        //int[][] arr = new int[][]{ new int[]{ 10, 20, 30 }, new int[] { 21,35,45}, new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };
        //int[] arr1 = new int[] {10,20,30};
        //List<int[]> arr = new List<int[]>();
        //arr.Add({ 1,2,3});
        //string json = JsonHelper.ToJson<int>(arr,true);
        //File.WriteAllText(path, json);
    }
    
    public void LoadFile(string path) 
    {
//#if UNITY_EDITOR
//        string path = EditorUtility.OpenFilePanel("Load", Application.dataPath, "json");
//#endif
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
            //_vertexFactory.Create(rawVertex._name, rawVertex._position, rawVertex._value);
            vertexCount++;
        }
        foreach (RawVertex rawVertex in rawVertices)
        {
            foreach (RawEdge rawEdge in rawVertex._edges)
            {
                /*if (rawEdge._direction == 0)
                {
                    if (rawEdge._id < rawVertex._id)
                        continue;
                }*/
                _edgeFactory.Create(vertices[rawVertex._id], vertices[rawEdge._id], rawEdge._value, rawEdge._direction);
                //GameObject edgeObj = Instantiate(edgePrefab);
                //Edge edge = edgeObj.GetComponent<Edge>();
                //edge.Initialize(vertices[rawVertex._id], vertices[rawEdge._id], rawEdge._value, rawEdge._direction);
                //AllEvents.OnEdgeCreated.Invoke(edge);
            }
        }
        Debug.Log("NIGGGER");
        //JsonUtility.FromJson<>();
    }
    public void SaveFile(string path) 
    {
//#if UNITY_EDITOR
//        string path = EditorUtility.SaveFilePanel("Saving file", Application.dataPath, "Graph", "json");
//#endif
        /*if (!File.Exists(path))
        {
            Debug.Log("Wrong file");
            return;
        }*/
        //��������
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
