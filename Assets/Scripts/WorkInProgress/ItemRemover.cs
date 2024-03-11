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
    public static void Remove(GameObject vertexObj)
    {
        if (vertexObj == null)
            return;
        AllEvents.OnVertexRemoved.Invoke(vertexObj);
        Destroy(vertexObj);
        AllEvents.OnVertexSelect.Invoke(null);

    }
}
public class EdgeRemover: MonoBehaviour 
{
    public static void Remove(GameObject edgeObj)
    {
        AllEvents.OnEdgeRemoved.Invoke(edgeObj);
        Destroy(edgeObj);
        AllEvents.OnDeselect.Invoke();
    }
}
