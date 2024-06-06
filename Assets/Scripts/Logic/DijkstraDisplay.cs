using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LineRenderer))]
public class DijkstraDisplay : MonoBehaviour
{
    //[SerializeField] private GameObject _edgeWayMark;
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _DijkstraMaterial;
    //private LineRenderer _lineRenderer;
    private List<Edge> _lastWay = null;
    

    private void Awake()
    {
        AllEvents.OnEdgeRemoved.AddListener(Clear);
    }
    
    public void Clear() 
    {
        if (_lastWay == null)
            return;
        foreach (Edge e in _lastWay)
        {
            e.gameObject.GetComponent<LineRenderer>().material = _baseMaterial;
        }
        _lastWay = null;
    }
    private void Clear(Edge edge)
    {
        if (_lastWay == null)
            return;
        if (!_lastWay.Contains(edge))
            return;
        foreach (Edge e in _lastWay)
        {
            e.gameObject.GetComponent<LineRenderer>().material = _baseMaterial;
        }
        _lastWay = null;
    }
    public void DisplayWay(List<Edge> way)
    {
        foreach (Edge e in way) 
        {
            e.gameObject.GetComponent<LineRenderer>().material = _DijkstraMaterial;
        }
        _lastWay = way;
    }
}
