using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public GameObject pauseMenu;

    private bool isPaused = false;
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1;

        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0;

        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
