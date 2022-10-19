using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TaslContainer", menuName = "Data")]
public class TaskContainer : ScriptableObject
{
    [SerializeField] private Task[] _tasks;

    public Task[] Tasks => _tasks;
}
