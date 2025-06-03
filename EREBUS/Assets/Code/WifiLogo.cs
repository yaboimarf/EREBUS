using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class WifiLogo : MonoBehaviour
{
    public float timer;
    public float reAper;
    public GameObject wifiFull;
    public GameObject wifiMid;
    public GameObject wifiLow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 )
        {
            timer = reAper;
            wifiMid.SetActive(true);
            wifiFull.SetActive(true);
            wifiLow.SetActive(true);
        }
        if ( timer < 2 )
        {
            wifiMid.SetActive( false );
        }
        if (timer >2 && timer <4)
        {
            wifiFull.SetActive( false );
        }
        
    }
}
