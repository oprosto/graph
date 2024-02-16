using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AllEvents.OnBackgroundClick.Invoke();
    }

}
