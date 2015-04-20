using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    public static bool isGameOver = false;
    private float timer;
    private bool isHighScoreBeaten = false;
    public GameObject GameOverScreen;
    public GameObject Instruction;

	// Use this for initialization
	void Start () {
        LightScript.LightLevelText.GetComponent<Animator>().Play("UILightLevelFade");
        LevelManager.FearLevelText.GetComponent<Animator>().Play("UILightLevelFade");
        LevelManager.LevelTimerText.GetComponent<Animator>().Play("UIGameOverTime");
        Instantiate(GameOverScreen);
        timer = 2f;
        if (PlayerPrefs.GetFloat("Best time")<LevelManager.TimerLevel) {
            PlayerPrefs.SetFloat("Best time",LevelManager.TimerLevel);
            isHighScoreBeaten = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    timer -= Time.deltaTime;
        if (timer<=0) {
        timer = 50000f;
        var cloneInstruction = (GameObject) Instantiate(Instruction);
            foreach (var obj in GameObject.FindGameObjectsWithTag("UI")) {
                if (obj.name == "GamePlayPanel") cloneInstruction.transform.SetParent(obj.transform,false);
            }
            if (isHighScoreBeaten)
            LevelManager.LevelTimerText.GetComponent<Text>().text = "New Highscore!\nYour time:\n" +
                                                                        LevelManager.LevelTimerText.GetComponent<Text>()
                                                                            .text+"\n\n";
            else
                LevelManager.LevelTimerText.GetComponent<Text>().text = "Your time:\n" +
                                                                            LevelManager.LevelTimerText.GetComponent<Text>()
                                                                                .text + "\n";
            
	    }
	}
}
