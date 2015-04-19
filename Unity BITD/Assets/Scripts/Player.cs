using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject player;
	public GameObject bump;
	
	// Use this for initialization
	void Start () {
		//начальное направление игрока - ось OX!	
	}
	
	// Update is called once per frame
	void Update () {

		//движение игрока за мышкой
		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
		transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);

		//вылет шишки по нажатию на левую кнопку мыши
		if (Input.GetMouseButtonDown(0)) {
			var cloneBump = (GameObject)Instantiate (bump);
			Vector3 bumpDir = mousePosition - player.transform.position;
			cloneBump.transform.rotation = Quaternion.LookRotation (Vector3.forward, bumpDir);
			cloneBump.rigidbody2D.AddRelativeForce (new Vector2 (0f, 500f));

				}
	}
}
