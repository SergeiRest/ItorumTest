using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TaskSingleton : Singleton<TaskSingleton>
{
    [SerializeField] private TaskContainer _container;

    private Task _curreentTask;
    private int _index = 0;

    public TaskContainer Container => _container;

    private void Start()
    {
        _curreentTask = _container.Tasks[_index];
        foreach (Task task in _container.Tasks)
        {
            task.OnTaskComplete += TryComplete;
        }
    }

    private void TryComplete(Task task, bool isCorrect, Action callback)
    {
        if (_curreentTask == task)
        {
            Debug.Log("Всё гуд");
            callback?.Invoke();
            _index++;
            if (_index < _container.Tasks.Length)
            {
                _curreentTask = _container.Tasks[_index];
            }
        }
        else
        {
            Debug.Log("Не очень гуд");
        }
    }
}
