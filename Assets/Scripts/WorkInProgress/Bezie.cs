using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezie : MonoBehaviour
{
    private static float _offsetUI = -0.04f;
    [SerializeField] GameObject _edgeObj;
    Edge _edge;
    Vector3 _startPoint;
    Vector3 _endPoint;
    Vector3 _p3;
    Vector3 _p4;
    private Vector3 findLocalCenter(Vector3 start, Vector3 end) 
    {
        Vector3 result = Vector3.zero;
        result.x = (end.x + start.x) / 2;
        result.y = (end.y + start.y) / 2 + _offsetUI;
        result.z = start.z;
        return result;
    }
    private void UpdateVertex() 
    {
        _edge = GetComponent<Edge>();
        _startPoint = _edge.GetStartVertex().GetPosition();
        _endPoint = _edge.GetEndVertex().GetPosition();
        
    }
    private void FindStablePoints() 
    {
        UpdateVertex();
        float angle = EdgeTools.FindAngle(_edge);
        Vector3 center = EdgeTools.FindCenter(_edge);
        _startPoint = _edge.GetStartVertex().GetPosition();
        _endPoint = _edge.GetEndVertex().GetPosition();
        _p3 = findLocalCenter(_startPoint, center);
        _p4 = findLocalCenter(center, _endPoint);




    }
}
