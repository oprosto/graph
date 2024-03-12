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
    private void EdgeCreated(Edge edge)
    {
        TMP_Text str = edge.gameObject.GetComponentInChildren<TMP_Text>();
        Vector3 position = EdgeTools.FindCenter(edge);
        float angle = EdgeTools.FindAngle(edge);
        str.transform.position = position;
        str.transform.rotation = Quaternion.Euler(0,0, angle);
        str.text = edge.GetValue().ToString();
    }
    
    private void DisplayMenuCurrentState(Edge edge)
    {
        if (edge == null)
            return;
        //Edge edgeInfo = edge.GetComponent<Edge>();
        //nameField.text = edgeInfo.GetValue().ToString();
    }

}
