using TMPro;
using Unity.Rendering.HybridV2;
using UnityEngine;

public class VertexUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text valueField;

    void Awake()
    {
        AllEvents.OnVertexNameChanged.AddListener(SetName);
        AllEvents.OnVertexCreated.AddListener(VertexCreated);
        AllEvents.OnVertexSelect.AddListener(DisplayMenuCurrentState);
    }
    private void SetName(Vertex vertex,string _name) 
    {
        vertex.GetComponent<Vertex>().SetName(_name);// = _name;
    }
    private void SetValue()
    {
        
    }
    private void VertexCreated(Vertex vertex)
    {
        vertex.GetComponentInChildren<TextMeshPro>().text = vertex.GetName();
    }
    private void DisplayMenuCurrentState(Vertex vertex) 
    {
        if (vertex == null)
            return;
        nameField.text = vertex.GetName();
        valueField.text = vertex.GetValue().ToString();
    }

}
