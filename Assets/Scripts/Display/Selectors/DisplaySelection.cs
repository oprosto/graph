using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySelection : MonoBehaviour
{
    [SerializeField] private GameObject _coordinatesMarker;
    [SerializeField] private GameObject _vertexMarker;
    [SerializeField] private GameObject _edgeMarker;
    private LineRenderer _lineMarker;

    //[SerializeField] TMP_Text _coordsText;

    private void Awake()
    {
        _lineMarker = _edgeMarker.GetComponent<LineRenderer>();
    }
    private void Start()
    {
        AllEvents.OnVertexSelect.AddListener(DisplayVertexSelector);
        AllEvents.OnCoordinatesSelect.AddListener(DisplayCurrentPosition);
        //AllEvents.OnVertexRemoved.AddListener(RemoveVertexSelection);
        AllEvents.OnEdgeSelect.AddListener(DisplayEdgeSelector);
        //AllEvents.OnEdgeRemoved.AddListener(RemoveEdgeSelection);
        AllEvents.OnDeselect.AddListener(Deselect);
    }
    private void DisplayVertexSelector(Vertex vertex)
    {
        if (vertex == null)
            return;
        Deselect();
        _vertexMarker.SetActive(true);

        Vector3 vertexCord = vertex.GetComponent<Vertex>().GetPosition();
        Tools.toSelectorLayer(ref vertexCord);
        _vertexMarker.transform.position = vertexCord;
    }
    /*
    private void RemoveVertexSelection(Vertex vertex) 
    {
        _vertexMarker.SetActive(false);
    }
    */
    private void DisplayEdgeSelector(Edge edge) 
    {
        if (edge == null)
            return;

        Deselect();
        _edgeMarker.SetActive(true);

        //Vector3 start = edge.GetStartVertex().GetPosition();
        //Vector3 end = edge.GetEndVertex().GetPosition();
        Vector3 start = EdgeTools.FindCoolPosition(edge, true);
        Vector3 end = EdgeTools.FindCoolPosition(edge, false);
        Tools.toSelectorLayer(ref start);                           //œŒƒ”Ã¿“‹ Õ¿ –»Õ∆»À
        Tools.toSelectorLayer(ref end);
        _lineMarker.SetPosition(0, start);
        _lineMarker.SetPosition(1, end);
    }
    /*
    private void RemoveEdgeSelection(Edge edge)
    {
        _edgeMarker.SetActive(false);
    }
    */
    
    private void DisplayCurrentPosition(Vector3 coords)
    {
        Deselect();
        _coordinatesMarker.SetActive(true);

        _coordinatesMarker.transform.position = coords;
    }
    
    private void Deselect() 
    {
        _coordinatesMarker.SetActive(false);
        _vertexMarker.SetActive(false);
        _edgeMarker.SetActive(false);
    }
}
