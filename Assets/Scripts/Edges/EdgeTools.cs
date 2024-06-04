using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class EdgeTools
{
    private static float _offsetUI = -0.04f;
    private static float _globalOffset = 0.25f;

    public static Vector3 FindCoolPosition(Edge edge, bool isStart) 
    {
        Vector3 resultPosition;
        Vector3 startPosition = edge.GetStartVertex().GetPosition();
        Vector3 endPosition = edge.GetEndVertex().GetPosition();
        float angle = FindAngle(edge);
        if (isStart)
            resultPosition = startPosition;
        else
            resultPosition = endPosition;

        if (startPosition.y > endPosition.y)        
            angle += 90;        
        else
            angle -= 90;

        resultPosition.x += Mathf.Cos(Mathf.Deg2Rad * angle) * _globalOffset;
        resultPosition.y += Mathf.Sin(angle) * _globalOffset;
        return resultPosition;
    }
    public static Vector3 FindCenter(Edge edge)
    {
        Vector3 resultPosition = Vector3.zero;


        //Vector3 start = edge.GetStartVertex().GetPosition();
        //Vector3 end = edge.GetEndVertex().GetPosition();
        
        Vector3 start = FindCoolPosition(edge, true);
        Vector3 end = FindCoolPosition(edge, false);

        resultPosition.x = (end.x + start.x) / 2;
        resultPosition.y = (end.y + start.y) / 2 + _offsetUI;
        resultPosition.z = start.z;

        return resultPosition;
    }
    
    public static float FindAngle(Edge edge)
    {
        float angle;
        Vector3 start = edge.GetStartVertex().GetPosition();
        Vector3 end = edge.GetEndVertex().GetPosition();
        if (start.x - end.x == 0)
            return 90;
        angle = Mathf.Atan((start.y - end.y) / (start.x - end.x)) * Mathf.Rad2Deg;
        return angle;
    }
    public static float FindAngle(Vertex from, Vertex to)
    {
        float angle;
        Vector3 start = from.GetPosition();
        Vector3 end = to.GetPosition();
        if (start.x - end.x == 0)
            return 90;
        angle = Mathf.Atan((start.y - end.y) / (start.x - end.x)) * Mathf.Rad2Deg;
        return angle;
    }
    public static float FindLength(Edge edge) 
    {
        Vector3 start = edge.GetStartVertex().GetPosition();
        Vector3 end = edge.GetEndVertex().GetPosition();
        float length = Mathf.Sqrt(Mathf.Pow(start.x - end.x, 2) + Mathf.Pow(start.y - end.y, 2));
        return length;
    } 
}
