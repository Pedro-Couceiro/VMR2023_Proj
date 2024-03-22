using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [Header("Module")] public TextMeshProUGUI timerText;
    [Header("Timer Settings")]
    [SerializeField] float _currentTime;
    [SerializeField] float _startTime = 0f; //Useless for now
    [SerializeField] private bool _isCountdown = false;
    
    // Update is called once per frame
    void Update()
    {
        _currentTime = _isCountdown ? _currentTime -= Time.deltaTime : _currentTime += Time.deltaTime;
        timerText.text = _currentTime.ToString("F2");
    }
}
