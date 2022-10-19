using System;
using UnityEngine;

public class ToggleActivator : MonoBehaviour
{
    public Action ToggleClicked;
    private void OnMouseDown()
    {
        ToggleClicked?.Invoke();
    }
}
