using UnityEngine;

public class RotationState : KeyState
{
    public RotationState(GameObject gameObject)
    {
        _gameObject = gameObject;
    }
    
    public override void Move(Vector3 position)
    {
        if ((_gameObject.transform.position - position).sqrMagnitude > 3)
        {
            _gameObject.transform.Rotate(new Vector3(0,0, 90));
            ChangeState();
        }
    }

    public override void ChangeState()
    {
        OnStateChanged?.Invoke(new ActivatedState(_gameObject));
    }
}
