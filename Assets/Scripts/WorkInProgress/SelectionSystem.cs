using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionSystem : MonoBehaviour
{

    private static PCControls _PCControls;
    private static MobileControls _mobileControl;
    private static Camera _mainCamera = null;
    private static GameObject _lastSelected = null;
    private static bool _isMobile;
    public static GameObject GetSelect() => _lastSelected;
    
    

    private void Awake()
    {
        _mainCamera = Camera.main;
        if (Application.isMobilePlatform)
        {
            _isMobile = true;
            _mobileControl = new MobileControls();
        }   
        else
        {
            _isMobile = false;
            _PCControls = new PCControls();
        }

    }
    private void Start()
    {
        AllEvents.OnDeselect.AddListener(OnDeselect);
        if (_isMobile)
        {
            _mobileControl.Touch.TouchPress.started += _ => StartTouch();
        }
        else
        {
            _PCControls.Mouse.Click.started += _ => StartedClick();
            _PCControls.Mouse.Click.performed += _ => EndedClick();
            _PCControls.KeyBoard.Escape.performed += _ => Exit();
            _PCControls.KeyBoard.Delete.performed += _ => Delete();
        }
    }
    private void StartTouch()
    {
        DetectObject(_mobileControl.Touch.TouchPosition.ReadValue<Vector2>());
    }

    private void Exit()
    {
        Application.Quit();
    }
    private void Delete() 
    {
        ItemRemover.RemoveItem();
    }
    private void OnEnable()
    {
        if (_isMobile)
            _mobileControl.Enable();
        else
            _PCControls.Enable();
    }
    private void OnDisable()
    {
        if (_isMobile)
            _mobileControl.Disable();
        else
            _PCControls.Disable();
    }
    private void StartedClick()
    {
        DetectObject(Input.mousePosition);
    }
    private void EndedClick()
    {

    }
    private void DetectObject(Vector3 clickPosition)
    {
        Ray ray = _mainCamera.ScreenPointToRay(clickPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(clickPosition.x, clickPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent<ISelectable>(out ISelectable target))
            {
                target.OnSelect();
                _lastSelected = hit.collider.gameObject;
            }
        }
    }
    private void OnDeselect()
    {
        _lastSelected = null;
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}