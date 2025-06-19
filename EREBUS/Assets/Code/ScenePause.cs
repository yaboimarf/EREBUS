using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePause : MonoBehaviour
{
    public GameObject unPauseButton;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        unPauseButton.SetActive(false);
    }
}
