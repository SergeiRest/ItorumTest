using System;
using UnityEngine;

public class ToggleActivator : MonoBehaviour
{
    public Action ToggleClicked;
    private void OnMouseDown()
    {
        Debug.Log("ЛУпа теперь без пупы");
        ToggleClicked?.Invoke();
    }
}
