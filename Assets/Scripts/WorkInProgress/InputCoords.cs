using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputCoords : MonoBehaviour, IPointerClickHandler
{
    private static Vector3 _coords = Vector3.zero;
    public static Vector3 GetCoords() => _coords;

    private void Awake()
    {
        AllEvents.OnVertexSelect.AddListener(Clear);
        AllEvents.OnEdgeSelect.AddListener(Clear);
    }
    private void Clear(Edge edge) 
    {
        _coords = Vector3.zero;
    }
    private void Clear(Vertex vertex)
    {
        _coords = Vector3.zero;
    }
    public void OnPointerClick(PointerEventData eventData)
    {        
        _coords = Camera.main.ScreenToWorldPoint(eventData.position);
        Tools.to2D(ref _coords);
        AllEvents.OnCoordinatesSelect.Invoke(_coords);
    }
}
