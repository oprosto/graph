using System;
using TMPro;
using UnityEngine;

public class SelectedItemUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _displayValue;
    [SerializeField] private TMP_Text _valueField;
    [SerializeField] private TMP_Text _nameField;
    private void Awake()
    {
        
    }
    private void Start()
    {
        AllEvents.OnVertexSelect.AddListener(DisplayVertexValue);
        AllEvents.OnEdgeSelect.AddListener(DisplayEdgeValue);
        AllEvents.OnDeselect.AddListener(Deselect);
    }

    private void Deselect()
    {
        _displayValue.text = "";
    }

    public void ChangeName() 
    {
        if (SelectionSystem.GetSelect().TryGetComponent<Vertex>(out Vertex vertex))
        {
            AllEvents.OnVertexNameChanged.Invoke(vertex, _nameField.text);
            return;
        }
    }
    public void ChangeValue() 
    {
        if (SelectionSystem.GetSelect() == null)
            return;
        if (SelectionSystem.GetSelect().TryGetComponent<Vertex>(out Vertex vertex))
        {
            double value;
            if (double.TryParse(_valueField.text.Remove(_valueField.text.Length-1), out double data))
            {
                value = data;
            }
            else 
            {
                Debug.Log("Bad input");
                return;
            }
            AllEvents.OnVertexValueChanged.Invoke(vertex, value);
            DisplayVertexValue(vertex);
            return;
        }
        if (SelectionSystem.GetSelect().TryGetComponent<Edge>(out Edge edge))
        {
            double value;
            if (double.TryParse(_valueField.text.Remove(_valueField.text.Length - 1), out double data))
            {
                value = data;
            }
            else
            {
                Debug.Log("Bad input");
                return;
            }
            AllEvents.OnEdgeValueChanged.Invoke(edge, value);
            DisplayEdgeValue(edge);
            return;
        }
    }

    private void DisplayEdgeValue(Edge edge)
    {
        _displayValue.text = edge.GetValue().ToString();
    }

    private void DisplayVertexValue(Vertex vertex)
    {
        _displayValue.text = vertex.GetValue().ToString();
    }
}
