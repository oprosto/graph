using System.Collections;
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
    private void Start()
    {
        //_lineRenderer = GetComponent<LineRenderer>();
    }
    /*
    private void Clear(Edge edge) 
    {
        if (_lastWay == null)
            return;
        if (!_lastWay.Contains(edge))
            return;
        _lineRenderer.SetPositions(null);
        _lastWay = null;
    }*/
    public void Clear() 
    {
        if (_lastWay == null)
            return;
        foreach (Edge e in _lastWay)
        {
            e.gameObject.GetComponent<LineRenderer>().material = _baseMaterial;
        }
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
    }
    public void DisplayWay(List<Edge> way)
    {
        Clear();
        foreach (Edge e in way) 
        {
            e.gameObject.GetComponent<LineRenderer>().material = _DijkstraMaterial;
        }
        _lastWay = way;
        //Vector3[] postions = new Vector3[way.Count*2];
        //_lineRenderer.positionCount = way.Count*2;
        //int i = 0;
        /*Vector3 start_pos = way[0].GetStartVertex().GetPosition();
        Tools.toDijkstraLayer(ref start_pos);
        EdgeTools.FindCoolPosition(way[0], true);
        postions[i] = start_pos;
        i++;*/
        /*
        foreach (Edge edge in way)
        {
            
            Vector3 start_pos = edge.GetStartVertex().GetPosition();
            Tools.toDijkstraLayer(ref start_pos);
            EdgeTools.FindCoolPosition(edge, true);
            postions[i] = start_pos;            
            _lineRenderer.SetPosition(i, start_pos);
            i++;

            Vector3 end_pos = edge.GetEndVertex().GetPosition();
            Tools.toDijkstraLayer(ref end_pos);
            EdgeTools.FindCoolPosition(edge, false);
            postions[i] = end_pos;            
            _lineRenderer.SetPosition(i, end_pos);
            i++;

            //StartCoroutine(waiter());
        }
        _lineRenderer.SetPositions(postions);
        */
    }
    IEnumerator waiter() 
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
