using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Vertex
{
    //public string name { get; set; }
    //public Vector3 position { get; set; }
    //public double value { get; set; }

    private string name;
    private Vector3 position;
    private double value;
    
    public Vertex() 
    {
        int amountOfVertex = VertexDataBase.GetAmountOfVertex();
        name = $"q{amountOfVertex}";
        position = Vector3.zero;
        value = 0;
    }
    public Vertex(string name_, Vector3 position_, double value_)
    {
        name = name_;
        position = position_;
        value = value_;
    }


    public void SetName(string name_) => name = name_;
    public void SetPosition(Vector3 position_) => position = position_;
    public void SetValue(double value_) => value = value_;

    public string GetName() => name;
    public Vector3 GetPosition() => position;
    public double GetValue() => value;




}
