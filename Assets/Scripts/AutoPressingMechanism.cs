using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPressingMechanism : MonoBehaviour, ITaskInitializer
{
    private Task _task;

    private void Start()
    {
        Initialize();
    }

    private void OnMouseDown()
    {
        _task.OnTaskComplete?.Invoke(_task, true, null);
    }

    public void Initialize()
    {
        _task = TaskSingleton.Instance.Container.Tasks[5];
    }
}
