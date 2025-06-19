using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject startmenu;
    public string level1;
    public string level2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene1()
    {
        SceneManager.LoadScene(level1);
    }
    public void ChangeScene2()
    {
        SceneManager.LoadScene(level2);
    }
    public void OpenMenu()
    {
        menu.SetActive(true);
        startmenu.SetActive(false);        
    }
    public void CloseMenu()
    {
        menu.SetActive(false);
        startmenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("game is gesloten");
    }
}
