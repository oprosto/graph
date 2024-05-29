using TMPro;
using Unity.Rendering.HybridV2;
using UnityEngine;

public class VertexUI : MonoBehaviour
{
    //[SerializeField] private TMP_Text nameField;
    //[SerializeField] private TMP_Text valueField;

    void Awake()
    {
        AllEvents.OnVertexNameChanged.AddListener(SetName);
        AllEvents.OnVertexCreated.AddListener(VertexCreated);
        AllEvents.OnVertexValueChanged.AddListener(SetValue);
        //AllEvents.OnVertexSelect.AddListener(ChangeValue);
    }
    private void SetName(Vertex vertex,string name) 
    {
        vertex.SetName(name);// = _name;
        vertex.GetComponentInChildren<TextMeshPro>().text = name;
    }
    private void SetValue(Vertex vertex, double value)
    {
        vertex.SetValue(value);
        vertex.GetComponentInChildren<TextMeshPro>().text = value.ToString();
    }
    private void VertexCreated(Vertex vertex)
    {
        vertex.GetComponentInChildren<TextMeshPro>().text = vertex.GetName();
    }
    /*
    private void ChangeValue(Vertex vertex) 
    {
        if (vertex == null)
            return;
        nameField.text = vertex.GetName();
        valueField.text = vertex.GetValue().ToString();
    }
    */

}
