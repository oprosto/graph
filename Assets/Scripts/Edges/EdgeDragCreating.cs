using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeFactory))]
public class EdgeDragCreating : MonoBehaviour
{    
    private static PCControls _PCControls;
    private static MobileControls _mobileControl;
    private static Camera _mainCamera = null;
    private static LineRenderer _lineRenderer = null;
    private static EdgeFactory _edgeFactory = null;

    private static Vertex _from;

    private static bool _isEdgeCreate = false;

    private bool _isMobile;

    private void Awake()
    {
        _edgeFactory = GetComponent<EdgeFactory>();
        _lineRenderer = GetComponent<LineRenderer>();
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
        //_controls.Mouse.Click.performed += _ => EndedClick();
        if (_isMobile)
        {
            _mobileControl.Touch.TouchPress.started += _ => MobileEdgeCreateStart();
            _mobileControl.Touch.TouchPress.canceled += _ => MobileEdgeCreateEnd();
        }
        else
        {
            _PCControls.Mouse.Click.started += _ => StartedClick();
            _PCControls.KeyBoard.Control.started += _ => EdgeCreateStart();
            _PCControls.KeyBoard.Control.performed += _ => EdgeCreateEnd();
        }

    }
    private void MobileEdgeCreateEnd()
    {
        Vertex to = DetectVertex(_mobileControl.Touch.TouchPosition.ReadValue<Vector2>());
        if (to != null) 
        {
            _edgeFactory.Create(_from, to);
            _from = to;
        }
        else 
        {
            _from = null;
        }

        _isEdgeCreate = false;
        _lineRenderer.enabled = false;
    }

    private void MobileEdgeCreateStart()
    {
        _from = DetectVertex(_mobileControl.Touch.TouchPosition.ReadValue<Vector2>());
        if (_from != null) 
        {
            _isEdgeCreate = true;
            _lineRenderer.enabled = true;
        }
    }

    private void StartedClick()
    {
        if (_isEdgeCreate)
        {
            Vertex to = DetectVertex(Input.mousePosition);
            if (to != null)
            {
                _edgeFactory.Create(_from, to);
                _from = to;
            }
            else 
            {
                _isEdgeCreate = false;
                _lineRenderer.enabled = false;
                _from = null;
            }

        }
        else
            _from = DetectVertex(Input.mousePosition);
    }
    private void EndedClick()
    {
        
        
    }
    private void EdgeCreateStart()
    {
        if (_from != null)
        {
            _isEdgeCreate = true;
            _lineRenderer.enabled = true;
        }
    }

    private void EdgeCreateEnd()
    {
        _isEdgeCreate = true;
        _lineRenderer.enabled = false;
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

    private static Vertex DetectVertex(Vector3 clickPosition)
    {
        Ray ray = _mainCamera.ScreenPointToRay(clickPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(clickPosition.x, clickPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent<Vertex>(out Vertex from))
            {
                return from;
            }
        }
        return null;
    }
    private void Update()
    {
        if (_isEdgeCreate)
        {
            _lineRenderer.SetPosition(0, _from.GetPosition());
            Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Tools.to2D(ref mousePos);
            _lineRenderer.SetPosition(1, mousePos);
        }
    }
    
}
