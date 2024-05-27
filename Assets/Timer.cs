using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Reference to the Text component for displaying the timer

    private float elapsedTime; // Time elapsed since the timer started
    private bool isRunning = true; // Controls whether the timer is running

    void Start()
    {
        elapsedTime = 0f;
        UpdateTimerText();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime; // Increment elapsed time
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime - minutes * 60);
        string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = "Timer: " + formattedTime;
    }

    // Optional: Method to stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Optional: Method to start the timer
    public void StartTimer()
    {
        isRunning = true;
    }

    // Optional: Method to reset the timer
    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerText();
    }
}
