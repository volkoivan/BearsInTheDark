using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class HowToPlay : MonoBehaviour {
	private bool isPressed = false;
	public int press = 0;
	// Use this for initialization
	void Start () {
		//aboutUsPanel.transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isPressed) {	
			gameObject.transform.GetChild(0).GetComponent<Text>().text = "Click left mouse button to throw a pine cone\n\nClick right mouse button to turn on/off the light";
			gameObject.transform.GetChild(1).GetComponent<Text>().text = "Click to continue";
						if (gameObject.transform.localScale.x < 0.9)
								gameObject.transform.localScale += new Vector3 (0.04f, 0.04f, 0);
				}

		if (Input.GetMouseButtonDown (0)) {
						isPressed = false;
						press++;
				}
			if (press==2)
			{
				gameObject.transform.GetChild(0).GetComponent<Text>().text = "The light recharges when it turned off\n\nWithout the light your fear level increases";
				gameObject.transform.GetChild(1).GetComponent<Text>().text = "Click to close";
			}
			if (press >= 3) {
						if (gameObject.transform.localScale.x > 0)
								gameObject.transform.localScale -= new Vector3 (0.04f, 0.04f, 0);
						else
								press = 0;
				}

	}
	public void isPress()
	{
		isPressed = true;
	}
}