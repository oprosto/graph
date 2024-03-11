using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�������� ����� ���������� ��� �������� ��� itemRemover ����� ������� IVisiter. ����� Vertex, Edge � ������ ����� �������� ���������, ����������� ���������
public class ItemRemover : MonoBehaviour
{
    //�� ����, ������ �� ��������� ���� ��������� � ����������

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
