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
    }
    private void OnVertexSelected(Vertex vertex)
    {
        CoordinatesMarker.SetActive(false);
        VertexMarker.SetActive(true);

        Vector3 vertexCord = vertex.GetPosition();
        Tools.markToVertexLayout(ref vertexCord);
        VertexMarker.transform.position = vertexCord;
    }
    private void OnEdgeSelected() 
    {
    
    }
    private void OnCoordinatesSelected(Vector3 coords)
    {
        CoordinatesMarker.SetActive(true);
        VertexMarker.SetActive(false);


        CoordinatesMarker.transform.position = coords;
        //Temp
        string temp;
        temp = "X: " + coords.x.ToString() + " Y: " + coords.y.ToString();
        CoordsText.text = temp;
    }
}
