using UnityEngine;

public class RotationState : KeyState, ITaskInitializer
{
    private Task _task;
    public RotationState(GameObject gameObject)
    {
        _gameObject = gameObject;
        Initialize();
    }
    
    public override void Move(Vector3 position)
    {
        if ((_gameObject.transform.position - position).sqrMagnitude > 1)
        {
            _gameObject.transform.Rotate(new Vector3(0,0, 90));
            ChangeState();
        }
    }

    public override void ChangeState()
    {
        _task.OnTaskComplete?.Invoke(_task, true, null);
        OnStateChanged?.Invoke(new ActivatedState(_gameObject));
    }

    public void Initialize()
    {
        _task = TaskSingleton.Instance.Container.Tasks[0];
    }
}
