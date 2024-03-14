using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SelectionSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text test;

    private static PCControls _PCControls;
    private static MobileControl _MobileControl;
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
            _MobileControl = new MobileControl();
            test.text = "Mobile";
        }   
        else
        {
            test.text = "PC";
            _isMobile = false;
            _PCControls = new PCControls();
        }

    }
    private void Start()
    {
        AllEvents.OnDeselect.AddListener(OnDeselect);
        if (_isMobile)
        {

        }
        else
        {
            _PCControls.Mouse.Click.started += _ => StartedClick();
            _PCControls.Mouse.Click.performed += _ => EndedClick();
            _PCControls.KeyBoard.Escape.performed += _ => Exit();
        }

    }
    //бпелеммн рср
    private void Exit()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        if (_isMobile)
            _MobileControl.Enable();
        else
            _PCControls.Enable();
    }
    private void OnDisable()
    {
        if (_isMobile)
            _MobileControl.Disable();
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
            else
            {
                //Debug.Log("You find a bug in selection system, sir!");
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