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

    public Action<string> OnTaskComplete;
    
    private void Start()
    {
        GetTask();
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
               GetTask();
                return;
            }
            else
            {
                OnTaskComplete?.Invoke("Конец приложения");
            }
        }
        else
        {
            Debug.Log("Не очень гуд");
        }
    }

    private void GetTask()
    {
        _curreentTask = _container.Tasks[_index];
        OnTaskComplete?.Invoke(_curreentTask.Description);
    }
}
