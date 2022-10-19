using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TaskView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _wrongMessageText;
    
    public void ChangeDescription(string value)
    {
        _descriptionText.text = value;
    }
    
    public void ChangeWrongMessage(string value)
    {
        StartTimer();
        _wrongMessageText.text = value;
        StopTimer();
    }

    private IEnumerator TimerWait()
    {
        yield return new WaitForSecondsRealtime(3);
        _wrongMessageText.text = " ";
    }

    private void StartTimer() => StartCoroutine(TimerWait());
    private void StopTimer() => StopCoroutine(TimerWait());
}
