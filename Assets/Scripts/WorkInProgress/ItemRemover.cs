using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Возможно стоит объединить все ремуверы под itemRemover через паттерн IVisiter. Тогда Vertex, Edge и прочее будут главными объектами, собирающими остальные
public class ItemRemover : MonoBehaviour
{
    //Не знаю, хорошо ли связывать этот компонент с выделением

    public void RemoveItem() 
    {
        if (SelectionSystem.GetSelect().TryGetComponent<IRemovable>(out IRemovable item)) 
        {
            item.Remove();
        }
    }


}
public class VertexRemover: MonoBehaviour
{
    public static void Remove(Vertex vertex)
    {
        if (vertex == null)
            return;
        AllEvents.OnVertexRemoved.Invoke(vertex);
        Destroy(vertex.gameObject);
        AllEvents.OnDeselect.Invoke();

    }
}
public class EdgeRemover: MonoBehaviour 
{
    public static void Remove(Edge edge)
    {
        AllEvents.OnEdgeRemoved.Invoke(edge);
        Destroy(edge.gameObject);
        AllEvents.OnDeselect.Invoke();
    }
}
