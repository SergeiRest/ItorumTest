using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private void Start()
    {
        TaskSingleton.Instance.OnLose += Reload;
    }

    private void Reload()
    {
        TaskSingleton.Instance.OnLose -= Reload;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
