using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputCoords : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField] TMP_Text CoordsText;

    //private static bool isUsed = false;
    private static Vector3 Coords = Vector3.zero;
    public static Vector3 GetCoords() => Coords;

    Vertex vertex;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        Coords = Camera.main.ScreenToWorldPoint(eventData.position);
        //Vector3 coolNewWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Tools.to2D(ref Coords);
        AllEvents.OnCoordinatesSelect.Invoke(Coords);

    }
    /*
    public static void GetCords() 
    {
        isUsed = true;
    }
    */
    /*
    private void Update()
    {
        if (isUsed)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                Coords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Tools.to2D(ref Coords);
                DisplayCurrentCords();
                isUsed = false;
            }
        }
    }
    */
    /*
    private void DisplayCurrentCords() 
    {
        //CoordinatesMarker.transform.position = Coords;
        //Temp
        string temp;
        temp = "X: " + Coords.x.ToString() + " Y: " + Coords.y.ToString();
        CoordsText.text = temp;
    }
    */
}
