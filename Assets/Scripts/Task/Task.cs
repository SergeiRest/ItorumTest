using System;
using System.Threading;
using UnityEngine;

[System.Serializable]
public class Task
{
    [SerializeField] string _decription;

    public Action<Task, bool, Action> OnTaskComplete;

    public string Description => _decription;
}
