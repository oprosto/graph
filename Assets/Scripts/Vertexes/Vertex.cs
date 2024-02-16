using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Vertex : MonoBehaviour
{
    //public string name { get; set; }
    //public Vector3 position { get; set; }
    //public double value { get; set; }

    private string _name;
    private Vector3 _position;
    private double _value;
    
    //public Vertex() 
    //{
    //    int amountOfVertex = VertexDataBase.GetAmountOfVertex();
    //    name = $"q{amountOfVertex}";
    //    position = Vector3.zero;
    //    value = 0;
    //}
    //public Vertex(string name_, Vector3 position_, double value_)
    //{
    //    name = name_;
    //    position = position_;
    //    value = value_;
    //}
    /*
    public void Initialize()
    {
        int amountOfVertex = VertexDataBase.GetAmountOfVertex();
        _name = $"q{amountOfVertex}";
        _position = Vector3.zero;
        _value = 0;
    }
    */
    public void Initialize(string name, Vector3 position, double value)
    {
        if (name == null)
        {
            int amountOfVertex = VertexDataBase.GetAmountOfVertex();
            _name = $"q{amountOfVertex}";
        }
        else
            _name = name;
        _position = position;
        _value = value;
    }

    public void SetName(string name) => _name = name;
    public void SetPosition(Vector3 position) => _position = position;
    public void SetValue(double value) => _value = value;

    public string GetName() => _name;
    public Vector3 GetPosition() => _position;
    public double GetValue() => _value;




}
