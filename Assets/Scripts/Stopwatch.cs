using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private float _seconds;
    [SerializeField] private TextMeshProUGUI _timeText;
    void Update()
    {
        _seconds = Time.time;
        _timeText.text = _seconds.ToString();
    }
}
