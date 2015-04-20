using System;
using System.Threading;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class BearScript : MonoBehaviour {
	private bool isHit = false;
    private const float BearSpeed = 100f;
    private Quaternion RotationFacingPlayer;
    public GameObject[] BearSounds;
    // Use this for initialization
    private void Start() {
        Instantiate(BearSounds[Random.Range(4,7)]);
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
        RotationFacingPlayer = transform.rotation;
        rigidbody2D.AddRelativeForce(new Vector2(0, BearSpeed));
        transform.localEulerAngles= new Vector3(0,0,0);
        if (transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2f, 0, 0)).x) {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0, 0)).x)
        {
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }


	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("Yes!");
        if (col.gameObject.tag == "Player") {
			Debug.Log ("???");
            LevelManager.isGameOver = true;
        }
        if ((col.gameObject.tag == "Bump") && (!isHit))
        {
            var soundClone = (GameObject)Instantiate(BearSounds[Random.Range(0,4)]);
            Destroy(soundClone,3f);
            Debug.Log("!!!");
            transform.rotation = RotationFacingPlayer;
			rigidbody2D.AddRelativeForce(new Vector2 (0, -3*BearSpeed));
		    gameObject.GetComponent<Animator>().Play("BearRotatingAnimation");
		    gameObject.GetComponent<Animator>().speed = 3;
            transform.localEulerAngles = new Vector3(0, 0, 0);
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			isHit = true;
			Destroy(col.gameObject);
		}
    }
}