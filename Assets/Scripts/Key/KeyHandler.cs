using System;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _main;
    [SerializeField] private CNC _cnc;
    private KeyState _currentState;

    public KeyState CurrentState => _currentState;
    public Action OnStateChanged;

    private void Awake()
    {
        _currentState = new MovingState(_main, _target);
        _currentState.OnStateChanged += ChangeState;
    }

    private void ChangeState(KeyState state)
    {
        _currentState.OnStateChanged -= ChangeState;
        OnStateChanged?.Invoke();
        _currentState = state;
        _currentState.OnStateChanged += ChangeState;
        if (state is ActivatedState)
        {
            _cnc.Enable();
        }
    }
}
