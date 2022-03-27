using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlAds : MonoBehaviour
{
    public Button adsButton;

     void Start()
    {
       if(PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            adsButton.gameObject.SetActive(false);
            GameObject.Find("ADS").SetActive(false);

        }
        else if(PlayerPrefs.GetInt("RemoveAds") == 0)
        {
            adsButton.gameObject.SetActive(true);
        }
    }

    public void deleteAds()
    {
        adsButton.gameObject.SetActive(false);
    }


    public void moneyMarket()
    {
        SceneManager.LoadScene("MoneyMarket");
    }

}
