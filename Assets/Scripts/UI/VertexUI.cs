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
        vertex.GetComponent<Vertex>().SetName(_name);// = _name;
    }
    private void VertexCreated(GameObject vertex)
    {
        vertex.GetComponentInChildren<TextMeshPro>().text = vertex.GetComponent<Vertex>().GetName();
    }
    private void DisplayMenuCurrentState(GameObject vertex) 
    {
        if (vertex == null)
            return;
        Vertex vertexInfo = vertex.GetComponent<Vertex>(); 
        nameField.text = vertexInfo.GetName();
        valueField.text = vertexInfo.GetValue().ToString();
    }

}
