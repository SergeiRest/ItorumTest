using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNC : MonoBehaviour
{
    [SerializeField] private LampColorChanger[] _lamps;

    public void Enable()
    {
        foreach (var lamp in _lamps)
        {
            lamp.SetDefault();
        }
    }
}
