using UnityEngine;
using TMPro;

public class TaskView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void ChangeDescription(string value)
    {
        descriptionText.text = value;
    }
}
