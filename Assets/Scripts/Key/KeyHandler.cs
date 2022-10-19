using System;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _main;
    private KeyState _currentState;

    public KeyState CurrentState => _currentState;
    public Action OnStateChanged;

    private void Awake()
    {
        _currentState = new MovingState(_main, _target);
        _currentState.OnStateChanged += LupaPupa;
    }

    private void LupaPupa(KeyState state)
    {
        OnStateChanged?.Invoke();
        _currentState = state;
        _currentState.OnStateChanged += LupaPupa;
    }
}
