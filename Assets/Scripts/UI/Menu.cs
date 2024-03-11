using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject CreateVertexButton, CreateVertexSubMenu, ValuesButton, ValuesSubMenu;
    public void ValuesMenuEnabled()
    {

        CreateVertexButton.SetActive(true);
        CreateVertexSubMenu.SetActive(false);
        ValuesButton.SetActive(false);
        ValuesSubMenu.SetActive(true);
    }
    public void VertexMenuEnabled()
    {
        CreateVertexButton.SetActive(false);
        CreateVertexSubMenu.SetActive(true);
        ValuesButton.SetActive(true);
        ValuesSubMenu.SetActive(false);
    }
}
