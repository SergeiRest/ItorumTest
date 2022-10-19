using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public enum ClampedButtonStates
{
    Clamped,
    Unclamped
}

public class ClampedButton : MonoBehaviour, ITaskInitializer
{
    private ClampedButtonStates _state = ClampedButtonStates.Unclamped;
    private Task[] _tasks;
    private Task _task;
    private int _taskIndex = 0;

    private void Start()
    {
        Initialize();
    }

    private void OnMouseDown()
    {
        _state = ChangeState();
        if (_state == ClampedButtonStates.Clamped && _taskIndex == 0)
        {
            _task?.OnTaskComplete(_task, true, ChangeTask);
        }
        else if(_state == ClampedButtonStates.Unclamped && _taskIndex == 1)
        {
            _task?.OnTaskComplete(_task, true, null);
        }
        else
        {
            _task?.OnTaskComplete(_task, false, ChangeTask);
        }
    }

    private void ChangeTask()
    {
        _taskIndex++;
        _task = _tasks[_taskIndex];
    }

    private ClampedButtonStates ChangeState()
    {
        if (_state == ClampedButtonStates.Clamped)
            return ClampedButtonStates.Unclamped;
        else
            return ClampedButtonStates.Clamped;
    }

    public void Initialize()
    {
        _tasks = new []{ TaskSingleton.Instance.Container.Tasks[1], TaskSingleton.Instance.Container.Tasks[4] } ;
        _task = _tasks[0];
    }
}
