using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject EscapeMenuCanvas;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(!EscapeMenuCanvas.activeSelf)
            {
                EscapeMenuCanvas.SetActive(true);
                Time.timeScale = 0;
            } else
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        EscapeMenuCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void BackToMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("Main Menu");
    }
}
