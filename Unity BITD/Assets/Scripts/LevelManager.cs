using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {
    private const int MaxFear = 100;
    public static float FearLevel;
    public static float TimerLevel;
    public GameObject BearGameObject;
    public static Text FearLevelText;
    public static Text LevelTimerText;
    public static Text HighscoreText;
    public int Money;
    public float TimerBear;
    private GameObject cameraGameObject;
    private Vector3 cameraStartingPosition;
    private bool isLightOn;
    private float journeyLength;
    private float newx, newy;
    private float timerToShake;
    public static bool isGameOver = false;
    public static bool isGameStarted = false;
    public GameObject gameOverObject;
    public bool isGameOverCreated = false;
    public GameObject[] MusicToPlay;
    public GameObject BackgroundMusic;
    public GameObject MenuMusic;
    public GameObject cloneMenuMusic;

    // Use this for initialization
    private void Start() {
        //HighscoreText.text = .ToString();
        isGameOver = false;
        isGameStarted = false;
        isGameOverCreated = false;
        cloneMenuMusic = (GameObject) Instantiate(MenuMusic);
        FearLevel = 0;
        Money = 0;
        TimerLevel = 0f;
        TimerBear = 5f;
        timerToShake = 0f;
        cameraGameObject = GameObject.FindGameObjectWithTag("MainCamera");
        cameraStartingPosition = cameraGameObject.transform.position;
    }

    // Update is called once per frame
    private void Update() {
        if (isGameStarted && !isGameOver)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("UI")) {
                if (obj.name == "Highscore") HighscoreText = obj.GetComponent<Text>();
                if (obj.name == "Level Timer") LevelTimerText = obj.GetComponent<Text>();
                if (obj.name == "FearLevel") FearLevelText = obj.GetComponent<Text>();
            }
            TimerLevel += Time.deltaTime;
            TimerBear -= Time.deltaTime;
            timerToShake += Time.deltaTime;


            if (TimerBear < 0f) {
                Instantiate(BearGameObject);
                TimerBear = Random.Range(5f, 10f)/((15 + Convert.ToInt32(TimerLevel))/15);
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


            //Управление страхом
            isLightOn = GameObject.FindGameObjectWithTag("Light").GetComponent<LightScript>().isOn;
            if (isLightOn) {
                FearLevel -= Time.deltaTime*15f;
            }
            else {
                FearLevel += Time.deltaTime*10f;
            }
            if (FearLevel >= MaxFear) FearLevel = MaxFear;
            if (FearLevel <= 0) FearLevel = 0;
            FearLevelText.text = "Fear level: " + Convert.ToInt32(FearLevel) + "%";
            if (timerToShake > 1/(FearLevel + 0.1f)) {
                timerToShake = 0f;
                newx = cameraStartingPosition.x + FearLevel/1000*Random.Range(FearLevel/-2f, FearLevel/2f);
                newy = cameraStartingPosition.y + FearLevel/1000*Random.Range(FearLevel/-2f, FearLevel/2f);
                journeyLength = Vector3.Distance(transform.position, new Vector3(newx, newy, cameraStartingPosition.z));
            }
            float distCovered = (Time.deltaTime)*(journeyLength/0.05f);
            float fracJourney = distCovered/journeyLength;
            cameraGameObject.transform.position = Vector3.Lerp(transform.position,
                new Vector3(newx, newy, cameraStartingPosition.z),
                fracJourney);
        }

        //Вызов геймовера
            if (isGameOver) {
                if (Input.GetMouseButtonDown(0)) Application.LoadLevel("Test");
                if (!isGameOverCreated) {
                    
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
        isGameStarted = true;
    }
}