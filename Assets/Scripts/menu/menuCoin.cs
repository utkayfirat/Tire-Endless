using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class menuCoin : MonoBehaviour
{
    public static int menuCoins;
    public Text desiredCoinText;

    void Start()
    {
        menuCoins = PlayerPrefs.GetInt("coinSystem");
        desiredCoinText.text = "" + menuCoins;
    }

    
    void Update()
    {
        
    }
}
