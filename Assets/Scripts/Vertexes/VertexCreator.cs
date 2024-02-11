using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class VertexCreator : MonoBehaviour
{
    [SerializeField] private TMP_Text NameField, ValueField;

    [SerializeField] private GameObject vertexPrefab;

    public void CreateVertex()
    {
        //Vertex vertex = new Vertex();
        double value;
        string name;
        Vector3 position;

        if (double.TryParse(ValueField.text, out value))        
            Debug.Log("Create Vertex. Value was not parsed!");
        
        name = NameField.text;

        position = InputCoords.GetCoords();
        //position = Vector3.zero;

        
        //Vertex vertex = ;
        //vertex.Initialize(name, position, value);
        //Vertex vertex = new Vertex(name, position, value);
        //vertex.SetName(name);
        //vertex.SetPosition(position);
        //vertex.SetValue(value);

        GameObject vertexObj = Instantiate(vertexPrefab);
        Vertex vertex = vertexObj.AddComponent<Vertex>();
        vertex.Initialize(name, position, value);
        AllEvents.OnVertexCreated.Invoke(vertexObj, vertex);
    }

}
