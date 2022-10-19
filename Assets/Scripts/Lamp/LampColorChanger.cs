using UnityEngine;

public enum LampStates
{
    On,
    Off,
    Disable
}


public class LampColorChanger : MonoBehaviour
{
    [SerializeField] private ToggleActivator _activator;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _activatedMaterial;
    [SerializeField] private Material _deactivatedMaterial;
    [SerializeField] private Material _unactiveMaterial;

    private LampStates _state = LampStates.Disable;
    
    private void Awake()
    {
        _activator.ToggleClicked += Change;
    }

    private void Change()
    {
        Debug.Log("Лупа снова с пупой");
    }
}
