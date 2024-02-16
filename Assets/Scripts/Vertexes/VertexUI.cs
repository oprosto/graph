using TMPro;
using UnityEngine;

public class VertexUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text valueField;

    void Awake()
    {
        AllEvents.OnNameChanged.AddListener(SetName);
        AllEvents.OnVertexCreated.AddListener(VertexCreated);
        AllEvents.OnVertexSelect.AddListener(DisplayMenuCurrentState);
    }
    private void SetName(GameObject vertex,string _name) 
    {
        vertex.name = _name;
    }
    private void VertexCreated(GameObject vertexObj, Vertex vertex)
    {
        vertexObj.GetComponentInChildren<TextMeshPro>().text = vertex.GetName();
    }
    private void DisplayMenuCurrentState(GameObject vertexObj, Vertex vertex) 
    {
        nameField.text = vertex.GetName();
        valueField.text = vertex.GetValue().ToString();
    }

}
