using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject DeathMenuCanvas;

    public void ResumeGame()
    {
        DeathMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void BackToMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("Main Menu");
    }
}
