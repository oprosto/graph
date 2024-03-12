using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EdgeFactory : MonoBehaviour
{    
    [SerializeField] private GameObject _edgePrefab;
    private static GameObject _lastVertex = null;
    private bool _isCreate = false;
        
    private void Start()
    {       
        AllEvents.OnCoordinatesSelect.AddListener(OnDeselected);
        AllEvents.OnVertexSelect.AddListener(CreateTEMPORARY);
    }
    private void CreateTEMPORARY(Vertex vertex) 
    {
        if(_lastVertex == null)
        {
            _lastVertex = vertex.gameObject;
        }
        else if (_isCreate && SelectionSystem.GetSelect().TryGetComponent<Vertex>(out Vertex vertex_)) 
        {
            Create();
        }        
        _isCreate = false;
        _lastVertex = SelectionSystem.GetSelect();
    }
    public void Create() 
    {
        Vertex start = _lastVertex.GetComponent<Vertex>(); ;
        Vertex end = SelectionSystem.GetSelect().GetComponent<Vertex>(); ;
        double value = 10000;
        bool isDirected = false;

        GameObject edgeObj = Instantiate(_edgePrefab);
        Edge edge = edgeObj.GetComponent<Edge>();
        edge.Initialize(start, end, value, isDirected);

        edgeObj.transform.position = EdgeTools.FindCenter(edge);
        edgeObj.transform.rotation = Quaternion.Euler(0, 0, EdgeTools.FindAngle(edge));

        edgeObj.GetComponent<BoxCollider2D>().size = new Vector2(EdgeTools.FindLength(edge), 0.5f);

        AllEvents.OnEdgeCreated.Invoke(edge);
    }
    private void OnDeselected(Vector3 vector)   //Так плохо
    {
        _isCreate = false;
    }
    public void StartCreate() 
    {
        _isCreate = true;

    }
}
