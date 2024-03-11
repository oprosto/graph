using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, ISelectable
{
    public void OnSelect() 
    {        
        AllEvents.OnDeselect.Invoke();
    }

}
