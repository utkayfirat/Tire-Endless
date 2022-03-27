using UnityEngine.UI;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public static int savedTotalCoins = 0;


    void Start()
    {
        if (PlayerPrefs.HasKey("coinSystem"))
        {
            savedTotalCoins = PlayerPrefs.GetInt("coinSystem");
        }

        PlayerManager.totalOfCoins = savedTotalCoins;
         
    }

    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
            PlayerManager.totalOfCoins += 1;
            PlayerPrefs.SetInt("coinSystem", PlayerManager.totalOfCoins);
            Destroy(gameObject);
        }
    }

}
