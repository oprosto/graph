using TMPro;
using UnityEngine;
using Toggle = UnityEngine.UI.Toggle;

enum EdgeDropDown 
{
    NonDirected = 0,
    Start,
    End
};
public class Menu : MonoBehaviour
{
    //Group
    [SerializeField] GameObject _vertexFactory, _edgeFactory;
    //Info
    [SerializeField] TMP_Text _nameInfo, _valueInfo;
    //Vertexes
    [SerializeField] TMP_InputField _vertexName, _vertexValue;
    [SerializeField] Toggle  _vertexNameToggle;
    //Edges
    [SerializeField] TMP_InputField _edgeValue;
    [SerializeField] Toggle _edgeValueToggle;
    //Current selected
    private Vertex _vertex = null;
    private Edge _edge = null;
    private void Awake()
    {
        AllEvents.OnVertexSelect.AddListener(DisplayVertexexUI);
        AllEvents.OnEdgeSelect.AddListener(DisplayEdgesUI);
        AllEvents.OnDeselect.AddListener(DisplayVertexexUI);
    }
    private void UpdateVertexInfo()
    {
        if (_vertex.GetValue() != 0)
            _valueInfo.text = _vertex.GetValue().ToString();
        else
            _valueInfo.text = string.Empty;
        _nameInfo.text = _vertex.GetName();
    }
    private void UpdateEdgeInfo() 
    {
        _valueInfo.text = _edge.GetValue().ToString();
    }
    private void DisplayVertexexUI()
    {
        _nameInfo.text = string.Empty;
        _valueInfo.text = string.Empty;
        _vertexFactory.SetActive(true);
        _edgeFactory.SetActive(false);
        _vertex = null;
        _edge = null;
    }
    private void DisplayVertexexUI(Vertex vertex) 
    {
        _nameInfo.text = vertex.GetName();
        if (vertex.GetValue() != 0)
            _valueInfo.text = vertex.GetValue().ToString();
        else
            _valueInfo.text = string.Empty;
        _vertexFactory.SetActive(true);
        _edgeFactory.SetActive(false);
        _vertex = vertex;
        _edge = null;
        _vertexNameToggle.isOn = _vertex.gameObject.GetComponentInChildren<TextMeshPro>().enabled;

    }
    private void DisplayEdgesUI(Edge edge)
    {
        _valueInfo.text = edge.GetValue().ToString();
        _nameInfo.text = string.Empty;
        _vertexFactory.SetActive(false);
        _edgeFactory.SetActive(true);
        _vertex = null;
        _edge = edge;
        _edgeValueToggle.isOn = _edge.gameObject.GetComponentInChildren<TextMeshPro>().enabled;
    }
    public void Clear() 
    {
        
        _vertexName.text = string.Empty;
        _edgeValue.text = string.Empty;
    }
    public void OnVertexNameChanged() 
    {
        if (_vertex != null)
            AllEvents.OnVertexNameChanged.Invoke(_vertex, _vertexName.text);
        UpdateVertexInfo();
    }
    
    public void OnVertexValueChanged() 
    {
        if (_vertex == null)
            return;
        double value;
        if (double.TryParse(_vertexValue.text, out value))
            AllEvents.OnVertexValueChanged.Invoke(_vertex, value);
        UpdateVertexInfo();
        
    }
    
    public void OnEdgeValueChanged() 
    {
        if (_edge == null)
            return;
        double value;
        if (double.TryParse(_edgeValue.text, out value))
            AllEvents.OnEdgeValueChanged.Invoke(_edge, value);
        UpdateEdgeInfo();
        
            
    }
    public void OnVertexDisplayNameChangeState() 
    {
        if (_vertex == null)
            return;
        if (_vertexNameToggle.isOn)
            _vertex.gameObject.GetComponentInChildren<TextMeshPro>().enabled = true;
        else
            _vertex.gameObject.GetComponentInChildren<TextMeshPro>().enabled = false;
    }
    /*
    public void OnVertexDisplayValueChangeState()
    {
        if (_vertex == null)
            return;
        if (_edgeValueToggle.isOn)
            _vertex.gameObject.GetComponentInChildren<TextMeshPro>().enabled = true;
        else
            _vertex.gameObject.GetComponentInChildren<TextMeshPro>().enabled = false;
    }
    */
    public void OnEdgeDisplayValueChangeState()
    {
        if (_edge == null)
            return;
        if (_edgeValueToggle.isOn)
            _edge.gameObject.GetComponentInChildren<TextMeshPro>().enabled = true;
        else
            _edge.gameObject.GetComponentInChildren<TextMeshPro>().enabled = false;
    }
    public void OnEdgeChangeDirection(int value) 
    {
        if (_edge == null)
            return;
        switch (value) 
        {
            case (int)EdgeDropDown.NonDirected:
                _edge.SetDirection((Direction)EdgeDropDown.NonDirected);
                break;
            case (int)EdgeDropDown.Start:
                _edge.SetDirection((Direction)EdgeDropDown.Start);
                break;
            case (int)EdgeDropDown.End:
                _edge.SetDirection((Direction)EdgeDropDown.End);
                break;
        }

    }
}
