using UnityEngine;
using TMPro;
using System.Collections;

public class GameTimer : MonoBehaviour
{

    public TMP_InputField timeInputField;
    public TMP_Text timerDisplayText;

    // variable for the timer
    private float gameTime;
    private bool isTimerRunning = false;

    //  encapsulation
    public float GameTime
    {
        get { return gameTime; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Time cannot be negative.");
            }
            else
            {
                gameTime = value;
                UpdateTimerDisplay(); // Update display when time is set
            }
        }
    }

    // Method to be called on Button click
    public void SetGameTime()
    {
        //  parse the time input to float
        if (float.TryParse(timeInputField.text, out float time))
        {
            GameTime = time; // Set the game time from the input field
            if (!isTimerRunning)
            {
                StartCoroutine(StartTimer());
            }
        }
        else
        {
            Debug.Log("Invalid input. Please enter a valid number.");
        }
    }
    private IEnumerator StartTimer()
    {
        isTimerRunning = true;

        while (gameTime > 0)
        {
            UpdateTimerDisplay();
            yield return new WaitForSeconds(1);
            gameTime--;
        }

        // Timer finished
        isTimerRunning = false;
        timerDisplayText.text = "Time's up!";
    }

    // Update the displayed timer
    private void UpdateTimerDisplay()
    {
        if (timerDisplayText != null)
        {
            timerDisplayText.text = "Remaining Time: " + gameTime + " seconds";
        }
    }
}