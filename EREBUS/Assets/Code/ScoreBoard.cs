using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public int availableFunds;
    public int healthRemaining;
    public TMP_Text funds;
    public TMP_Text playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        funds.text = availableFunds.ToString();
        playerHealth.text = healthRemaining.ToString();

    }
    public void AddFunds(int coins)
    {
        availableFunds += coins;
    }
    public void RemoveHealth(int damage)
    {
        healthRemaining -= damage;
    }
}
