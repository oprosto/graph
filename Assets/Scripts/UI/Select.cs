using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] private GameObject CoordinatesMarker;
    [SerializeField] private GameObject VertexMarker;
    //[SerializeField] private GameObject EdgeMarker;

    [SerializeField] TMP_Text CoordsText;

    private void Awake()
    {
        AllEvents.OnVertexSelect.AddListener(OnVertexSelected);
        AllEvents.OnCoordinatesSelect.AddListener(OnCoordinatesSelected);
        AllEvents.OnVertexDestroy.AddListener(RemoveSelection);
    }
    private void OnVertexSelected(GameObject vertex)
    {
        if (vertex == null)
            return;
        CoordinatesMarker.SetActive(false); 
        VertexMarker.SetActive(true);

        Vector3 vertexCord = vertex.GetComponent<Vertex>().GetPosition();
        Tools.markToVertexLayout(ref vertexCord);
        VertexMarker.transform.position = vertexCord;
    }
    private void RemoveSelection(GameObject vertex) 
    {
        VertexMarker.SetActive(false);
    }
    private void OnEdgeSelected() 
    {
    
    }
    private void OnCoordinatesSelected(Vector3 coords)
    {
        CoordinatesMarker.SetActive(true);
        VertexMarker.SetActive(false);


        CoordinatesMarker.transform.position = coords;
        AllEvents.OnVertexSelect.Invoke(null);
        //Temp
        string temp;
        temp = "X: " + coords.x.ToString() + " Y: " + coords.y.ToString();
        CoordsText.text = temp;
    }
}
