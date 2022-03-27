using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool stopping;
    public GameObject stopDialog;

    public static bool isGameStarted;
    public GameObject StartingButton;

    public static int numberOfCoins;
    public Text TakenCoin;


    public static int totalOfCoins;
    public Text totalCoin;

    public GameObject panelUst;
    public GameObject panelAlt;

    public Text inGameCoinsText;
    public Text highScoreText;
    public Text inGameScoreText;
    public Text scoreGameOverText;
    public static int scoreNumber; // 0 km def
    public static int highScoreNumber;
    public static int expNumber;
    bool kontrol;


    public Text levelText;
    public static int levelNumber; // 1 def

    public Text coinUI;
    public Button pauseButton;

    public bool camControl;




    void Start()
    {
        gameOver = false;
        kontrol = false;
        stopping = false;
        camControl = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
        totalOfCoins = 0;
        scoreNumber = 0;
        //Test level
        //PlayerPrefs.SetInt("expSystem",1);
        expNumber = PlayerPrefs.GetInt("expSystem");

        Camera.main.transform.position = new Vector3(5.01f, 3.66f,-8.32f);
        Camera.main.transform.rotation = Quaternion.Euler(1f,-22.94f,0f);
        

        highScoreText.text = "" + PlayerPrefs.GetInt("highScoreSystem");

        levelText.text = "" + PlayerPrefs.GetInt("levelSystem", 1);
        coinUI.text = "" + PlayerPrefs.GetInt("coinSystem");

    }


    void Update()
    {
        

        if (stopping == true)// durdurulma var
        {
            Time.timeScale = 0;
            stopDialog.SetActive(true);
        }
        if (stopping == false)// durdurulma yok
        {
            Time.timeScale = 1;
            stopDialog.SetActive(false);

            if (gameOver)
            {
                Time.timeScale = 0;
                scoreGameOverText.text = "" + scoreNumber;
                if(kontrol == false)
                {
                    expNumber = expNumber + highScoreNumber;
                    PlayerPrefs.SetInt("expSystem", expNumber);
                    kontrol = true;
                    Debug.Log(expNumber);
                }
                
                if (scoreNumber > PlayerPrefs.GetInt("highScoreSystem"))
                {
                    PlayerPrefs.SetInt("highScoreSystem", highScoreNumber);
                    highScoreNumber = PlayerPrefs.GetInt("highScoreSystem");
                    highScoreText.text = "" + highScoreNumber;

                }


                if (PlayerPrefs.GetInt("expSystem") <= 100
                    && PlayerPrefs.GetInt("expSystem") >= 0)
                {
                    levelNumber = 1;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 200
                    && PlayerPrefs.GetInt("expSystem") >= 100)
                {
                    levelNumber = 2;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 300
                    && PlayerPrefs.GetInt("expSystem") >= 200)
                {
                    levelNumber = 3;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 400
                    && PlayerPrefs.GetInt("expSystem") >= 300)
                {
                    levelNumber = 4;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);

                }

                if (PlayerPrefs.GetInt("expSystem") <= 500
                    && PlayerPrefs.GetInt("expSystem") >= 400)
                {
                    levelNumber = 5;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 600
                    && PlayerPrefs.GetInt("expSystem") >= 500)
                {
                    levelNumber = 6;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 700
                    && PlayerPrefs.GetInt("expSystem") >= 600)
                {
                    levelNumber = 7;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }


                if (PlayerPrefs.GetInt("expSystem") <= 800
                    && PlayerPrefs.GetInt("expSystem") >= 700)
                {
                    levelNumber = 8;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }


                if (PlayerPrefs.GetInt("expSystem") <= 900
                    && PlayerPrefs.GetInt("expSystem") >= 800)
                {
                    levelNumber = 9;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }


                if (PlayerPrefs.GetInt("expSystem") <= 1000
                    && PlayerPrefs.GetInt("expSystem") >= 900)
                {
                    levelNumber = 10;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 1100
                    && PlayerPrefs.GetInt("expSystem") >= 1000)
                {
                    levelNumber = 11;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 1200
                    && PlayerPrefs.GetInt("expSystem") >= 1100)
                {
                    levelNumber = 12;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 1300
                    && PlayerPrefs.GetInt("expSystem") >= 1200)
                {
                    levelNumber = 13;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") <= 1400
                    && PlayerPrefs.GetInt("expSystem") >= 1300)
                {
                    levelNumber = 14;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }

                if (PlayerPrefs.GetInt("expSystem") >= 1400)
                {
                    levelNumber = 15;
                    levelText.text = "" + levelNumber;
                    PlayerPrefs.SetInt("levelSystem", levelNumber);
                }


                gameOverPanel.SetActive(true);
                Destroy(inGameCoinsText);
                Destroy(inGameScoreText);
                Destroy(pauseButton);

            }

        }

        inGameCoinsText.text = "" + numberOfCoins;
        totalCoin.text = "" + PlayerPrefs.GetInt("coinSystem");
        TakenCoin.text = "" + numberOfCoins;

        if (isGameStarted.Equals(true))
        {
            if (camControl == false)
            {
                Camera.main.transform.position = new Vector3(0f, 7.47f, -8.32f);
                Camera.main.transform.rotation = Quaternion.Euler(16.39f, 0f, 0f);
                camControl = true;
            }

            highScoreNumber = scoreNumber;
            inGameScoreText.text = "" + scoreNumber;
            panelAlt.SetActive(false);
            panelUst.SetActive(false);
            Destroy(StartingButton);

        }


    }

}
