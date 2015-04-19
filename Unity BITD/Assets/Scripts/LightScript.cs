using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightScript : MonoBehaviour {
    private const int MaxIntensity = 8;
    private const int MaxAngle = 100;
    private const int MaxCharge = 100;

    private float lightCharge;
    public  bool isOn;
    public Light LightSource;
    public Text LightLevelText;

	// Use this for initialization
	void Start () {
        lightCharge = MaxCharge;
	    isOn = true;
	    foreach (var obj in GameObject.FindGameObjectsWithTag("UI")) {
	        if (obj.name == "LightLevel") LightLevelText = obj.GetComponent<Text>();
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    //управления яркостью фонарика
        
        if (Input.GetMouseButtonDown(1)) isOn = !isOn;
	    if (isOn) {
	        LightSource.spotAngle = lightCharge*MaxAngle/MaxCharge;
            LightSource.intensity = lightCharge * MaxIntensity / MaxCharge;
	       // lightCharge -= 7.5f*Time.deltaTime;
	    }
	    else {
	        LightSource.intensity = 0;
	        lightCharge += 5*Time.deltaTime/2;
	    }
        if (lightCharge <= 0) isOn = false;
        if (lightCharge >= 100) lightCharge = 100;

        //отображение информации о заряде
	    LightLevelText.text = "Battery level: " + Convert.ToInt32(lightCharge).ToString() + "%";

	}
}
