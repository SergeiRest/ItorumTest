using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiveCyclePresenter : MonoBehaviour
{
    [SerializeField] private LiveCycleView _view;
    [SerializeField] private LiveCycle _model;

    private void Start()
    {
        _model.WinAction += _view.Show;
    }

    private void OnDestroy()
    {
        _model.WinAction -= _view.Show;
    }
}
