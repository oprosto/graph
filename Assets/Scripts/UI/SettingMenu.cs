using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private GameObject LoadButton, SaveButton;
    private bool isEnable = false;
    public void StateChanged() 
    {
        if (isEnable)
            TurnOff();
        else
            TurnOn();
    
        isEnable = !isEnable;
        
    }
    private void TurnOn() 
    {

        LoadButton.gameObject.SetActive(true);
        SaveButton.gameObject.SetActive(true);
    } 
    private void TurnOff()
    {
        LoadButton.gameObject.SetActive(false);
        SaveButton.gameObject.SetActive(false);
    }
}
