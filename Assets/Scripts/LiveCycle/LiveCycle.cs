using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiveCycle : MonoBehaviour
{
    private const string TRY_COUNT_KEY = "TryCount";
    private const string ALL_TIME_KEY = "AllTime";
    
    private DateTime _time;
    private int _tryCount;
    private int _seconds;

    public Action<int, int> WinAction;
    
    private void Start()
    {
        Load();
        _time = DateTime.Now;
        TaskSingleton.Instance.OnWin += OnWin;
        TaskSingleton.Instance.OnLose += OnDie;
    }

    private void OnDestroy()
    {
        TaskSingleton.Instance.OnWin -= OnWin;
        TaskSingleton.Instance.OnLose -= OnDie;

    }

    private void OnWin()
    {
        _tryCount++;
        DateTime tempTime = DateTime.Now;
        int liveValue =  (int)(_seconds + (tempTime - _time).TotalSeconds);
        WinAction?.Invoke(_tryCount, liveValue);
        _tryCount = 0;
        _seconds = 0;
        Save();
    }

    private void OnDie()
    {
        _tryCount++;
        _seconds +=  (int)(DateTime.Now - _time).TotalSeconds;
        Save();
    }

    private void Load()
    {
        _seconds = PlayerPrefs.GetInt(ALL_TIME_KEY, 0);
        _tryCount = PlayerPrefs.GetInt(TRY_COUNT_KEY, 0);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(TRY_COUNT_KEY, _tryCount);
        PlayerPrefs.SetInt(ALL_TIME_KEY, _seconds);
    }
}
