using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPresenter : MonoBehaviour
{
    [SerializeField] private TaskSingleton _taskModel;
    [SerializeField] private TaskView _taskView;

    private void Awake()
    {
        _taskModel.OnTaskComplete += _taskView.ChangeDescription;
        _taskModel.OnTaskWronged += _taskView.ChangeWrongMessage;
    }

    private void OnDestroy()
    {
        _taskModel.OnTaskComplete -= _taskView.ChangeDescription;
        _taskModel.OnTaskWronged -= _taskView.ChangeWrongMessage;
    }
}
