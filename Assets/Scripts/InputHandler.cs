using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private KeyHandler _necessaryObject;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out KeyHandler state))
                {
                    _necessaryObject = state;
                    _necessaryObject.OnStateChanged += DropTarget;
                }
            }
        }
        else if(Input.GetMouseButton(0) && _necessaryObject != null)
        {
            Vector3 position = hit.point;
            position.z = _necessaryObject.transform.position.z;
            _necessaryObject.CurrentState.Move(position);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DropTarget();
        }
    }

    private void DropTarget()
    {
        _necessaryObject = null;
    }
}
