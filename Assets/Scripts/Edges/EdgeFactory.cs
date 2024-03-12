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
    public void Create(Vertex from, Vertex to) 
    {
        double value = 10000;
        bool isDirected = false;

        GameObject edgeObj = Instantiate(_edgePrefab);
        Edge edge = edgeObj.GetComponent<Edge>();
        edge.Initialize(from, to, value, isDirected);

        edgeObj.transform.position = EdgeTools.FindCenter(edge);
        edgeObj.transform.rotation = Quaternion.Euler(0, 0, EdgeTools.FindAngle(edge));

        edgeObj.GetComponent<BoxCollider2D>().size = new Vector2(EdgeTools.FindLength(edge) - _offset, 0.5f);

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
