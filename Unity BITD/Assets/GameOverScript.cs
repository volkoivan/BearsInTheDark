using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
    public static bool isGameOver = false;
    private float timer;

	// Use this for initialization
	void Start () {
        LightScript.LightLevelText.GetComponent<Animator>().Play("UILightLevelFade");
        LevelManager.FearLevelText.GetComponent<Animator>().Play("UILightLevelFade");
        LevelManager.LevelTimerText.GetComponent<Animator>().Play("UIGameOverTime");
        timer = 2f;
	}
	
	// Update is called once per frame
	void Update () {
	    timer -= Time.deltaTime;
        if (timer<=0) {
            timer = 50000f; 
                LevelManager.LevelTimerText.GetComponent<Text>().text = "Your time:\n" +
                                                                        LevelManager.LevelTimerText.GetComponent<Text>()
                                                                            .text+"\n";
            
	    }
	}
}
