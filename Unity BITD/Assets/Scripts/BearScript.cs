using System.Threading;
using UnityEngine;
using System.Collections;

public class BearScript : MonoBehaviour {
	private bool isHit = false;
    private const float BearSpeed = 100f;
    // Use this for initialization
    private void Start() {
        InstantiateAtBorder();
        MoveToThePlayer();
    }

    // Update is called once per frame
    private void Update() {
        if (LevelManager.isGameOver) rigidbody2D.velocity = new Vector2(0,0);
    }

    private void InstantiateAtBorder() {
        float x, y;
        if (Random.Range(0, 2) == 1) {
            x = Random.Range(0, Screen.width);
            y = Random.Range(0, 2)*Screen.height;
        }
        else {
            x = Random.Range(0, 2)*Screen.width;
            y = Random.Range(0, Screen.height);
        }
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, transform.position.z));
    }


    private void MoveToThePlayer() {
        Vector3 targetDir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDir);
        rigidbody2D.AddRelativeForce(new Vector2(0, BearSpeed));
    }


	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("Yes!");
        if (col.gameObject.tag == "Player") {
			Debug.Log ("???");
            LevelManager.isGameOver = true;
            
        }
		if ((col.gameObject.tag == "Bump") && (!isHit)) {
			Debug.Log ("!!!");
			rigidbody2D.AddRelativeForce(new Vector2 (0, -3*BearSpeed));
			transform.Rotate(0,0,transform.eulerAngles.x+180);
			isHit = true;
			Destroy(col.gameObject);
		}
    }
}