using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool menuActive;
    public string levelselect;

    // Update is called once per frame
    void Update()
    {
        if(menuActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("ikwerk");
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                menuActive = true;
            }
        }
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        menuActive = false;
    }
    public void ReturnToLevelSelect()
    {
        SceneManager.LoadScene(levelselect);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
