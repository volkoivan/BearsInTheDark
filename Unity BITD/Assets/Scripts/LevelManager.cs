using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Windows.Forms;

public class LevelManager : MonoBehaviour {
    private const int MaxFear = 100;
    public static float FearLevel;
    public int Money;
    public static float TimerLevel;
    public float TimerBear;
    public GameObject BearGameObject;
    private Text LevelTimerText;
    private Text FearLevelText;
    private bool isLightOn;

    // Use this for initialization
    private void Start() {
        FearLevel = 0;
        Money = 0;
        TimerLevel = 0f;
<<<<<<< HEAD
        TimerBear = 5f;
        foreach (var obj in GameObject.FindGameObjectsWithTag("UI")) {
            if (obj.name == "Level Timer") LevelTimerText = obj.GetComponent<Text>();
            if (obj.name == "FearLevel") FearLevelText = obj.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    private void Update() {
        TimerLevel += Time.deltaTime;
        TimerBear -= Time.deltaTime;
        if (TimerBear < 0f) {
            Instantiate(BearGameObject);
            TimerBear = 5f;
=======
	    TimerBear = 0f;
	    foreach (var obj in GameObject.FindGameObjectsWithTag("UI")) {
            if (obj.name == "Level Timer") LevelTimerText = obj.GetComponent<Text>();
	    }
	}
	
	// Update is called once per frame
	void Update () {

	    TimerLevel += Time.deltaTime;
	    TimerBear -= Time.deltaTime;
	    if (TimerBear < 0f) {
	        Instantiate(BearGameObject);
	        TimerBear = 5f;
>>>>>>> origin/master
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
            FearLevel -= Time.deltaTime*10f;
        }
        else {
            FearLevel += Time.deltaTime*5f;
        }
        if (FearLevel >= MaxFear) FearLevel = MaxFear;
        if (FearLevel <= 0) FearLevel = 0;
        FearLevelText.text = "Fear level: " + Convert.ToInt32(FearLevel).ToString() + "%";
    }
}
