using UnityEngine;

public enum LampStates
{
    On,
    Off,
    None
}


public class LampColorChanger : MonoBehaviour, ITaskInitializer
{
    [SerializeField] private ToggleActivator _activator;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _activatedMaterial;
    [SerializeField] private Material _deactivatedMaterial;
    [SerializeField] private Material _unactiveMaterial;

    [SerializeField] private LampStates _state;
    [SerializeField] private LampStates _toState;
    [SerializeField] private int _taskIndex;

    private Task _task;
    
    private void Start()
    {
        _activator.ToggleClicked += Change;
        Initialize();
    }

    public void SetDefault()
    {
        _renderer.material = GetMaterial();
    }

    private void Change()
    {
        _state = ChangeState();
        _renderer.material = GetMaterial();
        if (_state == _toState)
        {
            _task?.OnTaskComplete(_task, true, null);
        }
        else
        {
            _task?.OnTaskComplete(_task, false, null);
        }
    }

    private Material GetMaterial()
    {
        Material material = null;
        switch (_state)
        {
            case LampStates.On:
                material = _activatedMaterial;
                break;
            case LampStates.Off:
                material = _deactivatedMaterial;
                break;
        }

        return material;
    }

    private LampStates ChangeState()
    {
        LampStates returningState = LampStates.None;
        switch (_state)
        {
            case LampStates.Off:
                returningState = LampStates.On;
                break;
            case LampStates.On:
                returningState = LampStates.Off;
                break;
        }

        return returningState;
    }

    public void Initialize()
    {
        _task = TaskSingleton.Instance.Container.Tasks[_taskIndex];
    }
}
