using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionSystem: MonoBehaviour
{
    private static PCControls _controls;
    private static Camera _mainCamera = null;
    private static GameObject _lastSelected = null;

    public static GameObject GetSelect() => _lastSelected;
    private void Awake() 
    {
        _mainCamera = Camera.main;
        _controls = new PCControls();

    }
    private void Start()
    {
        AllEvents.OnDeselect.AddListener(OnDeselect);
        _controls.Mouse.Click.started += _ => StartedClick();
        _controls.Mouse.Click.performed += _ => EndedClick();
        
    }

    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable() 
    {
        _controls.Disable();
    }
    private void StartedClick() 
    {
        DetectObject();
    }
    private void EndedClick() 
    {

    }
    private void DetectObject() 
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
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
