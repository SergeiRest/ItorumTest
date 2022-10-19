using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LiveCycleView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tryCountText;
    [SerializeField] private TextMeshProUGUI _timerText;

    public void Show(int tryCount, int seconds)
    {
        _tryCountText.text = $"Количество попыток: {tryCount}";
        _timerText.text = $"Время прохождения: {seconds}";
    }
}
