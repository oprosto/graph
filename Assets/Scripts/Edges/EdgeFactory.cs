using UnityEngine;

public class EdgeFactory : MonoBehaviour
{    
    [SerializeField] private GameObject _edgePrefab;
    [SerializeField] private float _offset = 0.9f;

    private void Start()
    {       
        AllEvents.OnCoordinatesSelect.AddListener(OnDeselected);
        AllEvents.OnEdgeSelect.AddListener(OnDeselect);
    }
    private void CreateByButton(Vertex to) 
    {
        if (SelectionSystem.GetSelect().TryGetComponent<Vertex>(out Vertex from)) 
        {
            Create(from, to);
        }
        else 
        {
            Debug.Log("Try to create edge but from vertex wasnt exist");
        }
        AllEvents.OnVertexSelect.RemoveListener(CreateByButton);
    }
    public void Create(Vertex from, Vertex to, double value = 0, byte direction = 0) 
    {

        GameObject edgeObj = Instantiate(_edgePrefab);
        Edge edge = edgeObj.GetComponent<Edge>();
        edge.Initialize(from, to, value, direction);

        edgeObj.transform.position = EdgeTools.FindCenter(edge);
        edgeObj.transform.rotation = Quaternion.Euler(0, 0, EdgeTools.FindAngle(edge));

        edgeObj.GetComponent<BoxCollider2D>().size = new Vector2(EdgeTools.FindLength(edge) - _offset, 0.5f);
        /*
        if (direction == 0)
        {
            from.AddEdge(edge);
            to.AddInputEdge(edge);
        }
        else
        {
            from.AddEdge(edge);
            to.AddEdge(edge);
            from.AddInputEdge(edge);
            to.AddInputEdge(edge);
        }
        */
        AllEvents.OnEdgeCreated.Invoke(edge);
    }
    private void OnDeselected(Vector3 vector)   //Так плохо объединить все deselect в один
    {
        AllEvents.OnVertexSelect.RemoveListener(CreateByButton);
    }
    private void OnDeselect(Edge edge) 
    {
        AllEvents.OnVertexSelect.RemoveListener(CreateByButton);
    }
    public void StartCreate() 
    {
        AllEvents.OnVertexSelect.AddListener(CreateByButton);
    }
   
}
