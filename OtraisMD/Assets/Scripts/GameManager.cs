using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player; // Reference to the player
    public GameObject winPanel; // Reference to the win panel (GameObject)
    public GameObject losePanel; // Reference to the lose panel (GameObject)
    public GameObject UIpanel;

    void Start()
    {
        // Ensure the win and lose panels are hidden at the start
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }
    }

    // Call this method when the player dies
    public void HandlePlayerDeath()
    {
        // Show the lose panel
        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }

        // Hide the win panel if it's visible
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        Debug.Log("Game Over! You lost!");
    }

    private void WinGame()
    {
        // Show the win panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            UIpanel.SetActive(false);
        }

        // Hide the lose panel if it's visible
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }

        Debug.Log("You won the game!");
    }
}