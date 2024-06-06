using System.IO;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(FileHandlerUI))]
public class FilePanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _save;
    [SerializeField] private GameObject _load;
    [SerializeField] private GameObject _appUI;
    [SerializeField] private TMP_Text _catalog;
    [SerializeField] private TMP_InputField _inputName;
    private static string _name;
    private static FileHandlerUI _FH;

    private void Start()
    {
        _FH = GetComponent<FileHandlerUI>();
    }
    public void ChangeName()
    {
        _name = _inputName.text;
    }
    private  void DisplayCatalog() 
    {
        _catalog.text = "Saved Files\n";
        //string path = Application.persistentDataPath;
        string path = Application.dataPath;
        if (Application.isMobilePlatform)
            path += "/saves";
        else
            path += "/saves";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        string[] filenames = Directory.GetFiles(path);
        foreach (string filename in filenames)
        {
            _catalog.text += filename + '\n';
        }

    }
    public void Cancel() 
    {
        _panel.SetActive(false);
        _appUI.SetActive(true);
        _save.SetActive(false);
        _load.SetActive(false);
    }
    public void OpenSavePanel() 
    {
        DisplayCatalog();
        _appUI.SetActive(false);
        _panel.SetActive(true);
        _load.SetActive(false);
        _save.SetActive(true);
    }
    public void CloseSavePanel()
    {
        //string path = Application.persistentDataPath;
        string path = Application.dataPath;
        if (Application.isMobilePlatform)
            path += $"/saves/{_inputName.text}.json";
        else
            path += $"/saves/{_inputName.text}.json";
        
        _panel.SetActive(false);
        _appUI.SetActive(true);
        _save.SetActive(false);
        _load.SetActive(false);
        _FH.SaveFile(path);
    }
    public  void OpenLoadPanel()
    {
        DisplayCatalog();
        _appUI.SetActive(false);
        _panel.SetActive(true);
        _save.SetActive(false);
        _load.SetActive(true);
    }
    public void CloseLoadPanel()
    {
        //string path = Application.persistentDataPath;
        string path = Application.dataPath;

        if (Application.isMobilePlatform)
            path += $"/saves/{_inputName.text}.json";
        else
            path += $"/saves/{_inputName.text}.json";

        _panel.SetActive(false);
        _appUI.SetActive(true);
        _save.SetActive(false);
        _load.SetActive(false);
        _FH.LoadFile(path);
    }
}
