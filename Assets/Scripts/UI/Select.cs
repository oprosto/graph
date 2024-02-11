using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] private GameObject selecter; 
    private void Awake()
    {
        AllEvents.OnVertexChoosed.AddListener(OnSelected);
    }
    private void OnSelected(Vertex vertex)
    {
        selecter.SetActive(true);
        selecter.transform.position = vertex.GetPosition();
    }
}
