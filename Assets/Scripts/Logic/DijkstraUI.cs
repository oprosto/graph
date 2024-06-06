using TMPro;
using UnityEngine;

[RequireComponent(typeof(DiykstraMethod))]
[RequireComponent(typeof(DijkstraDisplay))]
public class DijkstraUI : MonoBehaviour
{
    [SerializeField] private GameObject _dijkstraPanel;
    [SerializeField] private TMP_Text _startText;
    [SerializeField] private TMP_Text _endText;
    [SerializeField] private TMP_Text _result;
    private DiykstraMethod _dijkstra;
    private DijkstraDisplay _dijkstraDisplay;
    private bool _showDijkstra = true;
    private Vertex _start = null;
    private Vertex _end = null;
    private void Awake()
    {
        AllEvents.OnVertexRemoved.AddListener(RemoveFromChoosen);
    }
    private void RemoveFromChoosen(Vertex vertex) 
    {
        if (_start == vertex)
        {
            _start = null;
            _startText.text = "";
        }
        if (_end == vertex)
        {
            _end = null;
            _endText.text = "";
        }
    }
    private void Start()
    {
        _dijkstra = GetComponent<DiykstraMethod>();
        _dijkstraDisplay = GetComponent<DijkstraDisplay>();
    }
    public void OpenCloseDijkstraPanel() 
    {
        if (_showDijkstra)
        {
            _dijkstraPanel.SetActive(true);
            _showDijkstra = false;
        }
        else 
        {
            _dijkstraPanel.SetActive(false);
            _showDijkstra = true;
        }
           
    }
    public void RememberStartVertex() 
    {
        if (SelectionSystem.GetSelect() == null)
            return;
        if (SelectionSystem.GetSelect().TryGetComponent<Vertex>(out Vertex vertex))
        {
            _start = vertex;
            _startText.text = vertex.GetName();
        }    
    }
    public void RememberEndVertex() 
    {
        if (SelectionSystem.GetSelect() == null)
            return;
        if (SelectionSystem.GetSelect().TryGetComponent<Vertex>(out Vertex vertex))
        {
            _end = vertex;
            _endText.text = vertex.GetName();
        }
    }
    public void StartDijkstra() 
    { 
        if (_start != null && _end != null)
        {
            ClearWay();
            double res = _dijkstra.startDijkstra(_start, _end);
            if (res == double.MaxValue)
                _result.text = "No way";
            else
                _result.text = res.ToString();
        }
    }
    public void ClearWay() 
    {
        _result.text = "";
        _dijkstraDisplay.Clear();
    }
}
