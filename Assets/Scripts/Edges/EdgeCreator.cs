using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EdgeCreator : MonoBehaviour
{
    //[SerializeField] private TMP_Text ValueField;

    [SerializeField] private GameObject edgePrefab;
    //[SerializeField] private GameObject _start, _end;
    private static GameObject lastVertex = null;
    private bool _isCreate = false;
        
    private void Awake()
    {
        AllEvents.OnVertexSelect.AddListener(CreateEdge);
        AllEvents.OnCoordinatesSelect.AddListener(OnDeselected);
    }
    private void CreateEdge(GameObject vertex) 
    {
        if (_isCreate && lastVertex != null && vertex != null) 
        {
            Vertex start = lastVertex.GetComponent<Vertex>(); ;
            Vertex end = vertex.GetComponent<Vertex>(); ;
            double value = 10000;
            bool isDirected = false;

            GameObject edgeObj = Instantiate(edgePrefab);
            Edge edge = edgeObj.GetComponent<Edge>();
            edge.Initialize(start, end, value, isDirected);
            AllEvents.OnEdgeCreated.Invoke(edgeObj);

        }
        _isCreate = false;
        lastVertex = vertex;
    }
    
    private void OnDeselected(Vector3 vector)   //Так плохо
    {
        _isCreate = false;
    }
    public void StartCreate() 
    {
        _isCreate = true;
    }
}
