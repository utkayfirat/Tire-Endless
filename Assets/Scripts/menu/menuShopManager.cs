using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuShopManager : MonoBehaviour
{

    public int currentTireCarIndex;
    public GameObject[] tireModels;
    public menuTireBlueprint[] tires;
    public Button buyButton;
    public Button adsButton;
    public Text levelText;
    public Text adsInformationText;
    public int levelNumberTaken;
    public Button playGame;

    //UI
    public Text currentLevel;

    
    void Start()
    {
        foreach (menuTireBlueprint tire in tires) 
        {
            if (tire.tireLevel == 0)
                tire.isUnlocked = true;
            else
                tire.isUnlocked = PlayerPrefs.GetInt(tire.name, 0)== 0 ? false: true;
        }

        currentTireCarIndex = PlayerPrefs.GetInt("SelectedTire", 0);
        foreach (GameObject tire in tireModels)
            tire.SetActive(false);

        tireModels[currentTireCarIndex].SetActive(true);

        levelNumberTaken = PlayerPrefs.GetInt("levelSystem");
        currentLevel.text = "" + PlayerPrefs.GetInt("levelSystem");
    }


    void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        tireModels[currentTireCarIndex].SetActive(false);

        currentTireCarIndex++;

        if (currentTireCarIndex == tireModels.Length)
            currentTireCarIndex = 0;

        tireModels[currentTireCarIndex].SetActive(true);
        menuTireBlueprint c = tires[currentTireCarIndex];
        if (!c.isUnlocked)
            return;


        PlayerPrefs.SetInt("SelectedTire", currentTireCarIndex);
    }


    public void ChangePrev()
    {
        tireModels[currentTireCarIndex].SetActive(false);

        currentTireCarIndex--;

        if (currentTireCarIndex == -1)
            currentTireCarIndex = tireModels.Length -1;

        tireModels[currentTireCarIndex].SetActive(true);

        menuTireBlueprint c = tires[currentTireCarIndex];
        if (!c.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedTire", currentTireCarIndex);
    }

    public void UnlockTire()
    {
        menuTireBlueprint c = tires[currentTireCarIndex];

        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedCar", currentTireCarIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("coinSystem", PlayerPrefs.GetInt("coinSystem") - c.price);
        SceneManager.LoadScene("Menu");
    }

    private void UpdateUI()
    {
        menuTireBlueprint c = tires[currentTireCarIndex];
        if (c.isUnlocked && levelNumberTaken >= c.tireLevel)
        {

            playGame.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            levelText.gameObject.SetActive(false);


        }
        else
        {
            if(!c.isUnlocked && levelNumberTaken >= c.tireLevel)
            {



                buyButton.gameObject.SetActive(true);
                playGame.gameObject.SetActive(true);
                buyButton.GetComponentInChildren<Text>().text = "Buy -" + c.price;
                if (PlayerPrefs.GetInt("coinSystem") >= c.price)
                {
                    levelText.gameObject.SetActive(false);
                    buyButton.interactable = true;
                    PlayerPrefs.SetInt("SelectedTire", currentTireCarIndex);

                }
                else
                {
                    playGame.gameObject.SetActive(false);
                    buyButton.interactable = false;
                }
            }
            else
            {
                buyButton.interactable = false;
                playGame.gameObject.SetActive(false);

                if (levelNumberTaken >= c.tireLevel)
                {
                    levelText.gameObject.SetActive(false);
                    
                }
                else
                {
                    buyButton.gameObject.SetActive(true);
                    buyButton.GetComponentInChildren<Text>().text = "Buy -" + c.price;
                    levelText.gameObject.SetActive(true);
                    buyButton.interactable = false;
                    levelText.text = c.tireLevel + " level is required";
                }

            }
            
        }
    }
}
