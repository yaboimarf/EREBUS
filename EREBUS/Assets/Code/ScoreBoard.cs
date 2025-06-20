using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Security;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public int availableFunds;
    public int healthRemaining;
    public TMP_Text funds;
    public TMP_Text playerHealth;
    public GameObject loseScreen;
    public string sceneChange;
    public AudioSource baseHit;
    // Update is called once per frame
    void Update()
    {
        funds.text = availableFunds.ToString();
        playerHealth.text = healthRemaining.ToString();
        if(healthRemaining <= 0)
        {
            GameOverScreen();
        }
    }
    public void AddFunds(int coins)
    {
        availableFunds += coins;
    }
    public void RemoveHealth(int damage)
    {
        baseHit.Play();
        healthRemaining -= damage;
    }
    public void GameOverScreen()
    {
        Time.timeScale = 0;
        loseScreen.SetActive(true);
    }
    public void GameOverScreenButton()
    {
        SceneManager.LoadScene(sceneChange);
    }
}
