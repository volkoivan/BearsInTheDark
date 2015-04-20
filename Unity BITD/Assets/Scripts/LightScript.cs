using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class LightScript : MonoBehaviour {
    private const int MaxIntensity = 8;
    private const int MaxAngle = 100;
    private const int MaxCharge = 100;
    public GameObject FlashlightSound;
    private float timerRecharge = 0.7f;

    public static GameObject LightLevelText;
    public Light LightSource;
    public bool isOn;
    private float lightCharge;
    // Use this for initialization
    private void Start() {
        lightCharge = MaxCharge;
        isOn = true;
    }

    // Update is called once per frame
    private void Update() {
        timerRecharge-=Time.deltaTime;
        //управления яркостью фонарика
        if (!LevelManager.isGameOver && LevelManager.isGameStarted)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("UI"))
            {
                if (obj.name == "LightLevel") LightLevelText = obj;
            }
            if (Input.GetMouseButtonDown(1) && timerRecharge<0f) {
                timerRecharge = 0.7f;
                var cloneSound = (GameObject) Instantiate(FlashlightSound);
                Destroy(cloneSound,1f);
                isOn = !isOn;
            }
            if (isOn) {
                lightCharge -= 10*Time.deltaTime;
                LightSource.spotAngle = lightCharge*MaxAngle/MaxCharge;
                LightSource.intensity = lightCharge*MaxIntensity/MaxCharge;
            }
            else {
                LightSource.intensity = 0;
                LightSource.spotAngle = 0;
                lightCharge += 12*Time.deltaTime;
            }
            if (lightCharge <= 0) isOn = false;
            if (lightCharge >= 100) lightCharge = 100;

            //отображение информации о заряде
           // LightLevelText.GetComponent<Text>().text = "Battery level: " + Convert.ToInt32(lightCharge) + "%";
        }
    }

    public void PlayAnimation() {
        GetComponent<Animator>().Play("LightAnim");

    }
}