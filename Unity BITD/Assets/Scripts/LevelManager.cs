using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {
    public static float TimerLevel;
    public static Text FearLevelText;
    public static Text LevelTimerText;
    public static Text HighscoreText;
    public static bool isGameOver = false;
    public static bool isGameStarted = false;
    private static bool isRestart;
    private GameObject BackgroundMusic;
    public GameObject BearGameObject;
    public GameObject GamePlayCanvas;
    public GameObject MenuCanvas;
    public GameObject MenuMusic;
    public int Money;
    public GameObject[] MusicToPlay;
    public float TimerBear;
    private GameObject cloneMenuMusic;
    public GameObject gameOverObject;
    public bool isGameOverCreated = false;
    private float timerToRestart;

    // Use this for initialization
    private void Start() {
        isGameOver = false;
        isGameStarted = false;
        isGameOverCreated = false;
        cloneMenuMusic = (GameObject) Instantiate(MenuMusic);
        Money = 0;
        TimerLevel = 0f;
        TimerBear = 5f;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("UI")) {
            if (obj.name == "Highscore") HighscoreText = obj.GetComponent<Text>();
        }

        string minutes = (Convert.ToInt32(PlayerPrefs.GetFloat("Best time"))/60).ToString();
        string seconds = (Convert.ToInt32(PlayerPrefs.GetFloat("Best time"))%60).ToString();
        if (Convert.ToInt32(minutes) < 10)
            HighscoreText.text = "Best time: 0" + minutes + ":";
        else
            HighscoreText.text = "Best time: " + minutes + ":";
        if (Convert.ToInt32(seconds) < 10)
            HighscoreText.text += "0" + seconds;
        else
            HighscoreText.text += seconds;
        if (isRestart) {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("UI")) {
                GamePlayCanvas.SetActive(true);
                MenuCanvas.SetActive(false);
            }
            StartGame();
            GameObject.FindGameObjectWithTag("Light").GetComponent<LightScript>().PlayAnimation();
        }
    }

    // Update is called once per frame
    private void Update() {
        timerToRestart -= Time.deltaTime;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("UI")) {
            if (obj.name == "Level Timer") LevelTimerText = obj.GetComponent<Text>();
            if (obj.name == "FearLevel") FearLevelText = obj.GetComponent<Text>();
        }

        if (isGameStarted && !isGameOver) {
            TimerLevel += Time.deltaTime;
            TimerBear -= Time.deltaTime;


            if (TimerBear < 0f) {
                Instantiate(BearGameObject);
                TimerBear = Random.Range(5f, 10f)/(Mathf.Log(TimerLevel,4));
            }


            string minutes = (Convert.ToInt32(TimerLevel)/60).ToString();
            string seconds = (Convert.ToInt32(TimerLevel)%60).ToString();
            if (Convert.ToInt32(minutes) < 10)
                LevelTimerText.text = "0" + minutes + ":";
            else
                LevelTimerText.text = minutes + ":";
            if (Convert.ToInt32(seconds) < 10)
                LevelTimerText.text += "0" + seconds;
            else
                LevelTimerText.text += seconds;


        }

        //Вызов геймовера

        if (isGameOver)
        {
            if (timerToRestart < 0f) {
                if (Input.GetMouseButtonDown(0)) {
                    isRestart = true;
                    Application.LoadLevel("MainScene");
                }
                if (Input.GetMouseButtonDown(1)) {
                    isRestart = false;
                    Application.LoadLevel("MainScene");
                }
            }
            if (!isGameOverCreated)
            {
                timerToRestart = 2f;
                Instantiate(gameOverObject);
                isGameOverCreated = true;
                isGameOver = true;
                BackgroundMusic.audio.volume = 0.5f;
                Instantiate(MusicToPlay[2]);
            }
        }
    }

    public void StartGame() {
        Destroy(cloneMenuMusic);
        BackgroundMusic = (GameObject) Instantiate(MusicToPlay[Random.Range(0, 2)]);
        GameObject.FindGameObjectWithTag("Light").GetComponent<Light>().range = 16;
        GameObject.FindGameObjectWithTag("Light").GetComponent<Light>().spotAngle = 100;
        GetComponent<Animator>().Play("CameraAnim");
        GetComponent<Camera>().orthographicSize = 5;
        transform.position= new Vector3(0,0,transform.position.z);
        isGameStarted = true;
    }
	}
