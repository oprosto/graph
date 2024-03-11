using TMPro;
using UnityEngine;
using UnityEngine.Events;

/*[RequireComponent(typeof(VertexUI))]
[RequireComponent (typeof(VertexStatementDisplay))]*/
public class Vertex : MonoBehaviour, ISelectable, IRemovable
{
    private VertexUI _vertexUI;
    private VertexStatementDisplay _vertexStatementDisplay;

    private string _name;
    private Vector3 _position;
    private double _value;
    private int _id;

    private static int _globalId = 0;
    /*
    private void Awake()
    {
        _vertexUI = GetComponent<VertexUI>();
        _vertexStatementDisplay = GetComponent<VertexStatementDisplay>();
    }*/
    public void Initialize(string name, Vector3 position, double value)
    {
        if (name == null)
        {
            int amountOfVertex = DataBase.GetAmountOfVertex();
            _name = $"q{amountOfVertex}";
        }
        else
            _name = name;
        _position = position;
        _value = value;
        _id = _globalId;
        _globalId++;
    }

    public void SetName(string name) => _name = name;
    public void SetPosition(Vector3 position) => _position = position;
    public void SetValue(double value) => _value = value;

    public string GetName() => _name;
    public Vector3 GetPosition() => _position;
    public double GetValue() => _value;
    public int GetId() => _id;

    public void OnSelect()
    {
        AllEvents.OnVertexSelect.Invoke(this.gameObject);
    }
    public void Remove()
    {
        VertexRemover.Remove(this.gameObject);
    }
}
