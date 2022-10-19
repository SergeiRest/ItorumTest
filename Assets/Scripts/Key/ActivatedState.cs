using System;
using UnityEngine;

public class ActivatedState : KeyState, ITaskInitializer
{
    private Task _task;

    public ActivatedState(GameObject gameObject)
    {
        _gameObject = gameObject;
        Initialize();
    }

    public override void Move(Vector3 position)
    {
        if ((position - _gameObject.transform.position).sqrMagnitude > 3)
        {
            _gameObject.transform.Rotate(new Vector3(0,0, -90));
            ChangeState();
        }
    }

    public override void ChangeState()
    {
        _task.OnTaskComplete?.Invoke(_task, true, null);
        OnStateChanged?.Invoke(new RotationState(_gameObject));
    }

    public void Initialize()
    {
        _task = TaskSingleton.Instance.Container.Tasks[6];
    }
}
