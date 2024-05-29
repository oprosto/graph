using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    private SelectionSystem _selectionSystem;

    private void Awake()
    {
        _selectionSystem = new SelectionSystem();
    }

}
