using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static float FearLevel;
    public int Money;
    public static float TimerLevel;
    public float TimerBear;
    public GameObject BearGameObject;
    private Text LevelTimerText;

	// Use this for initialization
	void Start () {
	    FearLevel = 0;
	    Money = 0;
        TimerLevel = 0f;
	    TimerBear = 5f;
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
        }
        string minutes = (Convert.ToInt32(TimerLevel) / 60).ToString();
        string seconds = (Convert.ToInt32(TimerLevel) % 60).ToString();
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
	}
}
