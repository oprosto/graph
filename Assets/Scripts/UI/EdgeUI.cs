using System;
using TMPro;
using UnityEngine;

public class EdgeUI : MonoBehaviour
{
    //private float offset = 0.5f;

    void Awake()
    {       
        AllEvents.OnEdgeCreated.AddListener(EdgeCreated);
        AllEvents.OnEdgeValueChanged.AddListener(SetValue);
        //AllEvents.OnEdgeSelect.AddListener(ChangeValue);
    }

    private void SetValue(Edge edge, double value)
    {
        edge.SetValue(value);
        edge.gameObject.GetComponentInChildren<TextMeshPro>().text = value.ToString();
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
    
    /*private void ChangeValue(Edge edge)
    {
        if (edge == null)
            return;
    }*/

}
