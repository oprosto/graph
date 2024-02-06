using TMPro;
using UnityEngine;

public class InputCoords : MonoBehaviour
{
    [SerializeField] TMP_Text CoordsText;
    [SerializeField] GameObject CoordsPoint;

    private static bool isUsed = false;
    private static Vector3 Coords = Vector3.zero;
    public static Vector3 GetCoords() => Coords;

    public static void GetCords() 
    {
        isUsed = true;
    }

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

    private void DisplayCurrentCords() 
    {
        CoordsPoint.transform.position = Coords;
        //Temp
        string temp;
        temp = "X: " + Coords.x.ToString() + " Y: " + Coords.y.ToString();
        CoordsText.text = temp;
    }
}
