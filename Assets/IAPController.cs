using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IAPController : MonoBehaviour,IStoreListener
{
    IStoreController controller;

    public string[] product;

    public int currentCoins;
    public bool delete = true;

    private void Start()
    {
        if (delete)
            PlayerPrefs.DeleteAll();
        
        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            GameObject.Find("removeAdsbuy").GetComponent<Button>().interactable = false;
            GameObject.Find("AdsButton").SetActive(false);
        }

        currentCoins = PlayerPrefs.GetInt("coinSystem");

        IAPStart();
        

    }

    private void IAPStart()
    {
        var module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        foreach(string item in product)
        {
            builder.AddProduct(item, ProductType.Consumable);
        }
        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Error" + error.ToString());
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Error while buying " + failureReason.ToString());
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        if (string.Equals(purchaseEvent.purchasedProduct.definition.id,product[0],StringComparison.Ordinal))
        {
            AddCoin(2000);
            return PurchaseProcessingResult.Complete;
        }


        else if (string.Equals(purchaseEvent.purchasedProduct.definition.id, product[1], StringComparison.Ordinal))
        {
            AddCoin(4000);
            return PurchaseProcessingResult.Complete;
        }


        else if (string.Equals(purchaseEvent.purchasedProduct.definition.id, product[2], StringComparison.Ordinal))
        {
            AddCoin(6000);
            return PurchaseProcessingResult.Complete;
        }


        //ads buy
        else if (string.Equals(purchaseEvent.purchasedProduct.definition.id, product[3], StringComparison.Ordinal))
        {
            RemoveAds(10000);
            return PurchaseProcessingResult.Complete;
        }
        else
        {
            return PurchaseProcessingResult.Pending;
        }

    }

    private void AddCoin(int coin)
    {
        currentCoins = currentCoins + coin;
        PlayerPrefs.SetInt("coinSystem", currentCoins);
    }

    private void RemoveAds(int coin)
    {
        currentCoins = currentCoins + coin;
        PlayerPrefs.SetInt("coinSystem", currentCoins);
        PlayerPrefs.SetInt("RemoveAds", 1);
    }

    public void IAPButton(string id)
    {
        //coin_2000
        //coin_4000
        //coin_6000
        //removeads_1

        Product proc = controller.products.WithID(id);
        if(proc != null && proc.availableToPurchase)
        {
            Debug.Log("Buying");
            controller.InitiatePurchase(proc);
            SceneManager.LoadScene("MoneyMarket");
        }
        else
        {
            Debug.Log("Not Buying");
        }

    }


}
