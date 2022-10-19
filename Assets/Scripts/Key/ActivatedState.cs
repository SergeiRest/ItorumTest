using System;
using UnityEngine;

public class ActivatedState : KeyState
{
    public ActivatedState(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public override void Move(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public override void ChangeState()
    {
        throw new System.NotImplementedException();
    }
}
