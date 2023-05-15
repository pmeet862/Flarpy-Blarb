using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LogicScript : MonoBehaviour
{
    private int playerScore;

    private int heighScore;
    public static bool isPaused;

    public Text scoreText;
    public AudioSource dingSFX;
    private AudioSource bgSFX;
    public float moveSpeed = 12;
    public float speedToIncrease = 2;
    public float maxSpeed = 20;

    public float timer1 = 0;


    //After this interval of time the game difficulty increases
    public float timeInterval = 60;
    public float spawnInterval = 2.2f;
    public float spawnRateIncreaser = 0.2f;
    public float minSpawnIterval = 1;
    private int timeLeft;

    //For backgrounf SFX toggle
    private string toggleState;

    //For ding SFX toggle
    private string toggleState1;

    public Text highScoreText;
    public Text countdownDisplay;

    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public GameObject pauseBTN;

    public GameObject countDown;
    private GameObject backgroundSound;
    private BirdScript bird;



    private void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();

        if (BGSoundScript.instance)
        {
            backgroundSound = GameObject.FindGameObjectWithTag("BGSound");
        }
        isPaused = true;
        pauseBTN.SetActive(false);
        StartCoroutine(resumeGame(3));
    }
    void Start()
    {

        heighScore = PlayerPrefs.GetInt("heighScore");
        toggleState = PlayerPrefs.GetString("toggleState");
        toggleState1 = PlayerPrefs.GetString("toggleState1");

        if (backgroundSound)
        {


            bgSFX = backgroundSound.GetComponent<AudioSource>();
            if (bool.Parse(toggleState) == false)
            {
                bgSFX.mute = true;
            }
            else
            {
                bgSFX.mute = false;
            }

        }

    }
    void Update()
    {

        highScoreText.text = "Heigh Score: " + PlayerPrefs.GetInt("heighScore").ToString();

        if (isPaused == false && moveSpeed <= maxSpeed && spawnInterval >= minSpawnIterval)
        {

            if (timer1 < timeInterval)
            {
                timer1 = timer1 + Time.deltaTime;
            }
            else
            {
                moveSpeed = moveSpeed + speedToIncrease;
                spawnInterval = spawnInterval - spawnRateIncreaser;
                timer1 = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape) && bird.birdIsAlive == true)
        {
            if (isPaused)
            {
                StartCoroutine(resumeGame(3));
            }
            else
            {
                pauseGame();
            }

        }




    }
    //Use for adding score
    //ContexMenu is used for calling the function below it from editor
    // [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (bool.Parse(toggleState1) == true)
        {

            dingSFX.Play();
        }
    }

    //use for resume btn click
    public void OnResumeClick()
    {
        StartCoroutine(resumeGame(3));
    }


    //Use for pause the game 
    public void pauseGame()
    {
        pauseMenuScreen.SetActive(true);
        isPaused = true;
        pauseBTN.SetActive(false);
    }

    //Use for resume the game 
    IEnumerator resumeGame(int timeLeft)
    {
        pauseMenuScreen.SetActive(false);
        countDown.SetActive(true);
        while (timeLeft > 0)
        {
            countdownDisplay.text = timeLeft.ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }
        countdownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        isPaused = false;
        pauseBTN.SetActive(true);

    }

    //Use for restart the game 
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Use for to change scene to title screen    
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Use for to load gameover screen
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        pauseBTN.SetActive(false);
        pauseMenuScreen.SetActive(false);

        if (playerScore > heighScore)
        {
            heighScore = playerScore;
            PlayerPrefs.SetInt("heighScore", playerScore);

        }
    }


}
