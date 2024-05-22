using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI panel
    private bool isPaused = false;

    private void Start()
    {
        Resume();
    }
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Debug.Log("Game is paused");
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Hide the pause menu and resume the game
        pauseMenuUI.SetActive(false);
        Debug.Log("Game is resumed");
        Time.timeScale = 1f; // Set time scale back to normal
        isPaused = false;
    }

    void Pause()
    {
        // Show the pause menu and pause the game
        pauseMenuUI.SetActive(true);
        Debug.Log("Game is paused");
        Time.timeScale = 0f; // Freeze the game
        isPaused = true;
    }

    public void QuitGame()
    {
        // Handle quitting the game

        Debug.Log("Quitting game...");

        // If we are running in a standalone build of the game
#if UNITY_STANDALONE
        Application.Quit();
#endif

        // If we are running in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
