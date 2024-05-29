using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class VertexFactory : MonoBehaviour
{
    [SerializeField] private TMP_Text NameField, ValueField;

    [SerializeField] private GameObject vertexPrefab;


    public void Create()
    {
        double value;
        string name;
        Vector3 position;

        if (double.TryParse(ValueField.text, out value))        
            Debug.Log("Create Vertex. Value was not parsed!");
        
        name = NameField.text.Substring(0, NameField.text.Length - 1);

        position = InputCoords.GetCoords();
        GameObject vertexObj = Instantiate(vertexPrefab);
        Vertex vertex = vertexObj.GetComponent<Vertex>();
        vertex.Initialize(name, position, value);
        AllEvents.OnVertexCreated.Invoke(vertex);
        AllEvents.OnDeselect.Invoke();
    }

    /*
    public void Remove(GameObject item) 
    {
        AllEvents.OnVertexRemoved.Invoke(item);
        Destroy(item);
        AllEvents.OnDeselect.Invoke();
    }
    */
}
