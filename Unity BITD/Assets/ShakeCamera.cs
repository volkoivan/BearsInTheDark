using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour
{
    private const int MaxFear = 100;
    public static float FearLevel;
    private bool isLightOn;
    private float timerToShake;
    private float newx, newy;
    private Vector3 cameraStartingPosition;
    private float journeyLength;
    public GameObject NoiseObject;
    public GameObject NoiseSound;

	// Use this for initialization
    void Start()
    {
        timerToShake = 0f;
        FearLevel = 0;
        cameraStartingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	    if (LevelManager.isGameStarted && !LevelManager.isGameOver) {
            timerToShake += Time.deltaTime;
            isLightOn = GameObject.FindGameObjectWithTag("Light").GetComponent<LightScript>().isOn;
            if (isLightOn)
            {
                FearLevel -= Time.deltaTime * 15f;
            }
            //Управление страхом
            else
            {
                FearLevel += Time.deltaTime * 10f*Mathf.Log10(LevelManager.TimerLevel);
            }
            if (FearLevel >= MaxFear) FearLevel = MaxFear;
            if (FearLevel <= 0) FearLevel = 0;
            //FearLevelText.text = "Fear level: " + Convert.ToInt32(FearLevel) + "%";
            if (timerToShake > 0.2f / (FearLevel + 0.1f))
            {
                timerToShake = 0f;
                newx = cameraStartingPosition.x + Random.Range(-FearLevel / 100f, FearLevel / 100f);
                newy = cameraStartingPosition.y + Random.Range(-FearLevel / 100f, FearLevel / 100f);
                transform.position = new Vector3(newx, newy, 0);
            }
            NoiseObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, FearLevel / 200);
	        NoiseSound.GetComponent<AudioSource>().volume = FearLevel/100f;
	    }
	}
}
