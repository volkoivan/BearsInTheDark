using UnityEngine;
using System.Collections;

public class AboutUs : MonoBehaviour {
	private bool isPressed = false;
	private int isPressed1 = 0;
	// Use this for initialization
	void Start () {
		//aboutUsPanel.transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if (isPressed) {
						if (gameObject.transform.localScale.x < 0.9)
								gameObject.transform.localScale += new Vector3 (0.04f, 0.04f, 0);

						if (Input.GetMouseButtonDown (0)){ 
								isPressed1 ++;
						isPressed = false;
								}
				}
		if (isPressed1==1){
			if (gameObject.transform.localScale.x >0)
				gameObject.transform.localScale -= new Vector3(0.04f,0.04f,0);
			else{
				isPressed1 = 0;}
				}
	}
	public void isPress()
	{
		isPressed = true;
	}
}
