using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputCoords : MonoBehaviour, IPointerClickHandler
{
    private static Vector3 Coords = Vector3.zero;
    public static Vector3 GetCoords() => Coords;

    public void OnPointerClick(PointerEventData eventData)
    {        
        Coords = Camera.main.ScreenToWorldPoint(eventData.position);
        Tools.to2D(ref Coords);
        AllEvents.OnCoordinatesSelect.Invoke(Coords);
    }
}
