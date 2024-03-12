using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeFactory))]
public class EdgeDragCreating : MonoBehaviour
{
    /*
    private static PCControls _controls;
    private static Camera _mainCamera = null;
    private static LineRenderer _lineRenderer = null;
    private static EdgeFactory _edgeFactory = null;


    private static Vertex _from; 

    private static bool _isEdgeCreate = false; 

    private void Awake()
    {
        _edgeFactory = GetComponent<EdgeFactory>();
        _lineRenderer = GetComponent<LineRenderer>();
        _mainCamera = Camera.main;
        _controls = new PCControls();
    }
    private void Start()
    {
        _controls.Mouse.Click.started += _ => StartedClick();
        _controls.Mouse.Click.performed += _ => EndedClick();

        _controls.KeyBoard.Control.started += _ => EdgeCreateStart();
        _controls.KeyBoard.Control.performed += _ => EdgeCreateEnd();
    }

    private void EndedClick()
    {
        Vertex to = DetectVertex();
        _edgeFactory.Create(_from, to);
        _from = to;
    }

    private void StartedClick()
    {
        _from = DetectVertex();
        DetectObject();
    }
    private void DetectObject() 
    {
        
    }
    private static Vertex DetectVertex() 
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
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
            _lineRenderer.SetPosition(1, Input.mousePosition);
        }
    }
    private void EdgeCreateEnd()
    {
        _isEdgeCreate = false;
    }

    private void EdgeCreateStart()
    {
        if (_from != null)
        {
            _isEdgeCreate = true;
        }
    }
    */
    
    private static PCControls _controls;
    private static Camera _mainCamera = null;
    private static LineRenderer _lineRenderer = null;
    private static EdgeFactory _edgeFactory = null;

    private static Vertex _from;

    private static bool _isEdgeCreate = false;

    private void Awake()
    {
        _edgeFactory = GetComponent<EdgeFactory>();
        _lineRenderer = GetComponent<LineRenderer>();
        _mainCamera = Camera.main;
        _controls = new PCControls();

    }
    private void Start()
    {
        //_controls.Mouse.Click.performed += _ => EndedClick();
        if (Application.isMobilePlatform)
        {
            Debug.Log("MOBILER");
        }
        else 
        {
            Debug.Log("PC");
        }
        _controls.Mouse.Click.started += _ => StartedClick();
        _controls.KeyBoard.Control.started += _ => EdgeCreateStart();
        _controls.KeyBoard.Control.performed += _ => EdgeCreateEnd();

    }
    private void StartedClick()
    {
        if (_isEdgeCreate)
        {
            Vertex to = DetectVertex();
            if (to != null)
            {
                _edgeFactory.Create(_from, to);
                _from = to;
                to.OnSelect();
            }

        }
        else
            _from = DetectVertex();
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
        _isEdgeCreate = false;
        _lineRenderer.enabled = false;
    }

    private void OnEnable()
    {
        _controls.Enable();
    }
    private void OnDisable()
    {
        _controls.Disable();
    }

    private static Vertex DetectVertex()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
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
