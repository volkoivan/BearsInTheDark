using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {
    private const int MaxFear = 100;
    public static float FearLevel;
    public static float TimerLevel;
    public GameObject BearGameObject;
    private Text FearLevelText;
    private Text LevelTimerText;
    public int Money;
    public float TimerBear;
    public GameObject cameraGameObject;
    private Vector3 cameraStartingPosition;
    private bool isLightOn;
    private float journeyLength;
    private float newx, newy;
    private float speed = 1.0f;
    private float startTime;
    private float timerToShake;

    // Use this for initialization
    private void Start() {
        FearLevel = 0;
        Money = 0;
        TimerLevel = 0f;
        TimerBear = 5f;
        timerToShake = 0f;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("UI")) {
            if (obj.name == "Level Timer") LevelTimerText = obj.GetComponent<Text>();
            if (obj.name == "FearLevel") FearLevelText = obj.GetComponent<Text>();
        }
        cameraGameObject = GameObject.FindGameObjectWithTag("MainCamera");
        cameraStartingPosition = cameraGameObject.transform.position;
    }

    // Update is called once per frame
    private void Update() {
        TimerLevel += Time.deltaTime;
        TimerBear -= Time.deltaTime;
        timerToShake += Time.deltaTime;
        if (TimerBear < 0f) {
            Instantiate(BearGameObject);
            TimerBear = 5f;
        }
        string minutes = (Convert.ToInt32(TimerLevel)/60).ToString();
        string seconds = (Convert.ToInt32(TimerLevel)%60).ToString();
        //string miliseconds = (Convert.ToInt32(TimerLevel*100) % 100).ToString();
        if (Convert.ToInt32(minutes) < 10)
            LevelTimerText.text = "0" + minutes + ":";
        else
            LevelTimerText.text = minutes + ":";
        if (Convert.ToInt32(seconds) < 10)
            LevelTimerText.text += "0" + seconds;
        else
            LevelTimerText.text += seconds;
        /*if (Convert.ToInt32(miliseconds) < 10)
            LevelTimerText.text += "0" + miliseconds;
        else
            LevelTimerText.text += miliseconds;*/

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
        if (timerToShake > 1/(FearLevel+0.1f)) {
            timerToShake = 0f;
            newx = cameraStartingPosition.x + FearLevel/1000*Random.Range(FearLevel/-2f, FearLevel/2f);
            newy = cameraStartingPosition.y + FearLevel / 1000 * Random.Range(FearLevel / -2f, FearLevel / 2f);
            startTime = Time.time;
            journeyLength = Vector3.Distance(transform.position, new Vector3(newx, newy, cameraStartingPosition.z));
        }
        float distCovered = (Time.deltaTime)*(journeyLength/0.05f);
        float fracJourney = distCovered/journeyLength;
        cameraGameObject.transform.position = Vector3.Lerp(transform.position, new Vector3 (newx, newy, cameraStartingPosition.z),
            fracJourney);
    }
}