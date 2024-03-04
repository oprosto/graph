using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISelectVisiter
{
    void Select(Edge edge);
    void Select(Vertex vertex);
    void Select(Vector3 vector);
    void Select();
}
interface ISelectable<T> 
{
    void Select(T selectToken);
}
public class IsSelectable : MonoBehaviour, ISelectVisiter
{
    public void Select(Edge edge) 
    {
        
    }
    public void Select(Vertex vertex)
    {

    }
    public void Select(Vector3 vector)
    {

    }
    public void Select()
    {

    }
}
