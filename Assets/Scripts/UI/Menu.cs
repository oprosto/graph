using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] TMP_Text _vertexName, _vertexValue;
    [SerializeField] Toggle _vertexValueToggle, _vertexNameToggle;
    //Edges
    [SerializeField] TMP_Text _edgeValue;
    [SerializeField] Toggle _edgeValueToggle;
    //[SerializeField] Dropdown _edgeDropDown;
    //Current selected
    private Vertex _vertex = null;
    private Edge _edge = null;
    private void Awake()
    {
        AllEvents.OnVertexSelect.AddListener(DisplayVertexexUI);
        AllEvents.OnEdgeSelect.AddListener(DisplayEdgesUI);
    }
    private void DisplayVertexexUI(Vertex vertex) 
    {
        _nameInfo.text = vertex.GetName();
        _valueInfo.text = vertex.GetValue().ToString();
        _vertexFactory.SetActive(true);
        _edgeFactory.SetActive(false);
        _vertex = vertex;
        _edge = null;
    }
    private void DisplayEdgesUI(Edge edge)
    {
        _valueInfo.text = edge.GetValue().ToString();
        _vertexFactory.SetActive(false);
        _edgeFactory.SetActive(true);
        _vertex = null;
        _edge = edge;
    }
    public void Clear() 
    {
        _vertexName.text = string.Empty;
        _vertexValue.text = string.Empty;
        _edgeValue.text = string.Empty;
    }
    public void OnVertexNameChanged() 
    {
        if (_vertex != null)
            AllEvents.OnVertexNameChanged.Invoke(_vertex, _vertexName.text);
    }
    public void OnVertexValueChanged() 
    {
        if (_vertex != null)
            return;
        double value;
        if (double.TryParse(_vertexValue.text[..^1], out value))
            AllEvents.OnVertexValueChanged.Invoke(_vertex, value);
        else
            Debug.Log("Wrong input");
        
    }
    public void OnEdgeValueChanged() 
    {
        if (_edge == null)
            return;
        double value;
        if (double.TryParse(_edgeValue.text[..^1], out value))
            AllEvents.OnEdgeValueChanged.Invoke(_edge, value);
        else
            Debug.Log("Wrong input");
        
            
    }
    public void OnVertexDisplayNameChangeState() 
    {
        if (_vertex == null)
            return;
        if (_vertexNameToggle.isOn)
            _vertex.gameObject.GetComponentInChildren<GameObject>().SetActive(true);
        else
            _vertex.gameObject.GetComponentInChildren<GameObject>().SetActive(false);
    }
    public void OnVertexDisplayValueChangeState()
    {
        /*Пока такого немае*/
    }
    public void OnEdgeDisplayValueChangeState()
    {
        if (_edge == null)
            return;
        if (_edgeValueToggle.isOn)
            _edge.gameObject.GetComponent<GameObject>().SetActive(true);
        else
            _edge.gameObject.GetComponent<GameObject>().SetActive(false);
    }
    public void OnEdgeChangeDirection(int value) 
    {
        if (_edge == null)
            return;
        switch (value) 
        {
            case (int)EdgeDropDown.NonDirected:
                _edge.SetDirection((byte)EdgeDropDown.NonDirected);
                break;
            case (int)EdgeDropDown.Start:
                _edge.SetDirection((byte)EdgeDropDown.Start);
                break;
            case (int)EdgeDropDown.End:
                _edge.SetDirection((byte)EdgeDropDown.End);
                break;
        }

    }
}
