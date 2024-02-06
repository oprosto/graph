using TMPro;
using UnityEngine;

public class VertexUI : MonoBehaviour
{
    //[SerializeField] private TMP_Text nameField;

    void Awake()
    {
        Debug.Log("I AWAKE! 1");
        AllEvents.OnNameChanged.AddListener(SetName);
        AllEvents.OnVertexCreated.AddListener(VertexCreated);
    }
    private void SetName(GameObject vertex,string _name) 
    {
        vertex.name = _name;
    }
    private void VertexCreated(GameObject vertexObj, Vertex vertex)
    {
        vertexObj.GetComponentInChildren<TextMeshPro>().text = vertex.GetName();
    }

}
