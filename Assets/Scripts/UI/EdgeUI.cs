using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class EdgeUI : MonoBehaviour
{
    //private float offset = 0.5f;

    void Awake()
    {       
        AllEvents.OnEdgeCreated.AddListener(EdgeCreated);
        AllEvents.OnEdgeSelect.AddListener(DisplayMenuCurrentState);
    }   
    private void EdgeCreated(GameObject edgeObj)
    {
        Edge edge = edgeObj.GetComponent<Edge>();
        TMP_Text str = edgeObj.GetComponentInChildren<TMP_Text>();
        Vector3 position = FindStringPosition(edge);
        float angle = FindStringAngle(edge);
        str.transform.position = position;
        str.transform.rotation = Quaternion.Euler(0,0, angle);
        str.text = edge.GetValue().ToString();
    }
    private Vector3 FindStringPosition(Edge edge) 
    {
        Vector3 resultPosition = Vector3.zero;
        Vector3 start = edge.GetStartVertex().GetPosition();
        Vector3 end = edge.GetEndVertex().GetPosition();

        resultPosition.x = (end.x + start.x)/2;
        resultPosition.y = (end.y + start.y)/2;
        resultPosition.z = start.z;
        return resultPosition;
    }
    private float FindStringAngle(Edge edge) 
    {
        float angle;
        Vector3 resultPosition = Vector3.zero;
        Vector3 start = edge.GetStartVertex().GetPosition();
        Vector3 end = edge.GetEndVertex().GetPosition();
        if (start.x - end.x == 0)
            return 90;
        angle = Mathf.Atan((start.y - end.y) / (start.x - end.x)) * Mathf.Rad2Deg;
        return angle;
    }
    private void DisplayMenuCurrentState(GameObject edge)
    {
        if (edge == null)
            return;
        //Edge edgeInfo = edge.GetComponent<Edge>();
        //nameField.text = edgeInfo.GetValue().ToString();
    }

}
