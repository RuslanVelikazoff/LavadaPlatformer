using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI timerText;

    private int minute;
    private float seconds;

    private void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
    }

    private void Update()
    {
        seconds += Time.deltaTime;
        
        if (seconds >= 60)
        {
            seconds -= 60;
            minute++;
        }
        
        SetTimerText();
    }

    private void SetTimerText()
    {
        if (seconds < 10)
        {
            timerText.text = $"{minute}:0{(int)seconds}";
        }
        else
        {
            timerText.text = $"{minute}:{(int)seconds}";
        }
    }

    public string GetTimerString()
    {
        string timerString = timerText.text;
        return timerString;
    }
}
