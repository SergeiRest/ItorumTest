using UnityEngine;
using System;

public abstract class KeyState
{
    protected GameObject _gameObject;
    
    public Action<KeyState> OnStateChanged;
    
    public abstract void Move(Vector3 position);
    public abstract void ChangeState();
}
