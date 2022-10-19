using UnityEngine;

public class MovingState : KeyState
{
    private Transform _target;
    
    public MovingState(GameObject gameObject, Transform target)
    {
        _gameObject = gameObject;
        _target = target;
    }

    public override void Move(Vector3 position)
    {
        _gameObject.transform.position = position;
        if ((_gameObject.transform.position - _target.position).sqrMagnitude < 1)
        {
            ChangeState();
        }
    }

    public override void ChangeState()
    {
        OnStateChanged?.Invoke(new RotationState(_gameObject));
    }
}
